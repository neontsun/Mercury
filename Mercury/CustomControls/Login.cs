using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Text;
using System;
using System.Threading.Tasks;
using System.IO;

namespace Mercury.CustomControls
{
    public partial class Login : UserControl
    {

        #region Хуки и глобальные переменные

        // Создаем коллекцию шрифтов
        PrivateFontCollection pr = new PrivateFontCollection();
        // Переменная, которая говорит о том, нажата ли иконка
        // показа пароля (глаз) (eyeIcon)
        bool showPassword = false;
        // Количество правильныйх условий
        int allFactorsIsTrue = 0;

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// Использует шрифт из файла.
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
            loginPanelLabel.Font = new Font(fontFamilies[3], 20);

            // Поле "Email"
            emailData.Font = new Font(fontFamilies[1], 12);

            // Поле "Пароль"
            passwordData.Font = new Font(fontFamilies[1], 12);

            // Поле "Оставаться в системе"
            loginCheckText.Font = new Font(fontFamilies[3], 10);

            // Кнопка "Вход"
            signinButton.Font = new Font(fontFamilies[2], 12);
        }

        /// <summary>
        /// Показывает сообщение с ошибкой.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void ShowError(string message)
        {
            // Показываем форму ошибки и передаем сообщение ошибки
            ErrorForm error = new ErrorForm(message);
            // Меняем позицию ошибки
            error.Location = new Point(this.Parent.Parent.Location.X + (this.Parent.Parent.Width / 2 - error.Width / 2) + 2,
                    this.Parent.Parent.Location.Y + (this.Parent.Parent.Height / 2 - error.Height / 2) - 30);
            // Показываем ошибку
            error.ShowDialog();
        }

        /// <summary>
        /// Очищает все поля и ставит нужные плейсхолдеры
        /// </summary>
        public void ClearControl()
        {
            // Ставим плейсхолдеры
            emailData.Text = "Email";
            passwordData.Text = "Пароль";
            // Меняем цвета текста
            emailData.ForeColor = Color.FromArgb(120, 120, 120);
            passwordData.ForeColor = Color.FromArgb(120, 120, 120);
            // Обнуляем защиту пароля
            passwordData.PasswordChar = char.Parse("\0");
            // Меняем иконку глаза (eyeIcon)
            eyeIcon.Image = Properties.Resources.eyeView;
            // Меняем иконку "Отаваться в системе"
            loginCheck.Image = null;
        }

        #endregion

        
        /// <summary>
        /// Конструктор
        /// </summary>
        public Login()
        {
            InitializeComponent();

            // Используем шрифты
            UseFonts();

            // Добавляем плейсхолдеры
            Animation.Placeholder.addPlaceholder(emailData, "Email", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Animation.Placeholder.addPlaceholder(passwordData, "Пароль", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));

            // Клик по панели авторизации
            loginPanel.Click += (f, a) => 
            {
                loginPanel.Focus();
            };

            // Событие при изменении видимости контрола
            this.VisibleChanged += (f, a) => 
            {
                if (this.Visible == true)
                {
                    loginPanel.Focus();
                }
                else
                {
                    // Очищаем поля
                    ClearControl();
                }
            };

            this.Click += (f, a) => loginPanel.Focus();

            // Клик по полю Email'a
            emailData.Enter += (f, a) => emailSeparator.BackColor = Color.FromArgb(65, 65, 65);
            emailData.Leave += (f, a) => emailSeparator.BackColor = Color.FromArgb(40, 40, 40);

            // Клик по полю Пароля
            passwordData.Enter += (f, a) => 
            {
                passwordSeparator.BackColor = Color.FromArgb(65, 65, 65);

                // Если нажата иконка глаза (eye)
                if (showPassword != true)
                {
                    // Ставим символ сокрытия пароля
                    passwordData.PasswordChar = '•';
                }
                
            };
            passwordData.Leave += (f, a) => 
            {
                passwordSeparator.BackColor = Color.FromArgb(40, 40, 40);

                // Если текст плейсхолдера, то показываем его
                if (passwordData.Text == "Пароль")
                {
                    passwordData.PasswordChar = char.Parse("\0");

                    // Ставим стандартную иконку глаза (eye)
                    eyeIcon.Image = Properties.Resources.eyeView;

                    // Обнуляем флаг нажалия на глаз (eye)
                    showPassword = false;
                }
            };

            // Клик по кнопке "Оставаться в системе"
            loginCheck.Click += (f, a) => 
            {
                loginPanel.Focus();

                // Проверка на то, стоит галка, или нет
                if (loginCheck.Image == null)
                {
                    loginCheck.Image = Properties.Resources.galkaGreen;
                }
                else { loginCheck.Image = null; }
            };
            loginCheckText.Click += (f, a) =>
            {
                loginPanel.Focus();

                // Проверка на то, стоит галка, или нет
                if (loginCheck.Image == null)
                {
                    loginCheck.Image = Properties.Resources.galkaGreen;
                }
                else { loginCheck.Image = null; }
            };

            // Наведение на кнопку "Вход" (signinButton)
            signinButton.MouseEnter += (f, a) =>
            {
                signinButton.Back = Color.FromArgb(30, 215, 96);
            };
            signinButton.MouseLeave += (f, a) =>
            {
                signinButton.Back = Color.FromArgb(29, 185, 84);
            };

            // Клик по кнопке глаза (eye)
            eyeIcon.Click += (f, a) => 
            {
                // Если мы показываем текст в поле пароля
                if (showPassword == false)
                {
                    // Обновляем флаг нажатия на иконку (eye)
                    showPassword = true;

                    // Меняем иконку
                    eyeIcon.Image = Properties.Resources.eyeHide;

                    // Показываем текст в поле пароля
                    passwordData.PasswordChar = char.Parse("\0");
                }
                else
                {
                    // Обнуляем флаг нажатия на иконку (eye)
                    showPassword = false;

                    // Меняем иконку
                    eyeIcon.Image = Properties.Resources.eyeView;

                    // Если текст пароля не равен тексту плейсхолдера
                    if (passwordData.Text != "Пароль")
                    {
                        // Защищаем текст в поле пароля
                        passwordData.PasswordChar = '•';
                    }
                }
            };
        }

        
        #region Методы

