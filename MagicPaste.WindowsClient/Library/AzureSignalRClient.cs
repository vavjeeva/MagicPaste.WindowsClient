using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MagicPaste.WindowsClient
{
    public class AzureSignalRClient
    {
        private MainForm mainForm;
        public AzureSignalRClient(MainForm _mainForm)
        {
            mainForm = _mainForm;
        }
        private HubConnection connection;
        TaskScheduler uiTaskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        public async void Initialize()
        {
            connection = new HubConnectionBuilder()
                 .WithUrl("https://magicpaste.azurewebsites.net/MagicPaste")                 
                 .Build();

            connection.On<string>("ReceiveData", (msg) =>
            {
                mainForm.Invoke((Action)(() =>
                   mainForm.txtIncomingData.Text = msg
                   ));
            });

            try
            {
                await connection.StartAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void SendData(string msg)
        {
            await connection.InvokeAsync("SendData", msg);
        }

        public async void Close()
        {
            await connection.StopAsync();
        }
    }
}
