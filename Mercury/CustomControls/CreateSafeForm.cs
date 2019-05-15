using pivyLab.Animation;
using pivyLab.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercury.WorkingScripts;

namespace Mercury.CustomControls
{
    public partial class CreateSafeForm : Form
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

        #region Хуки и глобальные переменные

        // Хук количества созданных полей
        int countAddsField = 0;
        // Наименование сейфа
        string NameSafe = string.Empty;
        // Массив полей
        string[] FieldsSafe = new string[6];
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
        /// Метод, создающий поля
        /// </summary>
        private void createField()
        {

            // Если введено название
            if (safeName.Text != "Название")
            {

                // Скрываем кнопки добавления поля
                addField.Visible = false;
                addFieldIcon.Visible = false;

                // Меняем количество созданных полей
                countAddsField++;


                switch (countAddsField)
                {

                    case 1:

                        // Меняем размер формы
                        this.Size = new Size(this.Width, 345);

                        // Показываем поле и разделитель
                        fieldText1.Visible = true;
                        fieldSeparator1.Visible = true;

                        // Передаем фокус
                        fieldText1.Focus();

                        // Показываем кнопку "Удалить поле"
                        removeField.Visible = true;
                        removeFieldIcon.Visible = true;

                        break;

                    case 2:

                        // Блокируем элемент
                        fieldText1.Enabled = false;

                        // Меняем размер формы
                        this.Size = new Size(this.Width, 389);

                        // Показываем поле и разделитель
                        fieldText2.Visible = true;
                        fieldSeparator2.Visible = true;

                        // Передаем фокус
                        fieldText2.Focus();

                        break;

                    case 3:

                        // Блокируем элемент
                        fieldText2.Enabled = false;

                        // Меняем размер формы
                        this.Size = new Size(this.Width, 433);

                        // Показываем поле и разделитель
                        fieldText3.Visible = true;
                        fieldSeparator3.Visible = true;

                        // Передаем фокус
                        fieldText3.Focus();

                        break;

                    case 4:

                        // Блокируем элемент
                        fieldText3.Enabled = false;

                        // Меняем размер формы
                        this.Size = new Size(this.Width, 477);

                        // Показываем поле и разделитель
                        fieldText4.Visible = true;
                        fieldSeparator4.Visible = true;

                        // Передаем фокус
                        fieldText4.Focus();

                        break;

                    case 5:

                        // Блокируем элемент
                        fieldText4.Enabled = false;

                        // Меняем размер формы
                        this.Size = new Size(this.Width, 521);

                        // Показываем поле и разделитель
                        fieldText5.Visible = true;
                        fieldSeparator5.Visible = true;

                        // Передаем фокус
                        fieldText5.Focus();

                        break;

                    case 6:

                        // Блокируем элемент
                        fieldText5.Enabled = false;

                        // Меняем размер формы
                        this.Size = new Size(this.Width, 565);

                        // Показываем поле и разделитель
                        fieldText6.Visible = true;
                        fieldSeparator6.Visible = true;

                        // Передаем фокус
                        fieldText6.Focus();

                        // Скрываем кнопку "Добавить поле"
                        addField.Visible = false;
                        addFieldIcon.Visible = false;

                        // Меняем положение кнопки "Удалить поле"
                        removeField.Location = new Point
                            (addField.Location.X, addField.Location.Y);
                        removeFieldIcon.Location = new Point
                            (addFieldIcon.Location.X, addFieldIcon.Location.Y);

                        break;
                }
            }
            else
            {
                // Показываем ошибку
                ShowError("Введите название сейфа");
            }


            // Перерисовываем
            this.Invalidate();
        }

