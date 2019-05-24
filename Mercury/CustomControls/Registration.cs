using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mercury.Animation;
using Mercury.CustomControls;

namespace Mercury
{
    public partial class Registration : UserControl
    {

        #region Хуки и глобальные переменные

        // Создаем коллекцию шрифтов
        PrivateFontCollection pr = new PrivateFontCollection();
        // Переменная, которая говорит о том, нажата ли иконка
        // показа пароля (глаз) (eyeIcon)
        bool showPassword = false;
        bool showMasterPassword = false;
        bool showReMasterPassword = false;
        // Количество правильныйх условий
        int allFactorsIsTrue = 0;

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
            registrationPanelLabel.Font = new Font(fontFamilies[3], 20);

            // Поле "Email"
            emailData.Font = new Font(fontFamilies[1], 12);

            // Поле "Пароль"
            passwordData.Font = new Font(fontFamilies[1], 12);

            // Поле "MasterPassword"
            masterpasswordData.Font = new Font(fontFamilies[1], 12);

            // Поле "ReMasterPassword"
            remasterpasswordData.Font = new Font(fontFamilies[1], 12);

            // Поле "Оставаться в системе"
            registrationCheckText.Font = new Font(fontFamilies[3], 10);

            // Кнопка "Вход"
            signupButton.Font = new Font(fontFamilies[2], 12);
        }

        /// <summary>
        /// Показывает сообщение с ошибкой.
        /// </summary>
        /// <param name="message">Сообщение</param>
        public void ShowError(string message)
        {
            // Показываем форму ошибку
            ErrorForm error = new ErrorForm(message);
            // Меняем позицию формы ошибки
            error.Location = new Point(this.Parent.Parent.Location.X + (this.Parent.Parent.Width / 2 - error.Width / 2) + 2,
                    this.Parent.Parent.Location.Y + (this.Parent.Parent.Height / 2 - error.Height / 2) - 30);
            // Показываем форму ошибки
            error.ShowDialog();
        }

        /// <summary>
        ///  Очищает поля и ставит плейсхолдеры
        /// </summary>
        public void ClearControl()
        {
            // Ставим плейсхолдеры
            emailData.Text = "Email";
            passwordData.Text = "Пароль";
            masterpasswordData.Text = "Мастер-пароль";
            remasterpasswordData.Text = "Подтвердите мастер-пароль";

            // Меняем цвета текста
            emailData.ForeColor = Color.FromArgb(120, 120, 120);
            passwordData.ForeColor = Color.FromArgb(120, 120, 120);
            masterpasswordData.ForeColor = Color.FromArgb(120, 120, 120);
            remasterpasswordData.ForeColor = Color.FromArgb(120, 120, 120);

            // Обнуляем защиту пароля
            passwordData.PasswordChar = char.Parse("\0");
            masterpasswordData.PasswordChar = char.Parse("\0");
            remasterpasswordData.PasswordChar = char.Parse("\0");

            // Меняем иконку глаза (eyeIcon)
            eyePasswordIcon.Image = Properties.Resources.eyeView;
            eyeMasterpasswordIcon.Image = Properties.Resources.eyeView;
            eyeReMasterpasswordIcon.Image = Properties.Resources.eyeView;

            // Меняем иконку "Отаваться в системе"
            registrationCheck.Image = null;
        }

        #endregion
        

