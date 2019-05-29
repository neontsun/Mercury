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
    public partial class EditSafe : Form
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
            pr.AddFontFile(Properties.Settings.Default.PathForFonts + "CircularStd-Black.otf");

            FontFamily[] fontFamilies = pr.Families;

            // Надпись "Авторизироваться"
            logoLabel.Font = new Font(fontFamilies[3], 20);

            // Кнопки сохранить и отмена
            saveButton.Font = new Font(fontFamilies[2], 11);
            cancel.Font = new Font(fontFamilies[2], 11);

            // Название сейфа
            safeName.Font = new Font(fontFamilies[2], 12);

            // Поля
            fieldText1.Font = new Font(fontFamilies[2], 12);
            fieldText2.Font = new Font(fontFamilies[2], 12);
            fieldText3.Font = new Font(fontFamilies[2], 12);
            fieldText4.Font = new Font(fontFamilies[2], 12);
            fieldText5.Font = new Font(fontFamilies[2], 12);
            fieldText6.Font = new Font(fontFamilies[2], 12);
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


        /// <summary>
        /// Конструктор
        /// </summary>
        public EditSafe(Safe safe)
        {
            InitializeComponent();

            // Подключаем шрифты
            UseFonts();

            // Риссуем форму
            FormStyleTwo.PaintForm(this);

            // Событие при наведении на кнопки
            saveButton.MouseEnter += (f, a) =>
            {
                saveButton.Back = Color.FromArgb(30, 215, 96);
            };
            saveButton.MouseLeave += (f, a) =>
            {
                saveButton.Back = Color.FromArgb(29, 185, 84);
            };
            saveButton.MouseDown += (f, a) =>
            {
                saveButton.Back = Color.FromArgb(20, 131, 59);
            };
            saveButton.MouseUp += (f, a) =>
            {
                saveButton.Back = Color.FromArgb(29, 185, 84);
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

            cancel.Click += (f, a) => this.Close();
            saveButton.Click += (f, a) => UpdateData();

            this.Load += (f, a) => 
            {
                safeName.Text = safe.SafeName;

                for (int i = 1; i <= safe.Fields.Count; i++)
                {
                    this.Controls["fieldText" + i].Text = safe.Fields[i - 1];
                }
            };
        }

        /// <summary>
        /// Собирает данные и обновляет значение в БД
        /// </summary>
        private void UpdateData()
        {
            var fieldValue = new List<string>();
            var fieldValueFinish = new List<string>();
            var nameSafe = safeName.Text;

            if (safeName.Text == string.Empty)
                ShowError("Название сейфа не должно быть пустым!");
            else
            {
                nameSafe = safeName.Text;

                var res = 0;
                for (int i = 1; i <= 6; i++)
                {
                    if (this.Controls["fieldText" + i].Text == string.Empty)
                        res++;
                }

                if (res == 6)
                    ShowError("Хотя бы одно поле должно быть заполнено!");
                else
                {
                    for (int i = 1; i <= 6; i++)
                    {
                        fieldValue.Add(this.Controls["fieldText" + i].Text != string.Empty
                            ? this.Controls["fieldText" + i].Text : null);
                    }
                    // Сортируем данные
                    foreach (var item in fieldValue.Where(u => u != null))
                    {
                        fieldValueFinish.Add(item.ToString());
                    }
                    foreach (var item in fieldValue.Where(u => u == null))
                    {
                        fieldValueFinish.Add(item);
                    }
                    fieldValue.Clear();

                    // Обновляем данные в БД
                    DateBase.UpdateSafe((this.Owner as Main).activeSafe, fieldValueFinish, nameSafe);
                    // Обновляем данные в списке сейфов
                    foreach (var item in (this.Owner as Main).safeCollection.Where
                        (f => f.SafeID == (this.Owner as Main).activeSafe.SafeID))
                    {
                        (item as Safe).SafeName = nameSafe;
                        (item as Safe).Fields = fieldValueFinish;
                    }
                    // Обновляем данные в активном сейфе
                    (this.Owner as Main).activeSafe.SafeName = nameSafe;
                    (this.Owner as Main).activeSafe.Fields = fieldValueFinish;
                }
            }

            (this.Owner as Main).FillSafeList();
            (this.Owner as Main).FocusedSafe((this.Owner as Main).activeSafe);

            this.Close();
        }
    }
}
