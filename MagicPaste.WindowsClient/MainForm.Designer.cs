namespace MagicPaste.WindowsClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.notifyMagicPasteIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtIncomingData = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(871, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Press CTRL + SHIFT + C to send clipboard data from WinForms";
            // 
            // notifyMagicPasteIcon
            // 
            this.notifyMagicPasteIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyMagicPasteIcon.Icon")));
            this.notifyMagicPasteIcon.Text = "MagicPaste";
            this.notifyMagicPasteIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyMagicPasteIcon_MouseDoubleClick);
            // 
            // txtIncomingData
            // 
            this.txtIncomingData.BackColor = System.Drawing.SystemColors.Highlight;
            this.txtIncomingData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncomingData.ForeColor = System.Drawing.SystemColors.Info;
            this.txtIncomingData.Location = new System.Drawing.Point(244, 63);
            this.txtIncomingData.Name = "txtIncomingData";
            this.txtIncomingData.Size = new System.Drawing.Size(638, 45);
            this.txtIncomingData.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Incoming Data";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 124);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIncomingData);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Magic Paste - WinForms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Minimized);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon notifyMagicPasteIcon;
        public System.Windows.Forms.TextBox txtIncomingData;
        private System.Windows.Forms.Label label2;
    }
}

