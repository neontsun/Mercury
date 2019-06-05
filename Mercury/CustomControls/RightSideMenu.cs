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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Mercury.CustomControls
{
    public partial class RightSideMenu : Form
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
                    cp.ClassStyle |= CS_DROPSHADOW; return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0; DwmIsCompositionEnabled(ref enabled);
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
                default: break;
            }
            base.WndProc(ref m);
        }


        #endregion

        #region Хуки

        // Создаем коллекцию
        PrivateFontCollection pr = new PrivateFontCollection();

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
            exit.Font = new Font(fontFamilies[3], 11);
            settings.Font = new Font(fontFamilies[3], 11);
        }

        #endregion

        
        public RightSideMenu()
        {
            InitializeComponent();

            this.Focus();

            // Подключаем шрифты
            UseFonts();

            // Риссуем форму
            FormStyleTwo.PaintForm(this);

            // Событие при наведении на кнопку выйти
            exit.MouseEnter += (f, a) => 
            {
                exit.ForeColor = Color.FromArgb(29, 185, 84);
            };
            exit.MouseLeave += (f, a) =>
            {
                exit.ForeColor = Color.FromArgb(120, 120, 120);
            };
            exit.MouseDown += (f, a) => 
            {
                exit.ForeColor = Color.FromArgb(70, 70, 70);
            };
            exit.MouseUp += (f, a) =>
            {
                exit.ForeColor = Color.FromArgb(29, 185, 84);
            };

            // Событие при наведении на кнопку настройки
            settings.MouseEnter += (f, a) =>
            {
                settings.ForeColor = Color.FromArgb(29, 185, 84);
            };
            settings.MouseLeave += (f, a) =>
            {
                settings.ForeColor = Color.FromArgb(120, 120, 120);
            };
            settings.MouseDown += (f, a) =>
            {
                settings.ForeColor = Color.FromArgb(70, 70, 70);
            };
            settings.MouseUp += (f, a) =>
            {
                settings.ForeColor = Color.FromArgb(29, 185, 84);
            };
        }

        #region Методы
        
        // Клик по кнопке выйти
        private void exit_Click(object sender, EventArgs e)
        {
            // Выходим из аккаунта
            (this.Owner as Main).Logout();
            // Скрываем меню
            this.Hide();
        }

        // Клик по кнопке "настройки"
        private void settings_Click(object sender, EventArgs e)
        {
            new Settings().ShowDialog();
        }

        #endregion
    }
}