        /// <summary>
        /// Конструктор
        /// </summary>
        public Registration()
        {
            InitializeComponent();

            // Используем шрифты
            UseFonts();


            // Добавляем плейсхолдеры
            Placeholder.addPlaceholder(emailData, "Email", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Placeholder.addPlaceholder(passwordData, "Пароль", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Placeholder.addPlaceholder(masterpasswordData, "Мастер-пароль", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            Placeholder.addPlaceholder(remasterpasswordData, "Подтвердите мастер-пароль", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));

            // Клик по панели авторизации
            registrationPanel.Click += (f, a) => registrationPanel.Focus();

            // Событие при изменении видимости контрола
            this.VisibleChanged += (f, a) =>
            {
                if (Visible == true)
                    registrationPanel.Focus();
                else
                    // Очищаем поля
                    ClearControl();
            };

            this.Click += (f, a) => registrationPanel.Focus();

            // Клик по полю Email'a
            emailData.Enter += (f, a) => emailSeparator.BackColor = Color.FromArgb(65, 65, 65);
            emailData.Leave += (f, a) => emailSeparator.BackColor = Color.FromArgb(40, 40, 40);

            // Клик по полю Пароля
            passwordData.Enter += (f, a) =>
            {
                passwordSeparator.BackColor = Color.FromArgb(65, 65, 65);

                // Если нажата иконка глаза (eye)
                if (showPassword != true)
                    // Ставим символ сокрытия пароля
                    passwordData.PasswordChar = '•';

            };
            passwordData.Leave += (f, a) =>
            {
                passwordSeparator.BackColor = Color.FromArgb(40, 40, 40);

                // Если текст плейсхолдера, то показываем его
                if (passwordData.Text == "Пароль")
                {
                    passwordData.PasswordChar = char.Parse("\0");

                    // Ставим стандартную иконку глаза (eye)
                    eyePasswordIcon.Image = Properties.Resources.eyeView;

                    // Обнуляем флаг нажалия на глаз (eye)
                    showPassword = false;
                }
            };

            // Клик по полю Мастер-пароль
            masterpasswordData.Enter += (f, a) =>
            {
                masterpasswordSeparator.BackColor = Color.FromArgb(65, 65, 65);

                // Если нажата иконка глаза (eye)
                if (showMasterPassword != true)
                    // Ставим символ сокрытия пароля
                    masterpasswordData.PasswordChar = '•';

            };
            masterpasswordData.Leave += (f, a) =>
            {
                masterpasswordSeparator.BackColor = Color.FromArgb(40, 40, 40);

                // Если текст плейсхолдера, то показываем его
                if (masterpasswordData.Text == "Мастер-пароль")
                {
                    masterpasswordData.PasswordChar = char.Parse("\0");

                    // Ставим стандартную иконку глаза (eye)
                    eyeMasterpasswordIcon.Image = Properties.Resources.eyeView;

                    // Обнуляем флаг нажалия на глаз (eye)
                    showMasterPassword = false;
                }
            };

            // Клик по полю Подтвердите Мастер-пароль
            remasterpasswordData.Enter += (f, a) =>
            {
                remasterpasswordSeparator.BackColor = Color.FromArgb(65, 65, 65);

                // Если нажата иконка глаза (eye)
                if (showReMasterPassword != true)
                    // Ставим символ сокрытия пароля
                    remasterpasswordData.PasswordChar = '•';

            };
            remasterpasswordData.Leave += (f, a) =>
            {
                remasterpasswordSeparator.BackColor = Color.FromArgb(40, 40, 40);

                // Если текст плейсхолдера, то показываем его
                if (remasterpasswordData.Text == "Подтвердите мастер-пароль")
                {
                    remasterpasswordData.PasswordChar = char.Parse("\0");

                    // Ставим стандартную иконку глаза (eye)
                    eyeReMasterpasswordIcon.Image = Properties.Resources.eyeView;

                    // Обнуляем флаг нажалия на глаз (eye)
                    showReMasterPassword = false;
                }
            };

            // Клик по кнопке "Оставаться в системе"
            registrationCheck.Click += (f, a) =>
            {
                registrationPanel.Focus();

                // Проверка на то, стоит галка, или нет
                if (registrationCheck.Image == null)
                    registrationCheck.Image = Properties.Resources.galkaGreen;
                else
                    registrationCheck.Image = null;
            };
            registrationCheckText.Click += (f, a) =>
            {
                registrationPanel.Focus();

                // Проверка на то, стоит галка, или нет
                if (registrationCheck.Image == null)
                    registrationCheck.Image = Properties.Resources.galkaGreen;
                else
                    registrationCheck.Image = null;
            };

            // Наведение на кнопку "Регистрация" (signupButton)
            signupButton.MouseEnter += (f, a) => signupButton.Back = Color.FromArgb(30, 215, 96);
            signupButton.MouseLeave += (f, a) => signupButton.Back = Color.FromArgb(29, 185, 84);
            
            // Клик по кнопке глаза у пароля(eye)
            eyePasswordIcon.Click += (f, a) =>
            {
                // Если мы показываем текст в поле пароля
                if (showPassword == false)
                {
                    // Обновляем флаг нажатия на иконку (eye)
                    showPassword = true;
                    // Меняем иконку
                    eyePasswordIcon.Image = Properties.Resources.eyeHide;
                    // Показываем текст в поле пароля
                    passwordData.PasswordChar = char.Parse("\0");
                }
                else
                {
                    // Обнуляем флаг нажатия на иконку (eye)
                    showPassword = false;
                    // Меняем иконку
                    eyePasswordIcon.Image = Properties.Resources.eyeView;
                    // Если текст пароля не равен тексту плейсхолдера
                    if (passwordData.Text != "Пароль")
                        // Защищаем текст в поле пароля
                        passwordData.PasswordChar = '•';
                }
            };

            // Клик по кнопке глаза у мастер-пароля
            eyeMasterpasswordIcon.Click += (f, a) =>
            {
                // Если мы показываем текст в поле пароля
                if (showMasterPassword == false)
                {
                    // Обновляем флаг нажатия на иконку (eye)
                    showMasterPassword = true;

                    // Меняем иконку
                    eyeMasterpasswordIcon.Image = Properties.Resources.eyeHide;

                    // Показываем текст в поле пароля
                    masterpasswordData.PasswordChar = char.Parse("\0");
                }
                else
                {
                    // Обнуляем флаг нажатия на иконку (eye)
                    showMasterPassword = false;

                    // Меняем иконку
                    eyeMasterpasswordIcon.Image = Properties.Resources.eyeView;

                    // Если текст пароля не равен тексту плейсхолдера
                    if (masterpasswordData.Text != "Мастер-пароль")
                        // Защищаем текст в поле пароля
                        masterpasswordData.PasswordChar = '•';
                }
            };

            // Клик по кнопке глаза у подтверждения мастер-пароля
            eyeReMasterpasswordIcon.Click += (f, a) =>
            {
                // Если мы показываем текст в поле пароля
                if (showReMasterPassword == false)
                {
                    // Обновляем флаг нажатия на иконку (eye)
                    showReMasterPassword = true;

                    // Меняем иконку
                    eyeReMasterpasswordIcon.Image = Properties.Resources.eyeHide;

                    // Показываем текст в поле пароля
                    remasterpasswordData.PasswordChar = char.Parse("\0");
                }
                else
                {
                    // Обнуляем флаг нажатия на иконку (eye)
                    showReMasterPassword = false;

                    // Меняем иконку
                    eyeReMasterpasswordIcon.Image = Properties.Resources.eyeView;

                    // Если текст пароля не равен тексту плейсхолдера
                    if (remasterpasswordData.Text != "Подтвердите мастер-пароль")
                        // Защищаем текст в поле пароля
                        remasterpasswordData.PasswordChar = '•';
                }
            };
        }


        #region Методы

        /// <summary>
        /// Клик по кнопке "Рагистрация"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signupButton_Click(object sender, System.EventArgs e)
        {
            // Собираем данные для проверки
            string[] data =
            {
                emailData.Text,
                passwordData.Text
            };

            // Если поня не заполнены
            if (emailData.Text == "Email" || passwordData.Text == "Пароль" || masterpasswordData.Text == "Мастер-пароль"
                || remasterpasswordData.Text == "Подтвердите мастер-пароль")
                ShowError("Вы заполнили не все поля");
            else
            {
                // Мастер-пароль и поле подтверждения не совпадают 
                if (masterpasswordData.Text != remasterpasswordData.Text)
                    // Показываем форму с ошибкой
                    ShowError("Проверьте правильность мастер-пароля");
                else
                {
                    // Проверяем валидность пароля
                    if (WorkingScripts.ValidateEmail.IsValidEmail(emailData.Text))
                        // Инкрементируем количество верных условий
                        allFactorsIsTrue++;
                    else
                        // Показываем форму с ошибкой
                        ShowError("Неправильный email");

                    // Если пароль не совпадает с допустимой длиной
                    if (passwordData.Text.Length < 6 || passwordData.Text.Length > 32)
                        // Показываем форму с ошибкой
                        ShowError("Пароль должен быть длиной от 6 до 32 символов");
                    else
                        // Инкрементируем количество верных условий
                        allFactorsIsTrue++;

                    // Если мастер-пароль и подтвердение мастер-пароля не совпадают с допустимой длиной
                    if (masterpasswordData.Text.Length < 6 || masterpasswordData.Text.Length > 32 && 
                        remasterpasswordData.Text.Length < 6 || remasterpasswordData.Text.Length > 32)
                        // Показываем форму с ошибкой
                        ShowError("Мастер-пароль должен быть длиной \nот 6 до 32 символов");
                    else
                        // Инкрементируем количество верных условий
                        allFactorsIsTrue++;

                    // Если все условия соблюдены
                    if (allFactorsIsTrue == 3)
                    {
                        allFactorsIsTrue = 0;

                        // Регистрируем пользователя
                        if (WorkingScripts.DateBase.ExistenceCheck("User", "Email", data[0]))
                            // Показываем форму с ошибкой
                            ShowError("Такой аккаунт уже существует");
                        else
                        {
                            // Сохраняем сессию
                            Properties.Settings.Default.userEmail = data[0];
                            Properties.Settings.Default.userPassword = data[1];
                            Properties.Settings.Default.Save();

                            // Если стоит галка сессии
                            if (registrationCheck.Image != null)
                            {
                                Properties.Settings.Default.saveSession = true;
                                Properties.Settings.Default.Save();
                            }

                            // Скрываем панель входа и регистрации,
                            // тем самым предоставляя пользователю доступ к приложению
                            this.Parent.Visible = false;
                            this.Parent.Location = new Point(1124, 28);
                            
                            // Регистрируем пользователя в новом потоке
                            WorkingScripts.DateBase.InsertData("User", new string[] { "Email", "Password" }, data);
                            
                            // Очищаем поля
                            ClearControl();
                        }
                    }

                    // Обнуляем количество верных условий
                    allFactorsIsTrue = 0;
                }
            }
        }

        #endregion
        
    }
}