        /// <summary>
        /// Метод, который удаляет поле
        /// </summary>
        private void hideField()
        {

            switch (countAddsField)
            {
                case 1:

                    // Меняем размер формы
                    this.Size = new Size(this.Width, 272);
                    // Скрываем поле и разделитель
                    fieldText1.Visible = false;
                    fieldSeparator1.Visible = false;
                    // Обнуляем поле
                    fieldText1.Text = string.Empty;
                    // Передаем фокус ???
                    safeName.Focus();
                    // Показываем кнопку добавить поле
                    addField.Visible = true;
                    addFieldIcon.Visible = true;
                    // Скрываем кнопку удалить поле
                    removeField.Visible = false;
                    removeFieldIcon.Visible = false;

                    break;

                case 2:

                    // Включаем элемент
                    fieldText1.Enabled = true;
                    // Меняем размер формы
                    this.Size = new Size(this.Width, 345);
                    // Скрываем поле и разделитель
                    fieldText2.Visible = false;
                    fieldSeparator2.Visible = false;
                    // Обнуляем поле
                    fieldText2.Text = string.Empty;
                    // Передаем фокус ???
                    fieldText1.Focus();
                    // Показываем кнопку добавить поле
                    addField.Visible = true;
                    addFieldIcon.Visible = true;

                    break;

                case 3:

                    // Включаем элемент
                    fieldText2.Enabled = true;
                    // Меняем размер формы
                    this.Size = new Size(this.Width, 389);
                    // Скрываем поле и разделитель
                    fieldText3.Visible = false;
                    fieldSeparator3.Visible = false;
                    // Обнуляем поле
                    fieldText3.Text = string.Empty;
                    // Передаем фокус ???
                    fieldText2.Focus();
                    // Показываем кнопку добавить поле
                    addField.Visible = true;
                    addFieldIcon.Visible = true;

                    break;

                case 4:

                    // Включаем элемент
                    fieldText3.Enabled = true;
                    // Меняем размер формы
                    this.Size = new Size(this.Width, 433);
                    // Скрываем поле и разделитель
                    fieldText4.Visible = false;
                    fieldSeparator4.Visible = false;
                    // Обнуляем поле
                    fieldText4.Text = string.Empty;
                    // Передаем фокус ???
                    fieldText3.Focus();
                    // Показываем кнопку добавить поле
                    addField.Visible = true;
                    addFieldIcon.Visible = true;

                    break;

                case 5:

                    // Включаем элемент
                    fieldText4.Enabled = true;
                    // Меняем размер формы
                    this.Size = new Size(this.Width, 477);
                    // Скрываем поле и разделитель
                    fieldText5.Visible = false;
                    fieldSeparator5.Visible = false;
                    // Обнуляем поле
                    fieldText5.Text = string.Empty;
                    // Передаем фокус ???
                    fieldText4.Focus();
                    // Показываем кнопку добавить поле
                    addField.Visible = true;
                    addFieldIcon.Visible = true;

                    break;

                case 6:

                    // Включаем элемент
                    fieldText5.Enabled = true;
                    // Меняем размер формы
                    this.Size = new Size(this.Width, 521);
                    // Скрываем поле и разделитель
                    fieldText6.Visible = false;
                    fieldSeparator6.Visible = false;
                    // Обнуляем поле
                    fieldText6.Text = string.Empty;
                    // Передаем фокус ???
                    fieldText5.Focus();
                    // Меняем положение кнопки "Удалить поле"
                    removeField.Location = new Point
                        (225, addField.Location.Y);
                    removeFieldIcon.Location = new Point
                        (202, addFieldIcon.Location.Y);
                    // Показываем кнопку добавить поле
                    addField.Visible = true;
                    addFieldIcon.Visible = true;

                    break;
            }

            countAddsField--;
        }

        /// <summary>
        /// Добавляем сейф
        /// </summary>
        /// <param name="safeName">Наименование сейфа</param>
        /// <param name="fields">Массив полей</param>
        private void addSafe(string safeName, string[] fields)
        {
            (this.Owner as Main).CreateSafe(new Safe(safeName, fields));
        }

        #endregion

        
        // Конструктор
        public CreateSafeForm()
        {
            InitializeComponent();

            // Подключаем шрифты
            UseFonts();

            // Событие при клике на данную форму
            this.Click += (f, a) => logoLabel.Focus();

            // Событие при изменении размеров формы
            this.Resize += (f, a) => 
            {
                this.Location = new Point(this.Location.X, 
                    (this.Owner as Main).Location.Y + (this.Owner as Main).Height / 2 - this.Height / 2);
            };

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

            // Ставим плейсхолдер для имени сейфа
            Animation.Placeholder.addPlaceholder(safeName, "Название", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));

