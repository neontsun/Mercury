using Mercury.WorkingScripts;
using pivyLab.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercury.CustomControls
{
    public partial class InviteForm : Form
    {
        #region Натройка теней у формы


        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00030000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
        [System.Runtime.InteropServices.DllImport("dwmapi.dll")]

        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            Int32 nLeftRect, Int32 nTopRect, Int32 nRightRect, Int32 nBottomRect, Int32 nWidthEllipse, Int32 nHeightEllipse);

        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();
                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 0,
                            leftWidth = 0,
                            rightWidth = 0,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);
                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }


        #endregion

        #region Хуки и глобальные переменные

        // Создаем коллекцию шрифтов
        PrivateFontCollection pr = new PrivateFontCollection();

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Показывает сообщение с ошибкой.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void ShowError(string message)
        {
            // Показываем форму ошибку
            ErrorForm error = new ErrorForm(message);

            error.Location = new Point((this.Owner as Main).Location.X + ((this.Owner as Main).Width / 2 - error.Width / 2),
                (this.Owner as Main).Location.Y + ((this.Owner as Main).Height / 2 - error.Height / 2));

            error.ShowDialog();
        }

        /// <summary>
        /// Использует шрифт из файла
        /// </summary>
        public void UseFonts()
        {
            // Сохраняем путь к папке со шрифтами
            Properties.Settings.Default.PathForFonts = Directory.GetCurrentDirectory()
                .Remove(Directory.GetCurrentDirectory().Length - 10) + "\\Fonts\\";
            Properties.Settings.Default.Save();

            // Добавляем шрифты в коллекцию
            pr.AddFontFile(Properties.Settings.Default.PathForFonts + "MuseoSansCyrl-300.ttf");
            pr.AddFontFile(Properties.Settings.Default.PathForFonts + "MuseoSansCyrl-500.ttf");
            pr.AddFontFile(Properties.Settings.Default.PathForFonts + "MuseoSansCyrl-700.ttf");
            pr.AddFontFile(Properties.Settings.Default.PathForFonts + "MuseoSansCyrl-900.ttf");

            FontFamily[] fontFamilies = pr.Families;

            // Надпись "Авторизироваться"
            logoLabel.Font = new Font(fontFamilies[1], 20);

            // Кнопки сохранить и отмена
            invite.Font = new Font(fontFamilies[1], 11);
            cancel.Font = new Font(fontFamilies[1], 11);

            Email.Font = new Font(fontFamilies[1], 11);
        }

        #endregion

        public InviteForm()
        {
            InitializeComponent();

            // Подключаем шрифты
            UseFonts();

            // Риссуем форму
            FormStyleTwo.PaintForm(this);

            // Ставим плейсхолдер для имени сейфа
            Animation.Placeholder.addPlaceholder(Email, "Введите Email", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));

            invite.MouseEnter += (f, a) =>
            {
                invite.Back = Color.FromArgb(30, 215, 96);
            };
            invite.MouseLeave += (f, a) =>
            {
                invite.Back = Color.FromArgb(29, 185, 84);
            };
            invite.MouseDown += (f, a) =>
            {
                invite.Back = Color.FromArgb(20, 131, 59);
            };
            invite.MouseUp += (f, a) =>
            {
                invite.Back = Color.FromArgb(29, 185, 84);
            };

            cancel.MouseEnter += (f, a) =>
            {
                cancel.Back = Color.FromArgb(30, 215, 96);
            };
            cancel.MouseLeave += (f, a) =>
            {
                cancel.Back = Color.FromArgb(29, 185, 84);
            };
            cancel.MouseDown += (f, a) =>
            {
                cancel.Back = Color.FromArgb(20, 131, 59);
            };
            cancel.MouseUp += (f, a) =>
            {
                cancel.Back = Color.FromArgb(29, 185, 84);
            };

            cancel.Click += (f, a) => 
            {

                (this.Owner as Main).safeMenuIsOpen = false;
                (this.Owner as Main).countOpenSafeMenu = 0;
                (this.Owner as Main).CloseSafeMenu();
                this.Close();
            };
            invite.Click += (f, a) => this.InviteInSafe((this.Owner as Main).activeSafe);
        }


        /// <summary>
        /// Приглашает в сейф
        /// </summary>
        private void InviteInSafe(Safe safe)
        {
            if (Email.Text == "Введите Email" || Email.Text == string.Empty)
                ShowError("Поле Email'a не может быть пустым");
            else
            {
                if (!DateBase.ExistenceCheck("User", "Email", Email.Text))
                    ShowError("Такого аккаунта не существует");
                else
                {
                    if (DateBase.CheckData("Notification", new string[] { "User_ID", "Safe_ID" }, 
                        new string[] { DateBase.GetUserID(Email.Text).ToString(), safe.SafeID.ToString() }))
                    {
                        ShowError("Приглашение уже отправлено");
                    }
                    else
                    {
                        if (DateBase.CheckUserSafeValid(DateBase.GetUserID(Email.Text), safe.SafeID))
                            ShowError("Пользователь уже находится в сейфе");
                        else
                        {
                            DateBase.InviteInSafe(DateBase.GetUserID(Email.Text), safe.SafeID);
                            ShowError("Приглашение отправлено");
                            (this.Owner as Main).safeMenuIsOpen = false;
                            (this.Owner as Main).countOpenSafeMenu = 0;
                            (this.Owner as Main).CloseSafeMenu();
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
