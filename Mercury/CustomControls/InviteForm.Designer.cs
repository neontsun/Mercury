namespace Mercury.CustomControls
{
    partial class InviteForm
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
            this.invite = new pivyLab.Control.FlatEllButton();
            this.cancel = new pivyLab.Control.FlatEllButton();
            this.safeNameSeparator = new pivyLab.Control.Separator();
            this.Email = new System.Windows.Forms.TextBox();
            this.logoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // invite
            // 
            this.invite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invite.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.invite.Cursor = System.Windows.Forms.Cursors.Hand;
            this.invite.ForeColor = System.Drawing.Color.White;
            this.invite.Location = new System.Drawing.Point(49, 195);
            this.invite.Name = "invite";
            this.invite.RoundRadius = 2;
            this.invite.Size = new System.Drawing.Size(168, 34);
            this.invite.TabIndex = 3;
            this.invite.Text = "Пригласить";
            this.invite.UseVisualStyleBackColor = true;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(223, 195);
            this.cancel.Name = "cancel";
            this.cancel.RoundRadius = 2;
            this.cancel.Size = new System.Drawing.Size(168, 34);
            this.cancel.TabIndex = 3;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // safeNameSeparator
            // 
            this.safeNameSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.safeNameSeparator.Location = new System.Drawing.Point(65, 144);
            this.safeNameSeparator.Name = "safeNameSeparator";
            this.safeNameSeparator.Size = new System.Drawing.Size(310, 1);
            this.safeNameSeparator.TabIndex = 7;
            // 
            // Email
            // 
            this.Email.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Email.ForeColor = System.Drawing.Color.White;
            this.Email.Location = new System.Drawing.Point(65, 118);
            this.Email.MaxLength = 32;
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(310, 19);
            this.Email.TabIndex = 6;
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(33, 33);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(171, 33);
            this.logoLabel.TabIndex = 5;
            this.logoLabel.Text = "Пригласить";
            // 
            // InviteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(441, 267);
            this.Controls.Add(this.safeNameSeparator);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.logoLabel);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.invite);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InviteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private pivyLab.Control.FlatEllButton invite;
        private pivyLab.Control.FlatEllButton cancel;
        private pivyLab.Control.Separator safeNameSeparator;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.Label logoLabel;
    }
}