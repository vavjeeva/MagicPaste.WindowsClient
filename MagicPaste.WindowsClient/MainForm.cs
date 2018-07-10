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
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point pt);

        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr WindowFromPoint(Point pt);

        // Activate an application window.
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImportAttribute("user32.dll", EntryPoint = "GetForegroundWindow")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        private string originalClipboardText = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            HotkeyManager.Current.AddOrReplace("OnHotKeyPressed", Keys.Control | Keys.Shift | Keys.C, true, OnHotKeyPressed);
            AzureSignalRClient.Initialize();

            //this.WindowState = FormWindowState.Minimized;
            //MinimizeToTray();
            //this.ShowInTaskbar = false;
        }

        private void OnHotKeyPressed(object sender, HotkeyEventArgs e)
        {
            try
            {
                CopySelectedDataToClipboard();
                var clipText = Clipboard.GetText();
                if (!string.IsNullOrEmpty(clipText))
                {
                    originalClipboardText = clipText;
                    AzureSignalRClient.SendData(clipText);                    
                    Clipboard.SetText(string.Empty);
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
        }
        
        private async void CopySelectedDataToClipboard()
        {
            Point p;
            if (GetCursorPos(out p))
            {
                IntPtr ptr = WindowFromPoint(p);
                if (ptr != IntPtr.Zero)
                {
                    SetForegroundWindow(ptr);

                    //wait for window to get focus quick and ugly
                    // probably a cleaner way to wait for windows to send a message
                    // that it has updated the foreground window
                    await Task.Delay(300);

                    //try to copy text in the current window
                    SendKeys.Send("^c");

                    await WaitForClipboardToUpdate(originalClipboardText);
                }
            }
        }

        private static async Task WaitForClipboardToUpdate(string clipboardText)
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (true)
            {
                if (await DoClipboardCheck(clipboardText)) return;
                if (sw.ElapsedMilliseconds >= 1500) throw new Exception("TIMED OUT WAITING FOR CLIPBOARD TO UPDATE.");
            }
        }

        private static async Task<bool> DoClipboardCheck(string clipboardText)
        {
            await Task.Delay(100);
            if (!Clipboard.ContainsText()) return false;
            var currentText = Clipboard.GetText();
            return currentText != clipboardText;
        }
    }
}
