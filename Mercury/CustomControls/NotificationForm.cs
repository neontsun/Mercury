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
    public partial class NotificationForm : Form
    {
        #region Настройка теней у формы


        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        private bool m_aeroEnabled;
        private const int CS_DROPSHADOW = 0x00060000;
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

        #region Хуки

        // Создаем коллекцию
        PrivateFontCollection pr = new PrivateFontCollection();

        #endregion

        #region Списки

        public List<Notification> list = new List<Notification>();

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Использует шрифт из файла.
        /// </summary>
        private void UseFonts()
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
            pr.AddFontFile(Properties.Settings.Default.PathForFonts + "CircularStd-Black.otf");

            FontFamily[] fontFamilies = pr.Families;

            // Поле email'a
            //deleteSafe.Font = new Font(fontFamilies[3], 11);
        }

        /// <summary>
        /// Возвращает шрифт для уведомлений
        /// </summary>
        private Font GetFontForNotification() => new Font(pr.Families[3], 9);

        /// <summary>
        /// Возвращает количество уведомлений
        /// </summary>
        /// <returns></returns>
        private int GetNotificationCount() => this.Controls.Count - 2;

        /// <summary>
        ///  Получаем числовой показателя для следующего лейбла / Объекта сейфа
        /// </summary>
        private int GetLocationForNotification()
        {
            // Если количество элементов в списке контролов
            // равно нулю, то возвращаем позицию первого контрола
            if (this.Controls.Count == 0)
                return 10;
            // Иначе возвращаем позицию в результате расчета
            // позиции последнего контрола в списке
            else
                return this.Controls[this.Controls.Count - 1].Location.Y + 130;
        }

        #endregion


        /// <summary>
        /// Конструктор
        /// </summary>
        public NotificationForm()
        {
            InitializeComponent();

            // Риссуем форму
            FormStyleTwo.PaintForm(this);

            UseFonts();

            this.Activated += (f, a) => LoadNotification();
        }

        
        #region Методы

        /// <summary>
        /// Строит уведомления
        /// </summary>
        public void LoadNotification()
        {
            this.list = (this.Owner as Main).notificationCollection;

            this.Controls.Clear();

            foreach (var item in list)
            {
                var control = NewNotification.CreateNewNotification(this, GetNotificationCount(),
                        GetFontForNotification(), item, GetLocationForNotification());

                this.Controls.Add(control);
            }
            UpdateNotificationCount();
        }

        /// <summary>
        /// Обновляет количество уведомлений
        /// </summary>
        public void RemoveFromMainNotificationList(Notification nf)
        {
            (this.Owner as Main).notificationCollection.Remove(nf);
        }

        /// <summary>
        /// Обновляет количество уведомлений
        /// </summary>
        public void UpdateNotificationCount()
        {
            if (DateBase.GetNotificationCount(DateBase.GetUserID(Properties.Settings.Default.userEmail)) != 0)
                (this.Owner as Main).WriteNotification();
            else
                (this.Owner as Main).HideNotificationCount();
        }

        /// <summary>
        /// Заполняет список сейфов
        /// </summary>
        public void ReloadSafeList() => (this.Owner as Main).FillSafeList();

        #endregion
    }
}
