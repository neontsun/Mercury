namespace Mercury.CustomControls
{
    partial class SafeMenu
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
            this.editSafe = new System.Windows.Forms.Label();
            this.deleteSafe = new System.Windows.Forms.Label();
            this.separator1 = new pivyLab.Control.Separator();
            this.inviteToSafe = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.safeID = new System.Windows.Forms.Label();
            this.separator2 = new pivyLab.Control.Separator();
            this.SuspendLayout();
            // 
            // editSafe
            // 
            this.editSafe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.editSafe.AutoSize = true;
            this.editSafe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editSafe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.editSafe.Location = new System.Drawing.Point(28, 111);
            this.editSafe.Name = "editSafe";
            this.editSafe.Size = new System.Drawing.Size(114, 18);
            this.editSafe.TabIndex = 9;
            this.editSafe.Text = "Редактировать";
            // 
            // deleteSafe
            // 
            this.deleteSafe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.deleteSafe.AutoSize = true;
            this.deleteSafe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteSafe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.deleteSafe.Location = new System.Drawing.Point(28, 207);
            this.deleteSafe.Name = "deleteSafe";
            this.deleteSafe.Size = new System.Drawing.Size(108, 18);
            this.deleteSafe.TabIndex = 10;
            this.deleteSafe.Text = "Удалить сейф";
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator1.Location = new System.Drawing.Point(0, 191);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(177, 1);
            this.separator1.TabIndex = 11;
            // 
            // inviteToSafe
            // 
            this.inviteToSafe.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.inviteToSafe.AutoSize = true;
            this.inviteToSafe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.inviteToSafe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.inviteToSafe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.inviteToSafe.Location = new System.Drawing.Point(28, 79);
            this.inviteToSafe.Name = "inviteToSafe";
            this.inviteToSafe.Size = new System.Drawing.Size(89, 18);
            this.inviteToSafe.TabIndex = 9;
            this.inviteToSafe.Text = "Пригласить";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.label2.Location = new System.Drawing.Point(28, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "ID: ";
            // 
            // safeID
            // 
            this.safeID.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.safeID.AutoSize = true;
            this.safeID.Cursor = System.Windows.Forms.Cursors.Default;
            this.safeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.safeID.Location = new System.Drawing.Point(48, 21);
            this.safeID.Name = "safeID";
            this.safeID.Size = new System.Drawing.Size(19, 16);
            this.safeID.TabIndex = 9;
            this.safeID.Text = "id";
            // 
            // separator2
            // 
            this.separator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator2.Location = new System.Drawing.Point(0, 57);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(177, 1);
            this.separator2.TabIndex = 11;
            // 
            // SafeMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(177, 244);
            this.Controls.Add(this.separator2);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.safeID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inviteToSafe);
            this.Controls.Add(this.editSafe);
            this.Controls.Add(this.deleteSafe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SafeMenu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label editSafe;
        private System.Windows.Forms.Label deleteSafe;
        private pivyLab.Control.Separator separator1;
        private System.Windows.Forms.Label inviteToSafe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label safeID;
        private pivyLab.Control.Separator separator2;
    }
}