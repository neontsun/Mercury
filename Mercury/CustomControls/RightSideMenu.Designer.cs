namespace Mercury.CustomControls
{
    partial class RightSideMenu
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
            this.exit = new System.Windows.Forms.Label();
            this.settings = new System.Windows.Forms.Label();
            this.userIDLabel = new System.Windows.Forms.Label();
            this.userID = new System.Windows.Forms.Label();
            this.separator2 = new pivyLab.Control.Separator();
            this.separator1 = new pivyLab.Control.Separator();
            this.SuspendLayout();
            // 
            // exit
            // 
            this.exit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.exit.AutoSize = true;
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.exit.Location = new System.Drawing.Point(23, 204);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(52, 18);
            this.exit.TabIndex = 8;
            this.exit.Text = "Выйти";
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // settings
            // 
            this.settings.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.settings.AutoSize = true;
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settings.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.settings.Location = new System.Drawing.Point(23, 74);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(83, 18);
            this.settings.TabIndex = 8;
            this.settings.Text = "Настройки";
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // userIDLabel
            // 
            this.userIDLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.userIDLabel.AutoSize = true;
            this.userIDLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.userIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userIDLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.userIDLabel.Location = new System.Drawing.Point(23, 20);
            this.userIDLabel.Name = "userIDLabel";
            this.userIDLabel.Size = new System.Drawing.Size(24, 16);
            this.userIDLabel.TabIndex = 8;
            this.userIDLabel.Text = "ID:";
            this.userIDLabel.Click += new System.EventHandler(this.settings_Click);
            // 
            // userID
            // 
            this.userID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.userID.AutoSize = true;
            this.userID.Cursor = System.Windows.Forms.Cursors.Default;
            this.userID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.userID.Location = new System.Drawing.Point(46, 20);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(19, 16);
            this.userID.TabIndex = 8;
            this.userID.Text = "id";
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator2.Location = new System.Drawing.Point(0, 55);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(177, 1);
            this.separator2.TabIndex = 12;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator1.Location = new System.Drawing.Point(0, 189);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(177, 1);
            this.separator1.TabIndex = 13;
            // 
            // RightSideMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(177, 244);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.userID);
            this.Controls.Add(this.userIDLabel);
            this.Controls.Add(this.settings);
            this.Controls.Add(this.exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RightSideMenu";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label exit;
        private System.Windows.Forms.Label settings;
        private System.Windows.Forms.Label userIDLabel;
        private System.Windows.Forms.Label userID;
        private pivyLab.Control.Separator separator2;
        private pivyLab.Control.Separator separator1;
    }
}