        /// <summary>
        /// Клик по кнопке "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signinButton_Click(object sender, EventArgs e)
        {
            // Собираем данные для проверки
            string[] data =
            {
                emailData.Text,
                passwordData.Text
            };


            // Если поня не заполнены
            // Уровень работы с интерфейсом
            if (emailData.Text == "Email" || passwordData.Text == "Пароль")
                // Сообщение с ошибкой
                ShowError("Вы заполнили не все поля");
            else
            {
                // Проверяем валидность пароля
                if (WorkingScripts.ValidateEmail.IsValidEmail(emailData.Text))
                    // Инкрементируем количество верных условий
                    allFactorsIsTrue++;
                else
                    // Сообщение с ошибкой
                    ShowError("Неправильный email");

                // Если пароль не совпадает с допустимой длиной
                if (passwordData.Text.Length < 6 || passwordData.Text.Length > 32)
                    // Сообщение с ошибкой
                    ShowError("Пароль должен быть длиной от 6 до 32 символов");
                else
                    // Инкрементируем количество верных условий
                    allFactorsIsTrue++;


                // Если все условия соблюдены
                // Уровень работы с данными, а не с интерфейсом
                if (allFactorsIsTrue == 2)
                {
                    // Обнуляем количество верных условий
                    allFactorsIsTrue = 0;

                    // Проверяем аккаунт на существование
                    if (WorkingScripts.DateBase.ExistenceCheck("User", "Email", data[0]))
                    {
                        // Проверяем данные
                        if (WorkingScripts.DateBase.CheckData("User", new string[] { "Email", "Password" }, data))
                        {
                            // Сохраняем сессию
                            Properties.Settings.Default.userEmail = data[0];
                            Properties.Settings.Default.userPassword = data[1];
                            Properties.Settings.Default.Save();

                            // Если стоит галка, то ставим соответствующий хук
                            if (loginCheck.Image != null)
                            {
                                Properties.Settings.Default.saveSession = true;
                                Properties.Settings.Default.Save();
                            }

                            // Скрываем панель входа и регистрации,
                            // тем самым предоставляя пользователю доступ к приложению
                            // Все действия в новом потоке.
                            this.Parent.Visible = false;
                            this.Parent.Location = new Point(1124, 28);

                            // Очищаем поля
                            ClearControl();
                        }
                        else
                            ShowError("Неправильный логин или пароль");
                    }
                    else
                        ShowError("Такого аккаунта не существует");
                }

                // Обнуляем количество верных условий
                allFactorsIsTrue = 0;
            }
        }

        #endregion
    }
}
