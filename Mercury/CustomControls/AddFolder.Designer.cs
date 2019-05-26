namespace Mercury.CustomControls
{
    partial class AddFolder
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
            this.logoLabel = new System.Windows.Forms.Label();
            this.safeNameSeparator = new pivyLab.Control.Separator();
            this.folderName = new System.Windows.Forms.TextBox();
            this.cancel = new pivyLab.Control.FlatEllButton();
            this.saveButton = new pivyLab.Control.FlatEllButton();
            this.SuspendLayout();
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logoLabel.ForeColor = System.Drawing.Color.White;
            this.logoLabel.Location = new System.Drawing.Point(33, 33);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(214, 33);
            this.logoLabel.TabIndex = 1;
            this.logoLabel.Text = "Создать папку";
            // 
            // safeNameSeparator
            // 
            this.safeNameSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.safeNameSeparator.Location = new System.Drawing.Point(88, 133);
            this.safeNameSeparator.Name = "safeNameSeparator";
            this.safeNameSeparator.Size = new System.Drawing.Size(310, 1);
            this.safeNameSeparator.TabIndex = 6;
            // 
            // folderName
            // 
            this.folderName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.folderName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.folderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.folderName.ForeColor = System.Drawing.Color.White;
            this.folderName.Location = new System.Drawing.Point(88, 107);
            this.folderName.MaxLength = 32;
            this.folderName.Name = "folderName";
            this.folderName.Size = new System.Drawing.Size(310, 19);
            this.folderName.TabIndex = 5;
            // 
            // cancel
            // 
            this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancel.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.ForeColor = System.Drawing.Color.White;
            this.cancel.Location = new System.Drawing.Point(253, 207);
            this.cancel.Name = "cancel";
            this.cancel.RoundRadius = 2;
            this.cancel.Size = new System.Drawing.Size(145, 33);
            this.cancel.TabIndex = 7;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(88, 207);
            this.saveButton.Name = "saveButton";
            this.saveButton.RoundRadius = 2;
            this.saveButton.Size = new System.Drawing.Size(145, 33);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Создать";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // AddFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(487, 272);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.safeNameSeparator);
            this.Controls.Add(this.folderName);
            this.Controls.Add(this.logoLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddFolder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.AddFolder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label logoLabel;
        private pivyLab.Control.Separator safeNameSeparator;
        private System.Windows.Forms.TextBox folderName;
        private pivyLab.Control.FlatEllButton cancel;
        private pivyLab.Control.FlatEllButton saveButton;
    }
}