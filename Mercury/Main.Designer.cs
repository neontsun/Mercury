namespace Mercury
{
    partial class Main
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.startPanel = new System.Windows.Forms.Panel();
            this.textLogo = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Label();
            this.registrationButton = new pivyLab.Control.FlatEllButton();
            this.separator1 = new pivyLab.Control.Separator();
            this.textLogoMain = new System.Windows.Forms.Label();
            this.logoSeparatorHorizontal = new pivyLab.Control.Separator();
            this.searchIcon = new System.Windows.Forms.PictureBox();
            this.searchText = new System.Windows.Forms.TextBox();
            this.logoSeparatorVertical = new pivyLab.Animation.GradientPanel();
            this.searchTextBreak = new System.Windows.Forms.PictureBox();
            this.emailText = new System.Windows.Forms.Label();
            this.emailIcon = new System.Windows.Forms.PictureBox();
            this.leftSideSeparator1 = new pivyLab.Control.Separator();
            this.leftSideLogoLabel = new System.Windows.Forms.Label();
            this.createSafeIcon = new System.Windows.Forms.PictureBox();
            this.safeList = new System.Windows.Forms.Panel();
            this.hideSafeListIcon = new System.Windows.Forms.PictureBox();
            this.leftSideSeparator2 = new pivyLab.Control.Separator();
            this.createSafeButton = new System.Windows.Forms.Panel();
            this.createSafeButtonLabel = new System.Windows.Forms.Label();
            this.createSafeButtonIcon = new System.Windows.Forms.PictureBox();
            this.safeItemView = new System.Windows.Forms.Panel();
            this.safeItemView_Field6 = new System.Windows.Forms.Label();
            this.safeItemView_Field5 = new System.Windows.Forms.Label();
            this.safeItemView_Field4 = new System.Windows.Forms.Label();
            this.safeItemView_Field3 = new System.Windows.Forms.Label();
            this.safeItemView_Field2 = new System.Windows.Forms.Label();
            this.safeItemView_MembersCount = new System.Windows.Forms.Label();
            this.safeItemView_Field1 = new System.Windows.Forms.Label();
            this.safeItemView_ItemPanel = new System.Windows.Forms.Panel();
            this.safeItemView_Hide = new System.Windows.Forms.PictureBox();
            this.safeItemView_Act = new System.Windows.Forms.PictureBox();
            this.safeItemView_Members = new System.Windows.Forms.PictureBox();
            this.safeItemView_AddFolder = new System.Windows.Forms.PictureBox();
            this.safeItemView_MenuSeparator = new pivyLab.Control.Separator();
            this.safeItemView_SafeCreatorPerson = new System.Windows.Forms.Label();
            this.safeItemView_SafeCreator = new System.Windows.Forms.Label();
            this.safeItemView_AddItem = new pivyLab.Control.FlatEllButton();
            this.safeItemView_SafeName = new System.Windows.Forms.Label();
            this.registration = new Mercury.Registration();
            this.login = new Mercury.CustomControls.Login();
            this.startPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBreak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.createSafeIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hideSafeListIcon)).BeginInit();
            this.createSafeButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createSafeButtonIcon)).BeginInit();
            this.safeItemView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_Hide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_Act)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_Members)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_AddFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // startPanel
            // 
            this.startPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startPanel.Controls.Add(this.registration);
            this.startPanel.Controls.Add(this.login);
            this.startPanel.Controls.Add(this.textLogo);
            this.startPanel.Controls.Add(this.loginButton);
            this.startPanel.Controls.Add(this.registrationButton);
            this.startPanel.Controls.Add(this.separator1);
            this.startPanel.Location = new System.Drawing.Point(1191, 25);
            this.startPanel.Name = "startPanel";
            this.startPanel.Size = new System.Drawing.Size(1192, 703);
            this.startPanel.TabIndex = 3;
            this.startPanel.Visible = false;
            // 
            // textLogo
            // 
            this.textLogo.AutoSize = true;
            this.textLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogo.ForeColor = System.Drawing.Color.White;
            this.textLogo.Location = new System.Drawing.Point(38, 9);
            this.textLogo.Name = "textLogo";
            this.textLogo.Size = new System.Drawing.Size(231, 64);
            this.textLogo.TabIndex = 5;
            this.textLogo.Text = "Mercury";
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.AutoSize = true;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(891, 21);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(50, 18);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Войти";
            this.loginButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // registrationButton
            // 
            this.registrationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationButton.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.registrationButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registrationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.registrationButton.ForeColor = System.Drawing.Color.White;
            this.registrationButton.Location = new System.Drawing.Point(976, 12);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.RoundRadius = 2;
            this.registrationButton.Size = new System.Drawing.Size(154, 36);
            this.registrationButton.TabIndex = 2;
            this.registrationButton.Text = "Регистрация";
            this.registrationButton.UseVisualStyleBackColor = true;
            // 
            // separator1
            // 
            this.separator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.separator1.Location = new System.Drawing.Point(0, 55);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(1122, 1);
            this.separator1.TabIndex = 1;
            // 
            // textLogoMain
            // 
            this.textLogoMain.AutoSize = true;
            this.textLogoMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textLogoMain.ForeColor = System.Drawing.Color.White;
            this.textLogoMain.Location = new System.Drawing.Point(39, 25);
            this.textLogoMain.Name = "textLogoMain";
            this.textLogoMain.Size = new System.Drawing.Size(147, 40);
            this.textLogoMain.TabIndex = 7;
            this.textLogoMain.Text = "Mercury";
            this.textLogoMain.Visible = false;
            // 
            // logoSeparatorHorizontal
            // 
            this.logoSeparatorHorizontal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.logoSeparatorHorizontal.Location = new System.Drawing.Point(0, 87);
            this.logoSeparatorHorizontal.Name = "logoSeparatorHorizontal";
            this.logoSeparatorHorizontal.Size = new System.Drawing.Size(1122, 1);
            this.logoSeparatorHorizontal.TabIndex = 6;
            this.logoSeparatorHorizontal.Visible = false;
            // 
            // searchIcon
            // 
            this.searchIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.searchIcon.Image = global::Mercury.Properties.Resources.searchIconGreen;
            this.searchIcon.Location = new System.Drawing.Point(359, 45);
            this.searchIcon.Name = "searchIcon";
            this.searchIcon.Size = new System.Drawing.Size(30, 24);
            this.searchIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchIcon.TabIndex = 10;
            this.searchIcon.TabStop = false;
            // 
            // searchText
            // 
            this.searchText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.searchText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.searchText.Location = new System.Drawing.Point(399, 48);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(260, 17);
            this.searchText.TabIndex = 11;
            // 
            // logoSeparatorVertical
            // 
            this.logoSeparatorVertical.ColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.logoSeparatorVertical.ColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.logoSeparatorVertical.Location = new System.Drawing.Point(234, 88);
            this.logoSeparatorVertical.Name = "logoSeparatorVertical";
            this.logoSeparatorVertical.Size = new System.Drawing.Size(1, 648);
            this.logoSeparatorVertical.TabIndex = 12;
            // 
            // searchTextBreak
            // 
            this.searchTextBreak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.searchTextBreak.Image = global::Mercury.Properties.Resources.searchTextBreak;
            this.searchTextBreak.Location = new System.Drawing.Point(686, 48);
            this.searchTextBreak.Name = "searchTextBreak";
            this.searchTextBreak.Size = new System.Drawing.Size(18, 18);
            this.searchTextBreak.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.searchTextBreak.TabIndex = 13;
            this.searchTextBreak.TabStop = false;
            this.searchTextBreak.Visible = false;
            // 
            // emailText
            // 
            this.emailText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailText.AutoSize = true;
            this.emailText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.emailText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.emailText.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.emailText.Location = new System.Drawing.Point(1046, 48);
            this.emailText.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.emailText.Name = "emailText";
            this.emailText.Size = new System.Drawing.Size(45, 18);
            this.emailText.TabIndex = 14;
            this.emailText.Text = "Email";
            this.emailText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // emailIcon
            // 
            this.emailIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.emailIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.emailIcon.Image = global::Mercury.Properties.Resources.emailIconGrayDown;
            this.emailIcon.Location = new System.Drawing.Point(1101, 50);
            this.emailIcon.Name = "emailIcon";
            this.emailIcon.Size = new System.Drawing.Size(16, 16);
            this.emailIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.emailIcon.TabIndex = 15;
            this.emailIcon.TabStop = false;
            // 
            // leftSideSeparator1
            // 
            this.leftSideSeparator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.leftSideSeparator1.Location = new System.Drawing.Point(46, 152);
            this.leftSideSeparator1.Name = "leftSideSeparator1";
            this.leftSideSeparator1.Size = new System.Drawing.Size(170, 1);
            this.leftSideSeparator1.TabIndex = 16;
            // 
            // leftSideLogoLabel
            // 
            this.leftSideLogoLabel.AutoSize = true;
            this.leftSideLogoLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.leftSideLogoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.leftSideLogoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.leftSideLogoLabel.Location = new System.Drawing.Point(43, 129);
            this.leftSideLogoLabel.Name = "leftSideLogoLabel";
            this.leftSideLogoLabel.Size = new System.Drawing.Size(53, 16);
            this.leftSideLogoLabel.TabIndex = 17;
            this.leftSideLogoLabel.Text = "Сейфы";
            // 
            // createSafeIcon
            // 
            this.createSafeIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createSafeIcon.Image = global::Mercury.Properties.Resources.iconPlusGray;
            this.createSafeIcon.Location = new System.Drawing.Point(192, 124);
            this.createSafeIcon.Name = "createSafeIcon";
            this.createSafeIcon.Size = new System.Drawing.Size(24, 24);
            this.createSafeIcon.TabIndex = 18;
            this.createSafeIcon.TabStop = false;
            // 
            // safeList
            // 
            this.safeList.AutoScroll = true;
            this.safeList.Location = new System.Drawing.Point(46, 170);
            this.safeList.Name = "safeList";
            this.safeList.Size = new System.Drawing.Size(170, 486);
            this.safeList.TabIndex = 19;
            // 
            // hideSafeListIcon
            // 
            this.hideSafeListIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.hideSafeListIcon.Image = global::Mercury.Properties.Resources.hideSafeListIconGrayDown;
            this.hideSafeListIcon.Location = new System.Drawing.Point(23, 125);
            this.hideSafeListIcon.Name = "hideSafeListIcon";
            this.hideSafeListIcon.Size = new System.Drawing.Size(22, 22);
            this.hideSafeListIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hideSafeListIcon.TabIndex = 20;
            this.hideSafeListIcon.TabStop = false;
            // 
            // leftSideSeparator2
            // 
            this.leftSideSeparator2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.leftSideSeparator2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.leftSideSeparator2.Location = new System.Drawing.Point(0, 674);
            this.leftSideSeparator2.Name = "leftSideSeparator2";
            this.leftSideSeparator2.Size = new System.Drawing.Size(234, 1);
            this.leftSideSeparator2.TabIndex = 21;
            // 
            // createSafeButton
            // 
            this.createSafeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createSafeButton.Controls.Add(this.createSafeButtonLabel);
            this.createSafeButton.Controls.Add(this.createSafeButtonIcon);
            this.createSafeButton.Location = new System.Drawing.Point(3, 679);
            this.createSafeButton.Name = "createSafeButton";
            this.createSafeButton.Size = new System.Drawing.Size(228, 55);
            this.createSafeButton.TabIndex = 22;
            // 
            // createSafeButtonLabel
            // 
            this.createSafeButtonLabel.AutoSize = true;
            this.createSafeButtonLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.createSafeButtonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createSafeButtonLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.createSafeButtonLabel.Location = new System.Drawing.Point(69, 19);
            this.createSafeButtonLabel.Name = "createSafeButtonLabel";
            this.createSafeButtonLabel.Size = new System.Drawing.Size(90, 16);
            this.createSafeButtonLabel.TabIndex = 18;
            this.createSafeButtonLabel.Text = "Новый Сейф";
            // 
            // createSafeButtonIcon
            // 
            this.createSafeButtonIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.createSafeButtonIcon.Image = global::Mercury.Properties.Resources.iconPlusGray;
            this.createSafeButtonIcon.Location = new System.Drawing.Point(43, 14);
            this.createSafeButtonIcon.Name = "createSafeButtonIcon";
            this.createSafeButtonIcon.Size = new System.Drawing.Size(24, 24);
            this.createSafeButtonIcon.TabIndex = 18;
            this.createSafeButtonIcon.TabStop = false;
            // 
            // safeItemView
            // 
            this.safeItemView.Controls.Add(this.safeItemView_Field6);
            this.safeItemView.Controls.Add(this.safeItemView_Field5);
            this.safeItemView.Controls.Add(this.safeItemView_Field4);
            this.safeItemView.Controls.Add(this.safeItemView_Field3);
            this.safeItemView.Controls.Add(this.safeItemView_Field2);
            this.safeItemView.Controls.Add(this.safeItemView_MembersCount);
            this.safeItemView.Controls.Add(this.safeItemView_Field1);
            this.safeItemView.Controls.Add(this.safeItemView_ItemPanel);
            this.safeItemView.Controls.Add(this.safeItemView_Hide);
            this.safeItemView.Controls.Add(this.safeItemView_Act);
            this.safeItemView.Controls.Add(this.safeItemView_Members);
            this.safeItemView.Controls.Add(this.safeItemView_AddFolder);
            this.safeItemView.Controls.Add(this.safeItemView_MenuSeparator);
            this.safeItemView.Controls.Add(this.safeItemView_SafeCreatorPerson);
            this.safeItemView.Controls.Add(this.safeItemView_SafeCreator);
            this.safeItemView.Controls.Add(this.safeItemView_AddItem);
            this.safeItemView.Controls.Add(this.safeItemView_SafeName);
            this.safeItemView.Location = new System.Drawing.Point(255, 107);
            this.safeItemView.Name = "safeItemView";
            this.safeItemView.Size = new System.Drawing.Size(930, 616);
            this.safeItemView.TabIndex = 23;
            this.safeItemView.Visible = false;
            // 
            // safeItemView_Field6
            // 
            this.safeItemView_Field6.AutoSize = true;
            this.safeItemView_Field6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_Field6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_Field6.Location = new System.Drawing.Point(724, 150);
            this.safeItemView_Field6.Name = "safeItemView_Field6";
            this.safeItemView_Field6.Size = new System.Drawing.Size(40, 16);
            this.safeItemView_Field6.TabIndex = 21;
            this.safeItemView_Field6.Text = "поле";
            this.safeItemView_Field6.Visible = false;
            // 
            // safeItemView_Field5
            // 
            this.safeItemView_Field5.AutoSize = true;
            this.safeItemView_Field5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_Field5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_Field5.Location = new System.Drawing.Point(584, 150);
            this.safeItemView_Field5.Name = "safeItemView_Field5";
            this.safeItemView_Field5.Size = new System.Drawing.Size(40, 16);
            this.safeItemView_Field5.TabIndex = 21;
            this.safeItemView_Field5.Text = "поле";
            this.safeItemView_Field5.Visible = false;
            // 
            // safeItemView_Field4
            // 
            this.safeItemView_Field4.AutoSize = true;
            this.safeItemView_Field4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_Field4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_Field4.Location = new System.Drawing.Point(454, 150);
            this.safeItemView_Field4.Name = "safeItemView_Field4";
            this.safeItemView_Field4.Size = new System.Drawing.Size(40, 16);
            this.safeItemView_Field4.TabIndex = 21;
            this.safeItemView_Field4.Text = "поле";
            this.safeItemView_Field4.Visible = false;
            // 
            // safeItemView_Field3
            // 
            this.safeItemView_Field3.AutoSize = true;
            this.safeItemView_Field3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_Field3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_Field3.Location = new System.Drawing.Point(325, 150);
            this.safeItemView_Field3.Name = "safeItemView_Field3";
            this.safeItemView_Field3.Size = new System.Drawing.Size(40, 16);
            this.safeItemView_Field3.TabIndex = 21;
            this.safeItemView_Field3.Text = "поле";
            this.safeItemView_Field3.Visible = false;
            // 
            // safeItemView_Field2
            // 
            this.safeItemView_Field2.AutoSize = true;
            this.safeItemView_Field2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_Field2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_Field2.Location = new System.Drawing.Point(211, 150);
            this.safeItemView_Field2.Name = "safeItemView_Field2";
            this.safeItemView_Field2.Size = new System.Drawing.Size(40, 16);
            this.safeItemView_Field2.TabIndex = 21;
            this.safeItemView_Field2.Text = "поле";
            this.safeItemView_Field2.Visible = false;
            // 
            // safeItemView_MembersCount
            // 
            this.safeItemView_MembersCount.AutoSize = true;
            this.safeItemView_MembersCount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeItemView_MembersCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_MembersCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_MembersCount.Location = new System.Drawing.Point(136, 102);
            this.safeItemView_MembersCount.Name = "safeItemView_MembersCount";
            this.safeItemView_MembersCount.Size = new System.Drawing.Size(90, 18);
            this.safeItemView_MembersCount.TabIndex = 21;
            this.safeItemView_MembersCount.Text = "количество";
            // 
            // safeItemView_Field1
            // 
            this.safeItemView_Field1.AutoSize = true;
            this.safeItemView_Field1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_Field1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(97)))), ((int)(((byte)(97)))), ((int)(((byte)(97)))));
            this.safeItemView_Field1.Location = new System.Drawing.Point(93, 150);
            this.safeItemView_Field1.Name = "safeItemView_Field1";
            this.safeItemView_Field1.Size = new System.Drawing.Size(40, 16);
            this.safeItemView_Field1.TabIndex = 21;
            this.safeItemView_Field1.Text = "поле";
            this.safeItemView_Field1.Visible = false;
            // 
            // safeItemView_ItemPanel
            // 
            this.safeItemView_ItemPanel.AutoScroll = true;
            this.safeItemView_ItemPanel.Location = new System.Drawing.Point(51, 178);
            this.safeItemView_ItemPanel.Name = "safeItemView_ItemPanel";
            this.safeItemView_ItemPanel.Size = new System.Drawing.Size(819, 418);
            this.safeItemView_ItemPanel.TabIndex = 20;
            // 
            // safeItemView_Hide
            // 
            this.safeItemView_Hide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.safeItemView_Hide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeItemView_Hide.Image = global::Mercury.Properties.Resources.closePanelViewGray;
            this.safeItemView_Hide.Location = new System.Drawing.Point(903, 3);
            this.safeItemView_Hide.Name = "safeItemView_Hide";
            this.safeItemView_Hide.Size = new System.Drawing.Size(24, 24);
            this.safeItemView_Hide.TabIndex = 19;
            this.safeItemView_Hide.TabStop = false;
            // 
            // safeItemView_Act
            // 
            this.safeItemView_Act.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.safeItemView_Act.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeItemView_Act.Image = global::Mercury.Properties.Resources.actGray;
            this.safeItemView_Act.Location = new System.Drawing.Point(846, 97);
            this.safeItemView_Act.Name = "safeItemView_Act";
            this.safeItemView_Act.Size = new System.Drawing.Size(24, 24);
            this.safeItemView_Act.TabIndex = 19;
            this.safeItemView_Act.TabStop = false;
            // 
            // safeItemView_Members
            // 
            this.safeItemView_Members.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeItemView_Members.Image = global::Mercury.Properties.Resources.membersGray;
            this.safeItemView_Members.Location = new System.Drawing.Point(110, 99);
            this.safeItemView_Members.Name = "safeItemView_Members";
            this.safeItemView_Members.Size = new System.Drawing.Size(24, 24);
            this.safeItemView_Members.TabIndex = 19;
            this.safeItemView_Members.TabStop = false;
            // 
            // safeItemView_AddFolder
            // 
            this.safeItemView_AddFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeItemView_AddFolder.Image = global::Mercury.Properties.Resources.addFolderGray;
            this.safeItemView_AddFolder.Location = new System.Drawing.Point(51, 97);
            this.safeItemView_AddFolder.Name = "safeItemView_AddFolder";
            this.safeItemView_AddFolder.Size = new System.Drawing.Size(24, 24);
            this.safeItemView_AddFolder.TabIndex = 19;
            this.safeItemView_AddFolder.TabStop = false;
            // 
            // safeItemView_MenuSeparator
            // 
            this.safeItemView_MenuSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.safeItemView_MenuSeparator.Location = new System.Drawing.Point(51, 131);
            this.safeItemView_MenuSeparator.Name = "safeItemView_MenuSeparator";
            this.safeItemView_MenuSeparator.Size = new System.Drawing.Size(817, 1);
            this.safeItemView_MenuSeparator.TabIndex = 3;
            // 
            // safeItemView_SafeCreatorPerson
            // 
            this.safeItemView_SafeCreatorPerson.AutoSize = true;
            this.safeItemView_SafeCreatorPerson.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_SafeCreatorPerson.ForeColor = System.Drawing.Color.White;
            this.safeItemView_SafeCreatorPerson.Location = new System.Drawing.Point(129, 50);
            this.safeItemView_SafeCreatorPerson.Name = "safeItemView_SafeCreatorPerson";
            this.safeItemView_SafeCreatorPerson.Size = new System.Drawing.Size(77, 16);
            this.safeItemView_SafeCreatorPerson.TabIndex = 2;
            this.safeItemView_SafeCreatorPerson.Text = "создатель";
            // 
            // safeItemView_SafeCreator
            // 
            this.safeItemView_SafeCreator.AutoSize = true;
            this.safeItemView_SafeCreator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_SafeCreator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.safeItemView_SafeCreator.Location = new System.Drawing.Point(48, 50);
            this.safeItemView_SafeCreator.Name = "safeItemView_SafeCreator";
            this.safeItemView_SafeCreator.Size = new System.Drawing.Size(85, 16);
            this.safeItemView_SafeCreator.TabIndex = 2;
            this.safeItemView_SafeCreator.Text = "Создатель: ";
            // 
            // safeItemView_AddItem
            // 
            this.safeItemView_AddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.safeItemView_AddItem.Back = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(185)))), ((int)(((byte)(84)))));
            this.safeItemView_AddItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.safeItemView_AddItem.ForeColor = System.Drawing.Color.White;
            this.safeItemView_AddItem.Location = new System.Drawing.Point(721, 25);
            this.safeItemView_AddItem.Name = "safeItemView_AddItem";
            this.safeItemView_AddItem.RoundRadius = 2;
            this.safeItemView_AddItem.Size = new System.Drawing.Size(147, 34);
            this.safeItemView_AddItem.TabIndex = 1;
            this.safeItemView_AddItem.Text = "Добавить";
            this.safeItemView_AddItem.UseVisualStyleBackColor = true;
            // 
            // safeItemView_SafeName
            // 
            this.safeItemView_SafeName.AutoSize = true;
            this.safeItemView_SafeName.BackColor = System.Drawing.Color.Transparent;
            this.safeItemView_SafeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.safeItemView_SafeName.ForeColor = System.Drawing.Color.White;
            this.safeItemView_SafeName.Location = new System.Drawing.Point(46, 25);
            this.safeItemView_SafeName.Name = "safeItemView_SafeName";
            this.safeItemView_SafeName.Size = new System.Drawing.Size(231, 25);
            this.safeItemView_SafeName.TabIndex = 0;
            this.safeItemView_SafeName.Text = "Наименование сейфа";
            // 
            // registration
            // 
            this.registration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.registration.Location = new System.Drawing.Point(34, 58);
            this.registration.Name = "registration";
            this.registration.Size = new System.Drawing.Size(1120, 636);
            this.registration.TabIndex = 7;
            this.registration.Visible = false;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.login.Location = new System.Drawing.Point(34, 58);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(1120, 636);
            this.login.TabIndex = 6;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1194, 738);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.textLogoMain);
            this.Controls.Add(this.logoSeparatorHorizontal);
            this.Controls.Add(this.searchIcon);
            this.Controls.Add(this.searchText);
            this.Controls.Add(this.logoSeparatorVertical);
            this.Controls.Add(this.searchTextBreak);
            this.Controls.Add(this.emailText);
            this.Controls.Add(this.emailIcon);
            this.Controls.Add(this.leftSideLogoLabel);
            this.Controls.Add(this.leftSideSeparator1);
            this.Controls.Add(this.createSafeIcon);
            this.Controls.Add(this.leftSideSeparator2);
            this.Controls.Add(this.hideSafeListIcon);
            this.Controls.Add(this.safeList);
            this.Controls.Add(this.createSafeButton);
            this.Controls.Add(this.safeItemView);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Controls.SetChildIndex(this.safeItemView, 0);
            this.Controls.SetChildIndex(this.createSafeButton, 0);
            this.Controls.SetChildIndex(this.safeList, 0);
            this.Controls.SetChildIndex(this.hideSafeListIcon, 0);
            this.Controls.SetChildIndex(this.leftSideSeparator2, 0);
            this.Controls.SetChildIndex(this.createSafeIcon, 0);
            this.Controls.SetChildIndex(this.leftSideSeparator1, 0);
            this.Controls.SetChildIndex(this.leftSideLogoLabel, 0);
            this.Controls.SetChildIndex(this.emailIcon, 0);
            this.Controls.SetChildIndex(this.emailText, 0);
            this.Controls.SetChildIndex(this.searchTextBreak, 0);
            this.Controls.SetChildIndex(this.logoSeparatorVertical, 0);
            this.Controls.SetChildIndex(this.searchText, 0);
            this.Controls.SetChildIndex(this.searchIcon, 0);
            this.Controls.SetChildIndex(this.logoSeparatorHorizontal, 0);
            this.Controls.SetChildIndex(this.textLogoMain, 0);
            this.Controls.SetChildIndex(this.startPanel, 0);
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchTextBreak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.createSafeIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hideSafeListIcon)).EndInit();
            this.createSafeButton.ResumeLayout(false);
            this.createSafeButton.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.createSafeButtonIcon)).EndInit();
            this.safeItemView.ResumeLayout(false);
            this.safeItemView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_Hide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_Act)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_Members)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.safeItemView_AddFolder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel startPanel;
        private pivyLab.Control.Separator separator1;
        private pivyLab.Control.FlatEllButton registrationButton;
        private System.Windows.Forms.Label loginButton;
        private System.Windows.Forms.Label textLogo;
        private System.Windows.Forms.Label textLogoMain;
        private pivyLab.Control.Separator logoSeparatorHorizontal;
        private System.Windows.Forms.PictureBox searchIcon;
        private System.Windows.Forms.TextBox searchText;
        private pivyLab.Animation.GradientPanel logoSeparatorVertical;
        private System.Windows.Forms.PictureBox searchTextBreak;
        private System.Windows.Forms.Label emailText;
        private System.Windows.Forms.PictureBox emailIcon;
        private pivyLab.Control.Separator leftSideSeparator1;
        private System.Windows.Forms.Label leftSideLogoLabel;
        private System.Windows.Forms.PictureBox createSafeIcon;
        private System.Windows.Forms.PictureBox hideSafeListIcon;
        private pivyLab.Control.Separator leftSideSeparator2;
        private System.Windows.Forms.Panel createSafeButton;
        private System.Windows.Forms.Label createSafeButtonLabel;
        private System.Windows.Forms.PictureBox createSafeButtonIcon;
        public System.Windows.Forms.Panel safeList;
        private System.Windows.Forms.Panel safeItemView;
        private System.Windows.Forms.Label safeItemView_SafeName;
        private pivyLab.Control.FlatEllButton safeItemView_AddItem;
        private System.Windows.Forms.Label safeItemView_SafeCreator;
        private pivyLab.Control.Separator safeItemView_MenuSeparator;
        private System.Windows.Forms.PictureBox safeItemView_Act;
        private System.Windows.Forms.PictureBox safeItemView_AddFolder;
        private System.Windows.Forms.Label safeItemView_SafeCreatorPerson;
        private System.Windows.Forms.Panel safeItemView_ItemPanel;
        private CustomControls.Login login;
        private Registration registration;
        private System.Windows.Forms.Label safeItemView_Field6;
        private System.Windows.Forms.Label safeItemView_Field5;
        private System.Windows.Forms.Label safeItemView_Field4;
        private System.Windows.Forms.Label safeItemView_Field3;
        private System.Windows.Forms.Label safeItemView_Field2;
        private System.Windows.Forms.Label safeItemView_Field1;
        private System.Windows.Forms.PictureBox safeItemView_Hide;
        private System.Windows.Forms.PictureBox safeItemView_Members;
        private System.Windows.Forms.Label safeItemView_MembersCount;
    }
}

