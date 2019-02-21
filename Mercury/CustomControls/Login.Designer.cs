namespace Mercury.CustomControls
{
    partial class Login
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginPanel = new pivyLab.Control.RoundCustomPanel();
            this.eyeIcon = new System.Windows.Forms.PictureBox();
            this.signinButton = new pivyLab.Control.FlatEllButton();
            this.loginCheck = new System.Windows.Forms.PictureBox();
            this.loginCheckText = new System.Windows.Forms.Label();
            this.passwordSeparator = new pivyLab.Control.Separator();
            this.emailSeparator = new pivyLab.Control.Separator();
            this.passwordData = new System.Windows.Forms.TextBox();
            this.emailData = new System.Windows.Forms.TextBox();
            this.loginPanelLabel = new System.Windows.Forms.Label();
            this.loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginCheck)).BeginInit();
            this.SuspendLayout();
            // 
            // loginPanel
            // 
            this.loginPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loginPanel.Controls.Add(this.eyeIcon);
            this.loginPanel.Controls.Add(this.signinButton);
            this.loginPanel.Controls.Add(this.loginCheck);
            this.loginPanel.Controls.Add(this.loginCheckText);
            this.loginPanel.Controls.Add(this.passwordSeparator);
            this.loginPanel.Controls.Add(this.emailSeparator);
            this.loginPanel.Controls.Add(this.passwordData);
            this.loginPanel.Controls.Add(this.emailData);
            this.loginPanel.Controls.Add(this.loginPanelLabel);
            this.loginPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.loginPanel.Location = new System.Drawing.Point(352, 66);
            this.loginPanel.Name = "loginPanel";
            this.loginPanel.RoundRadius = 25;
            this.loginPanel.Size = new System.Drawing.Size(417, 369);
            this.loginPanel.TabIndex = 1;
            // 
            // eyeIcon
            // 
            this.eyeIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.eyeIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eyeIcon.Image = global::Mercury.Properties.Resources.eyeView;
            this.eyeIcon.Location = new System.Drawing.Point(335, 185);
            this.eyeIcon.Name = "eyeIcon";
            this.eyeIcon.Size = new System.Drawing.Size(24, 24);
            this.eyeIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.eyeIcon.TabIndex = 6;
            this.eyeIcon.TabStop = false;
            // 
            // signinButton
            // 
            this.signinButton.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.signinButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.signinButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signinButton.ForeColor = System.Drawing.Color.White;
            this.signinButton.Location = new System.Drawing.Point(51, 293);
            this.signinButton.Name = "signinButton";
            this.signinButton.RoundRadius = 2;
            this.signinButton.Size = new System.Drawing.Size(310, 37);
            this.signinButton.TabIndex = 5;
            this.signinButton.Text = "Вход";
            this.signinButton.UseVisualStyleBackColor = false;
            this.signinButton.Click += new System.EventHandler(this.signinButton_Click);
            // 
            // loginCheck
            // 
            this.loginCheck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.loginCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginCheck.Location = new System.Drawing.Point(51, 247);
            this.loginCheck.Name = "loginCheck";
            this.loginCheck.Size = new System.Drawing.Size(18, 18);
            this.loginCheck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.loginCheck.TabIndex = 3;
            this.loginCheck.TabStop = false;
            // 
            // loginCheckText
            // 
            this.loginCheckText.BackColor = System.Drawing.Color.Transparent;
            this.loginCheckText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginCheckText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginCheckText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.loginCheckText.Location = new System.Drawing.Point(65, 248);
            this.loginCheckText.Name = "loginCheckText";
            this.loginCheckText.Padding = new System.Windows.Forms.Padding(13, 0, 0, 0);
            this.loginCheckText.Size = new System.Drawing.Size(208, 18);
            this.loginCheckText.TabIndex = 4;
            this.loginCheckText.Text = "Оставаться в системе";
            this.loginCheckText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // passwordSeparator
            // 
            this.passwordSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.passwordSeparator.Location = new System.Drawing.Point(51, 214);
            this.passwordSeparator.Name = "passwordSeparator";
            this.passwordSeparator.Size = new System.Drawing.Size(310, 1);
            this.passwordSeparator.TabIndex = 2;
            // 
            // emailSeparator
            // 
            this.emailSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.emailSeparator.Location = new System.Drawing.Point(51, 147);
            this.emailSeparator.Name = "emailSeparator";
            this.emailSeparator.Size = new System.Drawing.Size(310, 1);
            this.emailSeparator.TabIndex = 2;
            // 
            // passwordData
            // 
            this.passwordData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.passwordData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passwordData.ForeColor = System.Drawing.Color.White;
            this.passwordData.Location = new System.Drawing.Point(51, 188);
            this.passwordData.MaxLength = 40;
            this.passwordData.Name = "passwordData";
            this.passwordData.Size = new System.Drawing.Size(266, 19);
            this.passwordData.TabIndex = 2;
            this.passwordData.TabStop = false;
            // 
            // emailData
            // 
            this.emailData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.emailData.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailData.ForeColor = System.Drawing.Color.White;
            this.emailData.Location = new System.Drawing.Point(51, 121);
            this.emailData.MaxLength = 32;
            this.emailData.Name = "emailData";
            this.emailData.Size = new System.Drawing.Size(266, 19);
            this.emailData.TabIndex = 1;
            // 
            // loginPanelLabel
            // 
            this.loginPanelLabel.AutoSize = true;
            this.loginPanelLabel.BackColor = System.Drawing.Color.Transparent;
            this.loginPanelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginPanelLabel.ForeColor = System.Drawing.Color.White;
            this.loginPanelLabel.Location = new System.Drawing.Point(45, 30);
            this.loginPanelLabel.Margin = new System.Windows.Forms.Padding(45, 30, 30, 30);
            this.loginPanelLabel.Name = "loginPanelLabel";
            this.loginPanelLabel.Size = new System.Drawing.Size(246, 31);
            this.loginPanelLabel.TabIndex = 0;
            this.loginPanelLabel.Text = "Авторизироваться";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.Controls.Add(this.loginPanel);
            this.Name = "Login";
            this.Size = new System.Drawing.Size(1120, 643);
            this.loginPanel.ResumeLayout(false);
            this.loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eyeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loginCheck)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private pivyLab.Control.RoundCustomPanel loginPanel;
        private System.Windows.Forms.Label loginPanelLabel;
        private System.Windows.Forms.TextBox emailData;
        private pivyLab.Control.Separator emailSeparator;
        private pivyLab.Control.Separator passwordSeparator;
        private System.Windows.Forms.TextBox passwordData;
        private System.Windows.Forms.PictureBox loginCheck;
        private System.Windows.Forms.Label loginCheckText;
        private pivyLab.Control.FlatEllButton signinButton;
        private System.Windows.Forms.PictureBox eyeIcon;
    }
}
