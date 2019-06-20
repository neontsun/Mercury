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
    public partial class MembersInSafe : Form
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

        #region Списки

        List<Member> membersList = new List<Member>();

        #endregion

        #region Вспомогательные методы

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

            //// Надпись "Авторизироваться"
            listView1.Font = new Font(fontFamilies[1], 10);
            leave.Font = new Font(fontFamilies[1], 10);
        }

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

        #endregion


        public MembersInSafe()
        {
            InitializeComponent();

            // Подключаем шрифты
            UseFonts();

            // Риссуем форму
            FormStyleTwo.PaintForm(this);

            this.Activated += (f, a) => 
            {
                // Заполняем список участников
                membersList.Clear();
                listView1.Items.Clear();
                membersList = DateBase.GetListMembersInSafe((this.Owner as Main).activeSafe.SafeID);

                // Если пользователь не создатель сейфа
                if ((this.Owner as Main).activeSafe.Creator != Properties.Settings.Default.userEmail)
                {
                    leave.Visible = false;
                }

                foreach (var item in membersList)
                {
                    var list = new ListViewItem(item.MemberID.ToString());
                    list.SubItems.Add(item.Email);
                    list.ForeColor = Color.White;

                    listView1.Items.Add(list);
                }
            };
        }
    }
}