            // Ставим плейсхолдеры для полей
            Animation.Placeholder.addPlaceholder(fieldText1, "Поле", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Animation.Placeholder.addPlaceholder(fieldText2, "Поле", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Animation.Placeholder.addPlaceholder(fieldText3, "Поле", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Animation.Placeholder.addPlaceholder(fieldText4, "Поле", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Animation.Placeholder.addPlaceholder(fieldText5, "Поле", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Animation.Placeholder.addPlaceholder(fieldText6, "Поле", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));

            // Событие при получении и потере фокуса
            safeName.Enter += (f, a) => 
            {
                safeName.Focus();
                safeNameSeparator.BackColor = Color.FromArgb(65, 65, 65);
            };
            safeName.Leave += (f, a) =>
            {
                safeNameSeparator.BackColor = Color.FromArgb(40, 40, 40);
            };

            // Событие, строиящие визуал кнопки добавить поле
            addField.MouseEnter += (f, a) => 
            {
                addField.ForeColor = Color.FromArgb(29, 185, 84);
                addFieldIcon.Image = Properties.Resources.addFieldGreen;
            };
            addField.MouseLeave += (f, a) =>
            {
                addField.ForeColor = Color.FromArgb(120, 120, 120);
                addFieldIcon.Image = Properties.Resources.addFieldGray;
            };
            addFieldIcon.MouseEnter += (f, a) => 
            {
                addField.ForeColor = Color.FromArgb(29, 185, 84);
                addFieldIcon.Image = Properties.Resources.addFieldGreen;
            };
            addFieldIcon.MouseLeave += (f, a) =>
            {
                addField.ForeColor = Color.FromArgb(120, 120, 120);
                addFieldIcon.Image = Properties.Resources.addFieldGray;
            };
            addField.MouseDown += (f, a) => 
            {
                addField.ForeColor = Color.FromArgb(70, 70, 70);
                addFieldIcon.Image = Properties.Resources.addFieldDarkGray;
            };
            addField.MouseUp += (f, a) =>
            {
                addField.ForeColor = Color.FromArgb(29, 185, 84);
                addFieldIcon.Image = Properties.Resources.addFieldGreen;
            };
            addFieldIcon.MouseDown += (f, a) =>
            {
                addField.ForeColor = Color.FromArgb(70, 70, 70);
                addFieldIcon.Image = Properties.Resources.addFieldDarkGray;
            };
            addFieldIcon.MouseUp += (f, a) =>
            {
                addField.ForeColor = Color.FromArgb(29, 185, 84);
                addFieldIcon.Image = Properties.Resources.addFieldGreen;
            };

            // Событие клика по "Добавить поле"
            addField.Click += (f, a) => createField();
            addFieldIcon.Click += (f, a) => createField();


            // Событие, строиящие визуал кнопки удалить поле
            removeField.MouseEnter += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(29, 185, 84);
                removeFieldIcon.Image = Properties.Resources.removeFieldGreen;
            };
            removeField.MouseLeave += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(120, 120, 120);
                removeFieldIcon.Image = Properties.Resources.removeFieldGray;
            };
            removeFieldIcon.MouseEnter += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(29, 185, 84);
                removeFieldIcon.Image = Properties.Resources.removeFieldGreen;
            };
            removeFieldIcon.MouseLeave += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(120, 120, 120);
                removeFieldIcon.Image = Properties.Resources.removeFieldGray;
            };
            removeField.MouseDown += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(70, 70, 70);
                removeFieldIcon.Image = Properties.Resources.removeFieldDarkGray;
            };
            removeField.MouseUp += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(29, 185, 84);
                removeFieldIcon.Image = Properties.Resources.removeFieldGreen;
            };
            removeFieldIcon.MouseDown += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(70, 70, 70);
                removeFieldIcon.Image = Properties.Resources.removeFieldDarkGray;
            };
            removeFieldIcon.MouseUp += (f, a) =>
            {
                removeField.ForeColor = Color.FromArgb(29, 185, 84);
                removeFieldIcon.Image = Properties.Resources.removeFieldGreen;
            };

            // Событие при клике по "Удалить поле"
            removeField.Click += (f, a) => hideField();
            removeFieldIcon.Click += (f, a) => hideField();


            // Событие изменения текста на полях категории
            // Используется при добавлении полей
            fieldText1.TextChanged += (f, a) => 
            {
                if (fieldText1.Text != "Поле" && fieldText1.Text != string.Empty)
                {
                    addField.Visible = true;
                    addFieldIcon.Visible = true;
                }
                else
                {
                    addField.Visible = false;
                    addFieldIcon.Visible = false;
                }
            };
            fieldText2.TextChanged += (f, a) =>
            {
                if (fieldText2.Text != "Поле" && fieldText2.Text != string.Empty)
                {
                    addField.Visible = true;
                    addFieldIcon.Visible = true;
                }
                else
                {
                    addField.Visible = false;
                    addFieldIcon.Visible = false;
                }
            };
            fieldText3.TextChanged += (f, a) =>
            {
                if (fieldText3.Text != "Поле" && fieldText3.Text != string.Empty)
                {
                    addField.Visible = true;
                    addFieldIcon.Visible = true;
                }
                else
                {
                    addField.Visible = false;
                    addFieldIcon.Visible = false;
                }
            };
            fieldText4.TextChanged += (f, a) =>
            {
                if (fieldText4.Text != "Поле" && fieldText4.Text != string.Empty)
                {
                    addField.Visible = true;
                    addFieldIcon.Visible = true;
                }
                else
                {
                    addField.Visible = false;
                    addFieldIcon.Visible = false;
                }
            };
            fieldText5.TextChanged += (f, a) =>
            {
                if (fieldText5.Text != "Поле" && fieldText5.Text != string.Empty)
                {
                    addField.Visible = true;
                    addFieldIcon.Visible = true;
                }
                else
                {
                    addField.Visible = false;
                    addFieldIcon.Visible = false;
                }
            };
        }
        
        #region Методы

        // Событие при загрузке формы
        private void CreateSafeForm_Load(object sender, EventArgs e)
        {
            // Рисуем форму
            FormStyleTwo.PaintForm(this);
        }

        // Кнопка отмена
        private void cancel_Click(object sender, EventArgs e)
        {
            // Обнуляем количество открытых панелей меню
            (this.Owner as Main).ZeroingCountCreateSafeMenu();

            // Закрываем
            this.Close();
        }

        // Клик по кнопке сохранить
        private void saveButton_Click(object sender, EventArgs e)
        {
            // Если название сейфа не введено
            if (safeName.Text == "Название")
            {
                // Показываем ошибку
                ShowError("Введите название сейфа");
            }
            else
            {
                // Если не заполнено первое поле.
                // Так как все остальные поля можно заполнить только
                // после заполненения первого, то можно выполнить проверку
                // таким образом
                if (fieldText1.Text == "Поле" || fieldText1.Text == string.Empty)
                {
                    // Показываем ошибку
                    ShowError("Заполните хотя бы одно поле");
                }
                else
                {
                    // Если последнее поле не заполнено
                    if (Controls["fieldText" + countAddsField].Text == "Поле")
                    {
                        ShowError("Заполните или удалите пустое поле");
                    }
                    else
                    {
                        // Заполняем данные
                        // Передаем заполняем название сейфа и массив полей
                        NameSafe = safeName.Text;

                        int i = 0;
                        while (i < countAddsField)
                        {
                            FieldsSafe[i] = Controls["fieldText" + (i + 1)].Text;
                            i++;
                        }

                        // Создаем сейф
                        addSafe(NameSafe, FieldsSafe);

                        // Закрываем
                        cancel_Click(sender, e);
                    }
                }
            }
        }

        #endregion
        
    }
}
