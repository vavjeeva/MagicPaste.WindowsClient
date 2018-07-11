using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace MagicPaste.WindowsClient
{
    public partial class MainForm : Form
    {
        AzureSignalRClient client;
        public MainForm()
        {
            InitializeComponent();
            client = new AzureSignalRClient(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HotkeyManager.Current.AddOrReplace("OnHotKeyPressed", Keys.Control | Keys.Shift | Keys.C, true, OnHotKeyPressed);
            client.Initialize();

            this.WindowState = FormWindowState.Minimized;
            MinimizeToTray();
            this.ShowInTaskbar = false;
        }

        private void OnHotKeyPressed(object sender, HotkeyEventArgs e)
        {
            try
            {                          
                var clipboardText = Clipboard.GetText();
                if (!string.IsNullOrEmpty(clipboardText))
                {
                    client.SendData(clipboardText);                                        
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:", ex.Message);
            }
            finally
            {
                e.Handled = true;
            }
        }
        private void MainForm_Minimized(object sender, EventArgs e)
        {
            MinimizeToTray();
        }

        private void MinimizeToTray()
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyMagicPasteIcon.Visible = true;
            }
        }

        private void notifyMagicPasteIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyMagicPasteIcon.Visible = false;
            this.ShowInTaskbar = true;
        }

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            notifyMagicPasteIcon.Visible = false;
            client.Close();
        }              
    }
}
