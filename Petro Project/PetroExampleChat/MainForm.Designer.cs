namespace PetroExampleChat
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnectIPEndpoint = new System.Windows.Forms.TextBox();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.lstChatMessages = new System.Windows.Forms.ListBox();
            this.txtChatMessage = new System.Windows.Forms.TextBox();
            this.cmdSendMessage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdHost = new System.Windows.Forms.Button();
            this.txtHostName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connect";
            // 
            // txtConnectIPEndpoint
            // 
            this.txtConnectIPEndpoint.Location = new System.Drawing.Point(74, 6);
            this.txtConnectIPEndpoint.Name = "txtConnectIPEndpoint";
            this.txtConnectIPEndpoint.Size = new System.Drawing.Size(162, 20);
            this.txtConnectIPEndpoint.TabIndex = 1;
            this.txtConnectIPEndpoint.Text = "127.0.0.1:21100";
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(242, 4);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnect.TabIndex = 2;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lstChatMessages
            // 
            this.lstChatMessages.FormattingEnabled = true;
            this.lstChatMessages.Location = new System.Drawing.Point(12, 32);
            this.lstChatMessages.Name = "lstChatMessages";
            this.lstChatMessages.Size = new System.Drawing.Size(622, 173);
            this.lstChatMessages.TabIndex = 3;
            // 
            // txtChatMessage
            // 
            this.txtChatMessage.Location = new System.Drawing.Point(12, 211);
            this.txtChatMessage.Multiline = true;
            this.txtChatMessage.Name = "txtChatMessage";
            this.txtChatMessage.Size = new System.Drawing.Size(547, 41);
            this.txtChatMessage.TabIndex = 4;
            // 
            // cmdSendMessage
            // 
            this.cmdSendMessage.Location = new System.Drawing.Point(565, 211);
            this.cmdSendMessage.Name = "cmdSendMessage";
            this.cmdSendMessage.Size = new System.Drawing.Size(69, 41);
            this.cmdSendMessage.TabIndex = 5;
            this.cmdSendMessage.Text = "Send Message";
            this.cmdSendMessage.UseVisualStyleBackColor = true;
            this.cmdSendMessage.Click += new System.EventHandler(this.cmdSendMessage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(323, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(9, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "|";
            // 
            // cmdHost
            // 
            this.cmdHost.Location = new System.Drawing.Point(560, 4);
            this.cmdHost.Name = "cmdHost";
            this.cmdHost.Size = new System.Drawing.Size(75, 23);
            this.cmdHost.TabIndex = 9;
            this.cmdHost.Text = "Host";
            this.cmdHost.UseVisualStyleBackColor = true;
            this.cmdHost.Click += new System.EventHandler(this.cmdHost_Click);
            // 
            // txtHostName
            // 
            this.txtHostName.Location = new System.Drawing.Point(392, 6);
            this.txtHostName.Name = "txtHostName";
            this.txtHostName.Size = new System.Drawing.Size(162, 20);
            this.txtHostName.TabIndex = 8;
            this.txtHostName.Text = "My Server";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(338, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Host";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 264);
            this.Controls.Add(this.cmdHost);
            this.Controls.Add(this.txtHostName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdSendMessage);
            this.Controls.Add(this.txtChatMessage);
            this.Controls.Add(this.lstChatMessages);
            this.Controls.Add(this.cmdConnect);
            this.Controls.Add(this.txtConnectIPEndpoint);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Petro Example Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnectIPEndpoint;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.ListBox lstChatMessages;
        private System.Windows.Forms.TextBox txtChatMessage;
        private System.Windows.Forms.Button cmdSendMessage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdHost;
        private System.Windows.Forms.TextBox txtHostName;
        private System.Windows.Forms.Label label3;
    }
}

