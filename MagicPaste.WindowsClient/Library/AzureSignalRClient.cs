using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace MagicPaste.WindowsClient
{
    public static class AzureSignalRClient
    {
        private static HubConnection connection;
        public static async void Initialize()
        {
            connection = new HubConnectionBuilder()
                 .WithUrl("https://magicpaste.azurewebsites.net/MagicPaste")
                 .Build();

            connection.On<string>("ReceiveData", (msg) =>
            {
                Console.WriteLine(msg);
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

        public static async void SendData(string msg)
        {
            await connection.InvokeAsync("SendData", msg);
        }
    }
}
