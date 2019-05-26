using System.Drawing;
using System.Drawing.Text;
using pivyLab.UserForms;
using System.IO;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using Mercury.WorkingScripts;
using System.Runtime.Serialization.Formatters.Binary;

namespace Mercury
{

    // Всегда передаем фокус на елемент при клике на него



    public partial class Main : FormTwo
    {

        #region Хуки и глобальные переменные

        // Создаем коллекцию
        PrivateFontCollection pr = new PrivateFontCollection();
        // Переменная, которая говорит о том, активно ли меню выхода
        bool emailRightSideMenu = false;
        // Правое меню на верхней панели
        CustomControls.RightSideMenu rightSideMenu = new CustomControls.RightSideMenu();
        // Панель создания сейфа
        CustomControls.CreateSafeForm createSafe = new CustomControls.CreateSafeForm();
        // Количество открытых меню
        int countOpenMenu = 0;
        // Количество панелей создания сейфа
        public int countOpenMenuCreateSafe = 0;

        // Активный сейф
        Safe activeSafe;

        #endregion

        #region Списки

        // Список созданных сейфов
        List<Safe> safeCollection = new List<Safe>();
        public List<Folder> folderCollectionInActiveSafe = new List<Folder>();

        #endregion

        #region Вспомагательные методы

        #region Подключение к базе

        /// <summary>
        /// Метод подключения к бд
        /// </summary>
        private void ConnectWithDB()
        {
            // TODO: Сменить базу данных
            // Получаем путь до базы
            string path = Directory.GetCurrentDirectory()
                .Remove(Directory.GetCurrentDirectory().Length - 18) + @"\db\MercuryDB.mdf";
            string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"@\";Integrated Security=True;Connect Timeout=30";
            conn = conn.Replace("@", path);
            // Записываем путь в строку подключения
            Properties.Settings.Default.stringConnection = conn;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region Использование шрифтов

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

            // Кнопка "Войти"
            loginButton.Font = new Font(fontFamilies[2], 12);
            // Кнопка "Регистрация"
            registrationButton.Font = new Font(fontFamilies[2], 12);
            // Надпись / логотип
            textLogo.Font = new Font(fontFamilies[4], 42);
            // Надпись / логотип (Main)
            textLogoMain.Font = new Font(fontFamilies[4], 27);
            // Поле "Поиск"
            searchText.Font = new Font(fontFamilies[2], 11);
            // Поле email'a
            emailText.Font = new Font(fontFamilies[3], 11);
            // Поле лого-лейбла на левой панели
            leftSideLogoLabel.Font = new Font(fontFamilies[2], 10);
            // Надписть "Новый сейф"
            createSafeButtonLabel.Font = new Font(fontFamilies[3], 10);
            // Наименование сейфа на панеле отображения элементов сейфа
            safeItemView_SafeName.Font = new Font(fontFamilies[4], 16);
            // Кнопка "Добавить" элемент на панели элементов сейфа
            safeItemView_AddItem.Font = new Font(fontFamilies[2], 10);
            // Поле создателя сейфа
            safeItemView_SafeCreator.Font = new Font(fontFamilies[2], 10);
            // Поле создателя сейфа
            safeItemView_SafeCreatorPerson.Font = new Font(fontFamilies[2], 10);
            // Поля отображения на панели сейфа
            safeItemView_Field1.Font = new Font(fontFamilies[3], 10);
            safeItemView_Field2.Font = new Font(fontFamilies[3], 10);
            safeItemView_Field3.Font = new Font(fontFamilies[3], 10);
            safeItemView_Field4.Font = new Font(fontFamilies[3], 10);
            safeItemView_Field5.Font = new Font(fontFamilies[3], 10);
            safeItemView_Field6.Font = new Font(fontFamilies[3], 10);
        }

        #endregion

        #region Верхняя панель

        /// <summary>
        /// Метод, который записывает email пользователя на верхнюю панель
        /// </summary>
        private void WriteEmail()
        {
            // Показываем email в нижнем регистре
            emailText.Text = Properties.Settings.Default.userEmail.ToLower();
            // Меняем положение email'a
            emailText.Location = new Point(emailIcon.Location.X - emailText.Width, emailText.Location.Y);
            // Привязываем email к верхнему правому краю
            emailText.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
        }



        #endregion

        #region Меню на верхней панели

        /// <summary>
        /// Открываем правое меню из верхней панели
        /// </summary>
        private void OpenRightSideMenu()
        {
            // Выдаем права на форму
            rightSideMenu.Owner = this;
            // Показываем меню
            rightSideMenu.Show();
            // Меняем позицию правого меню
            rightSideMenu.Location = new Point(this.Location.X + (emailIcon.Location.X + emailIcon.Width - rightSideMenu.Width),
                this.Location.Y + (emailIcon.Location.Y + emailIcon.Height + 10));
        }

        /// <summary>
        /// Закрываем правое меню из верхней панели
        /// </summary>
        private void CloseRightSideMenu() => rightSideMenu.Hide();

        /// <summary>
        /// Выполняет выход их аккаунта
        /// </summary>
        public void Logout()
        {
            // Показываем панель входа / регистрации
            startPanel.Location = new Point(1, 33);
            startPanel.Visible = true;
            // Меняем цвет текста email'a
            emailText.ForeColor = Color.FromArgb(120, 120, 120);
            // Меняем иконку
            emailIcon.Image = Properties.Resources.emailIconGrayDown;
            // Обнуляем хук
            emailRightSideMenu = false;
            // Обнуляем хук количества элементов меню
            countOpenMenu = 0;

            // Обнуляем данные пользователя
            Properties.Settings.Default.userEmail = string.Empty;
            Properties.Settings.Default.userPassword = string.Empty;
            Properties.Settings.Default.Save();
            // Обнуляем хук
            Properties.Settings.Default.saveSession = false;

            // Разворачиваем контролы на весь экран
            login.Size = new Size(this.Width, this.Height - 80);
            registration.Size = new Size(this.Width, this.Height - 80);
            separator1.Size = new Size(this.Width, 1);

            // Чистим список сейфов
            safeList.Controls.Clear();

            safeItemView.Visible = false;
        }

        #endregion

        #region Создание сейфа

        /// <summary>
        /// Метод, который проверяет сейфы на повторные названия
        /// </summary>
        /// <param name="name">Наименование сейфа</param>
        public bool ValidateSafeName(string name)
        {
            bool result = true;

            foreach (var item in safeList.Controls)
            {
                // Если сейф с таким названием уже существует
                if ((item as Label).Text == name)
                    result = false;
            }

            return result;
        }

        /// <summary>
        /// Метод, который обнуляет хук количества открытых панелей создания сейфа
        /// </summary>
        public void ZeroingCountCreateSafeMenu() => this.countOpenMenuCreateSafe = 0;

        /// <summary>
        /// Метод, который закрывает все окна
        /// </summary>
        public void ClearScreenOfWindow()
        {
            // Закрываем окно создания сейфа
            createSafe.Close();
            // Чистим хук количества открытых меню
            ZeroingCountCreateSafeMenu();
        }

        /// <summary>
        /// Возвращает шрифт для сейфа
        /// </summary>
        private Font GetFontForSafe() => new Font(pr.Families[2], 11);

        /// <summary>
        ///  Получаем числовой показателя для следующего лейбла / Объекта сейфа
        /// </summary>
        private int GetLocationForSafe()
        {
            // Если количество элементов в списке контролов
            // равно нулю, то возвращаем позицию первого контрола
            if (safeList.Controls.Count == 0)
                return 20;
            // Иначе возвращаем позицию в результате расчета
            // позиции последнего контрола в списке
            else
                return safeList.Controls[safeList.Controls.Count - 1].Location.Y + 35;
        }

        /// <summary>
        /// Возвращает количество сейфов
        /// </summary>
        /// TODO: Проверить, правильно ли записываются названия сейфов!!!
        private int GetCountSafe => safeList.Controls.Count + 1;

        /// <summary>
        ///  Метод, который добавяет сейф на панель и добавляет его в список сейфов
        /// </summary>
        /// <param name="safe">Сейф</param>
        public void CreateSafe(Safe safe)
        {
            // Записываем данные в базу
            InsertSafeAndCategoryInDB(safe);
            // Чистим список сейфов
            safeList.Controls.Clear();
            // Заполняем список сейфов
            FillSafeList();
            // Передаем фокус на сейф
            FocusedSafe(safe);
        }

        /// <summary>
        /// Добавляет данные в таблицы Category и Safe
        /// </summary>
        /// <param name="safe"></param>
        private void InsertSafeAndCategoryInDB(Safe safe)
        {
            // Массив полей
            string[] fieldCategory = new string[6];
            // Массив значений
            string[] fieldValue = new string[6];

            // В зависимости от количества введенных полей - заполняем значения
            switch (safe.Fields.Count)
            {
                case 1:

                    fieldCategory = new string[]
                    {
                        "CategoryMaker",
                        "FieldOne"
                    };
                    fieldValue = new string[]
                    {
                        Properties.Settings.Default.userEmail,
                        safe.Fields[0]
                    };

                    break;

                case 2:

                    fieldCategory = new string[]
                    {
                        "CategoryMaker",
                        "FieldOne",
                        "FieldTwo"
                    };
                    fieldValue = new string[]
                    {
                        Properties.Settings.Default.userEmail,
                        safe.Fields[0],
                        safe.Fields[1]
                    };

                    break;

                case 3:

                    fieldCategory = new string[]
                    {
                        "CategoryMaker",
                        "FieldOne",
                        "FieldTwo",
                        "FieldThree"
                    };
                    fieldValue = new string[]
                    {
                        Properties.Settings.Default.userEmail,
                        safe.Fields[0],
                        safe.Fields[1],
                        safe.Fields[2]
                    };

                    break;

                case 4:

                    fieldCategory = new string[]
                    {
                        "CategoryMaker",
                        "FieldOne",
                        "FieldTwo",
                        "FieldThree",
                        "FieldFour",
                    };
                    fieldValue = new string[]
                    {
                        Properties.Settings.Default.userEmail,
                        safe.Fields[0],
                        safe.Fields[1],
                        safe.Fields[2],
                        safe.Fields[3]
                    };

                    break;

                case 5:

                    fieldCategory = new string[]
                    {
                        "CategoryMaker",
                        "FieldOne",
                        "FieldTwo",
                        "FieldThree",
                        "FieldFour",
                        "FieldFive"
                    };
                    fieldValue = new string[]
                    {
                        Properties.Settings.Default.userEmail,
                        safe.Fields[0],
                        safe.Fields[1],
                        safe.Fields[2],
                        safe.Fields[3],
                        safe.Fields[4]
                    };

                    break;

                case 6:

                    fieldCategory = new string[]
                    {
                        "CategoryMaker",
                        "FieldOne",
                        "FieldTwo",
                        "FieldThree",
                        "FieldFour",
                        "FieldFive",
                        "FieldSix"
                    };
                    fieldValue = new string[]
                    {
                        Properties.Settings.Default.userEmail,
                        safe.Fields[0],
                        safe.Fields[1],
                        safe.Fields[2],
                        safe.Fields[3],
                        safe.Fields[4],
                        safe.Fields[5]
                    };

                    break;
            }

            // Заносим в базу категорию
            WorkingScripts.DateBase.InsertData("Category", fieldCategory, fieldValue);
            // Собираем данные
            int catID = WorkingScripts.DateBase.GetLastIDFromCategory();
            int userID = WorkingScripts.DateBase.GetUserID(Properties.Settings.Default.userEmail);
            string[] value = new string[]
            {
                safe.SafeName,
                userID.ToString(),
                catID.ToString()
            };
            // Заносим в базу сейф
            WorkingScripts.DateBase.InsertData("Safe", new string[] { "SafeName", "User_ID", "Category_ID" }, value);
        }

        #endregion

        #region Сериализация
        // TODO: Вынести всю эту хуйню в отдельный класс

        //public void SerializeActiveSafe()
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    string path = Directory.GetCurrentDirectory()
        //        .Remove(Directory.GetCurrentDirectory().Length - 10) + @"\SerializeObject\activeSafe.dat";
        //    using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        //    {
        //        formatter.Serialize(fs, activeSafe);
        //    }
        //}

        //public void DeserializeActiveSafe()
        //{
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    string path = Directory.GetCurrentDirectory()
        //        .Remove(Directory.GetCurrentDirectory().Length - 10) + @"\SerializeObject\activeSafe.dat";
        //    using (var fs = new FileStream(path, FileMode.OpenOrCreate))
        //    {
        //        activeSafe = (Safe)formatter.Deserialize(fs);
        //    }
        //}

        //private void DeleteSerializeObject()
        //{
        //    string path = Directory.GetCurrentDirectory()
        //        .Remove(Directory.GetCurrentDirectory().Length - 10) + @"\SerializeObject\activeSafe.dat";
        //    if (File.Exists(path))
        //        File.Delete(path);
        //}

        //private bool ExistsSerializeObject()
        //{
        //    string path = Directory.GetCurrentDirectory()
        //        .Remove(Directory.GetCurrentDirectory().Length - 10) + @"\SerializeObject\activeSafe.dat";
        //    return File.Exists(path) ? true : false;
        //}

        #endregion

        #region Панель сейфа

        /// <summary>
        /// Показывавает сейф изнутри
        /// </summary>
        /// <param name="safe">Объект класса</param>
        public void ShowSafeItemView(Safe safe)
        {
            // Ставим название сейфа
            safeItemView_SafeName.Text = safe.SafeName;
            // Ставим создателя сейфа
            safeItemView_SafeCreatorPerson.Text = safe.Creator;
            // Заполняем поля
            FillFieldInSafeView(safe.Fields);
            // Показываем панель
            safeItemView.Visible = true;
            // Обновляем хук активного сейфа
            this.activeSafe = safe;
        }

        /// <summary>
        /// Заполняет поля панели
        /// </summary>
        /// <param name="list">список полей</param>
        public void FillFieldInSafeView(List<string> list)
        {
            for (int i = 1; i <= list.Count; i++)
            {
                safeItemView.Controls["safeItemView_Field" + i].Text = list[i - 1];
                safeItemView.Controls["safeItemView_Field" + i].Visible = true;
            }
        }

        /// <summary>
        /// Скрывает поля в сейфе
        /// </summary>
        public void HideFieldInSafeView()
        {
            for (int i = 1; i < 7; i++)
            {
                safeItemView.Controls["safeItemView_Field" + i].Visible = false;
            }
        }

        /// <summary>
        ////Передает фокус на сейф
        /// </summary>
        /// <param name="safe"></param>
        public void FocusedSafe(Safe safe)
        {
            // Чистим список элементов на панели отображения итемов сейфа
            safeItemView_ItemPanel.Controls.Clear();
            // Показываем сейф
            ShowSafeItemView(safe);
            foreach (var item in safeList.Controls)
            {
                if ((item as Label).Text == safe.SafeName)
                {
                    (item as Label).ForeColor = Color.FromArgb(20, 131, 59);
                }
            }
        }

        /// <summary>
        /// Возвращает шрифт для сейфа
        /// </summary>
        private Font GetFontForFolder() => new Font(pr.Families[3], 11);

        /// <summary>
        ///  Получаем числовой показателя для следующего лейбла / Объекта сейфа
        /// </summary>
        private int GetLocationForFolder()
        {
            // Если количество элементов в списке контролов
            // равно нулю, то возвращаем позицию первого контрола
            if (safeItemView_ItemPanel.Controls.Count == 0)
                return 5;
            // Иначе возвращаем позицию в результате расчета
            // позиции последнего контрола в списке
            else
                return safeItemView_ItemPanel.Controls[safeItemView_ItemPanel.Controls.Count - 1].Location.Y + 50;
        }

        /// <summary>
        /// Получает количество папок
        /// </summary>
        private int GetFolderCount()
        {
            int i = 0;
            foreach (var item in safeItemView_ItemPanel.Controls)
            {
                if ((item as Panel).Controls["Mark"].Text == "folder")
                    i++;
            }
            return i;
        }

        /// <summary>
        /// Показывает панель создания папки
        /// </summary>
        public void ShowAddFolderForm()
        {
            var newFolder = new CustomControls.AddFolder()
            {
                Owner = this
            }.ShowDialog();
        }

        /// <summary>
        /// Заполняет список папок в активном сейфе
        /// </summary>
        public void FillFolderList()
        {
            // Заполняем список папок
            // Передаем в параметры запроса объект активного сейфа
            this.folderCollectionInActiveSafe = WorkingScripts.DateBase.GetFolderList(activeSafe);

            // REF: Очищаем список папок
            // TODO: Переделать, тк будут очищаться и итемы
            safeItemView_ItemPanel.Controls.Clear();

            // Создаем контролы на панели
            foreach (var item in folderCollectionInActiveSafe)
            {
                safeItemView_ItemPanel.Controls.Add(
                    NewFolder.CreateNewFolder(safeItemView_ItemPanel,
                    GetFolderCount(), GetFontForFolder(), item, GetLocationForFolder())
                );
            }
        }

        /// <summary>
        /// Создает папку
        /// </summary>
        /// <param name="folder"></param>
        public void CreateFolder(Folder folder)
        {
            //CreateFolder(new Folder("Соска", Properties.Settings.Default.userEmail));

            safeItemView_ItemPanel.Controls.Add(
                NewFolder.CreateNewFolder(safeItemView_ItemPanel,
                GetFolderCount(), GetFontForFolder(), folder, GetLocationForFolder())
            );

            // Записываем данные в базу
            var values = new string[]
            {
                folder.FolderName,
                activeSafe.getSafeID().ToString()
            };
            DateBase.InsertData("Folder", new string[] { "FolderName", "Safe_ID"}, values);

            // Добавляем папку в список
            folderCollectionInActiveSafe.Add(folder);
        }

        #endregion

        #endregion

        #region Построение интефейса

        /// <summary>
        /// Строит верхнее меню
        /// </summary>
        private void CreateTopMenu()
        {
            // Ставим плейсхолдер
            Animation.Placeholder.addPlaceholder(searchText, "Поиск", Color.FromArgb(210, 210, 210), Color.FromArgb(120, 120, 120));
            // Событие при изменении текста в поле поиска
            searchText.TextChanged += (f, a) =>
            {
                // Если нет слова запроса, то скрываем кнопочку очистки текста
                if (searchText.Text == "Поиск" || searchText.Text == string.Empty)
                {
                    textLogoMain.Focus();
                    searchTextBreak.Visible = false;
                }
                // Если нет слова запроса, то показываем кнопочку очистки текста
                else
                    searchTextBreak.Visible = true;
            };
            // Событие при клике на поле поиска и передаем на него фокус
            searchText.Click += (f, a) =>
            {
                // Закрываем все открытые окна
                ClearScreenOfWindow();

                searchText.Focus();
            };
            // Событие при клике на кнопочку очитски поля поиска
            searchTextBreak.Click += (f, a) =>
            {
                // Передаем фокус на поле
                searchText.Focus();
                // Скрываем кнопку
                searchTextBreak.Visible = false;
                // Обнуляем поле текста
                searchText.Text = string.Empty;
            };
            // Показываем email
            if (Properties.Settings.Default.userEmail != string.Empty && Properties.Settings.Default.userPassword != string.Empty)
                // Записываем email
                WriteEmail();
            
            // Событие при клике по иконке и надписи email'a
            emailText.Click += (f, a) =>
            {
                // Закрываем все открытые окна
                ClearScreenOfWindow();
                // Передаем фокус
                emailText.Focus();

                // Если меню активно
                if (!emailRightSideMenu)
                {
                    // Меню активно
                    emailRightSideMenu = true;
                    // Меняем иконку у email'a
                    emailIcon.Image = Properties.Resources.emailIconGreenUp;
                    // Меняем цвет у email'a
                    emailText.ForeColor = Color.FromArgb(29, 185, 84);
                    // Хук на количество экземпляров меню
                    countOpenMenu++;

                    // Показываем меню
                    if (countOpenMenu == 1)
                        // Показываем меню
                        OpenRightSideMenu();
                }
                // Если меню не активно
                else
                {
                    // Меню не активно
                    emailRightSideMenu = false;
                    // Меняем иконку у email'a
                    emailIcon.Image = Properties.Resources.emailIconGrayDown;
                    // Меняем цвет у email'a
                    emailText.ForeColor = Color.FromArgb(120, 120, 120);
                    // Хук на количество экземпляров меню
                    countOpenMenu--;
                    // Скрываем меню
                    CloseRightSideMenu();
                }
            };
            emailIcon.Click += (f, a) =>
            {
                // Закрываем все открытые окна
                ClearScreenOfWindow();
                // Передаем фокус
                emailText.Focus();

                if (!emailRightSideMenu)
                {
                    // Меню активно
                    emailRightSideMenu = true;
                    // Меняем иконку у email'a
                    emailIcon.Image = Properties.Resources.emailIconGreenUp;
                    // Меняем цвет у email'a
                    emailText.ForeColor = Color.FromArgb(29, 185, 84);
                    // Хук на количество экземпляров меню
                    countOpenMenu++;

                    // Показываем меню
                    if (countOpenMenu < 2)
                        // Показываем меню
                        OpenRightSideMenu();
                }
                else
                {
                    // Меню не активно
                    emailRightSideMenu = false;
                    // Меняем иконку у email'a
                    emailIcon.Image = Properties.Resources.emailIconGrayDown;
                    // Меняем цвет у email'a
                    emailText.ForeColor = Color.FromArgb(120, 120, 120);
                    // Хук на количество экземпляров меню
                    countOpenMenu--;
                    // Скрываем меню
                    CloseRightSideMenu();
                }
            };
            // Событие при наведении на иконку и надпись email'a
            emailText.MouseEnter += (f, a) =>
            {
                // Если меню не активно
                if (!emailRightSideMenu)
                {
                    // Меняем цвет текста
                    emailText.ForeColor = Color.FromArgb(29, 185, 84);
                    // Меняем иконку
                    emailIcon.Image = Properties.Resources.emailIconGreenDown;
                }
            };
            emailText.MouseLeave += (f, a) =>
            {
                // Если меню не активно
                if (!emailRightSideMenu)
                {
                    // Меняем цвет текста
                    emailText.ForeColor = Color.FromArgb(120, 120, 120);
                    // Меняем иконку
                    emailIcon.Image = Properties.Resources.emailIconGrayDown;
                }
            };
            emailText.MouseDown += (f, a) =>
            {
                emailText.ForeColor = Color.FromArgb(70, 70, 70);
                if (emailRightSideMenu)
                    emailIcon.Image = Properties.Resources.emailIconDarkGrayUp;
                else
                    emailIcon.Image = Properties.Resources.emailIconDarkGrayDown;
            };
            emailText.MouseUp += (f, a) =>
            {
                if (emailRightSideMenu)
                    emailText.ForeColor = Color.FromArgb(29, 185, 84);
                else
                    emailText.ForeColor = Color.FromArgb(120, 120, 120);
            };

            emailIcon.MouseEnter += (f, a) =>
            {
                // Если меню не активно
                if (!emailRightSideMenu)
                {
                    // Меняем цвет текста
                    emailText.ForeColor = Color.FromArgb(29, 185, 84);
                    // Меняем иконку
                    emailIcon.Image = Properties.Resources.emailIconGreenDown;
                }
            };
            emailIcon.MouseLeave += (f, a) =>
            {
                // Если меню не активно
                if (!emailRightSideMenu)
                {
                    // Меняем цвет текста
                    emailText.ForeColor = Color.FromArgb(120, 120, 120);
                    // Меняем иконку
                    emailIcon.Image = Properties.Resources.emailIconGrayDown;
                }
            };
            emailIcon.MouseDown += (f, a) =>
            {
                emailText.ForeColor = Color.FromArgb(70, 70, 70);
                if (emailRightSideMenu)
                    emailIcon.Image = Properties.Resources.emailIconDarkGrayUp;
                else
                    emailIcon.Image = Properties.Resources.emailIconDarkGrayDown;
            };
            emailIcon.MouseUp += (f, a) =>
            {
                if (emailRightSideMenu)
                    emailText.ForeColor = Color.FromArgb(29, 185, 84);
                else
                    emailText.ForeColor = Color.FromArgb(120, 120, 120);
            };
        }

        /// <summary>
        /// Строим боковое левое меню
        /// </summary>
        private void CreateLeftSide()
        {
            // Если список сейфов скрыт
            if (Properties.Settings.Default.hideSafeList)
            {
                // Меняем иконку
                hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGrayRight;
                // Скрываем
                safeList.Visible = false;
            }
            // Делаем КАПС
            leftSideLogoLabel.Text = leftSideLogoLabel.Text.ToUpper();

            // Событие при наведении на лого-лейбл на левой панели
            leftSideLogoLabel.MouseEnter += (f, a) =>
            {
                // Меняем цвет текста
                leftSideLogoLabel.ForeColor = Color.FromArgb(29, 185, 84);
                // Если мы скрыли список сейфов
                if (Properties.Settings.Default.hideSafeList)
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenRight;
                else
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenDown;

            };
            leftSideLogoLabel.MouseLeave += (f, a) =>
            {
                // Меняем цвет текста
                leftSideLogoLabel.ForeColor = Color.FromArgb(120, 120, 120);
                // Если мы скрыли список сейфов
                if (Properties.Settings.Default.hideSafeList)
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGrayRight;
                else
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGrayDown;
            };

            hideSafeListIcon.MouseEnter += (f, a) =>
            {
                // Меняем цвет текста
                leftSideLogoLabel.ForeColor = Color.FromArgb(29, 185, 84);
                // Если мы скрыли список сейфов
                if (Properties.Settings.Default.hideSafeList)
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenRight;
                else
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenDown;
            };
            hideSafeListIcon.MouseLeave += (f, a) =>
            {
                // Меняем цвет текста
                leftSideLogoLabel.ForeColor = Color.FromArgb(120, 120, 120);
                // Если мы скрыли список сейфов
                if (Properties.Settings.Default.hideSafeList)
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGrayRight;
                else
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGrayDown;
            };

            leftSideLogoLabel.MouseDown += (f, a) =>
            {
                leftSideLogoLabel.ForeColor = Color.FromArgb(70, 70, 70);

                if (Properties.Settings.Default.hideSafeList)
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconDarkGrayRight;
                else
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconDarkGrayDown;
            };
            leftSideLogoLabel.MouseUp += (f, a) =>
            {
                leftSideLogoLabel.ForeColor = Color.FromArgb(29, 185, 84);

                if (Properties.Settings.Default.hideSafeList)
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenRight;
                else
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenDown;
            };

            // Событие при клике на лого-лейбл на левой панели
            leftSideLogoLabel.Click += (f, a) =>
            {
                // Закрываем все открытые окна
                ClearScreenOfWindow();

                leftSideLogoLabel.Focus();

                // Если мы скрыли список сейфов
                if (Properties.Settings.Default.hideSafeList)
                {
                    // Сохраняем параметр 
                    Properties.Settings.Default.hideSafeList = false;
                    Properties.Settings.Default.Save();

                    // Показываем список сейфов
                    safeList.Visible = true;
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenDown;
                }
                else
                {
                    // Сохраняем параметр
                    Properties.Settings.Default.hideSafeList = true;
                    Properties.Settings.Default.Save();

                    // Скрываем список сейфов
                    safeList.Visible = false;
                    hideSafeListIcon.Image = Properties.Resources.hideSafeListIconGreenRight;
                }
            };

            // Событие при наведении на иконку создания сейфа
            createSafeIcon.MouseEnter += (f, a) => createSafeIcon.Image = Properties.Resources.iconPlusGreen;
            createSafeIcon.MouseLeave += (f, a) => createSafeIcon.Image = Properties.Resources.iconPlusGray;
            createSafeIcon.MouseDown += (f, a) => createSafeIcon.Image = Properties.Resources.iconPlusDarkGray;
            createSafeIcon.MouseUp += (f, a) => createSafeIcon.Image = Properties.Resources.iconPlusGreen;

            // Событие при клике на иконку создания сейфа
            createSafeIcon.Click += (f, a) =>
            {
                createSafeIcon.Focus();
                OpenSafePanel();
            };

            // Событие при наведении на кнопку создания сейфа
            createSafeButton.MouseEnter += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(29, 185, 84);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGreen;
            };
            createSafeButton.MouseLeave += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(120, 120, 120);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGray;
                leftSideSeparator2.BackColor = Color.FromArgb(40, 40, 40);
            };

            createSafeButtonLabel.MouseEnter += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(29, 185, 84);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGreen;
            };
            createSafeButtonLabel.MouseLeave += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(120, 120, 120);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGray;
            };

            createSafeButtonIcon.MouseEnter += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(29, 185, 84);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGreen;
            };
            createSafeButtonIcon.MouseLeave += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(120, 120, 120);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGray;
            };

            // Событие при нажатии на кнопку создания сейфа
            createSafeButton.MouseDown += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(70, 70, 70);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusDarkGray;
                leftSideSeparator2.BackColor = Color.FromArgb(30, 30, 30);
            };
            createSafeButtonLabel.MouseDown += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(70, 70, 70);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusDarkGray;
                leftSideSeparator2.BackColor = Color.FromArgb(30, 30, 30);
            };
            createSafeButtonIcon.MouseDown += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(70, 70, 70);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusDarkGray;
                leftSideSeparator2.BackColor = Color.FromArgb(30, 30, 30);
            };
            createSafeButton.MouseUp += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(29, 185, 84);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGreen;
                leftSideSeparator2.BackColor = Color.FromArgb(40, 40, 40);
            };
            createSafeButtonLabel.MouseUp += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(29, 185, 84);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGreen;
                leftSideSeparator2.BackColor = Color.FromArgb(40, 40, 40);
            };
            createSafeButtonIcon.MouseUp += (f, a) =>
            {
                createSafeButtonLabel.ForeColor = Color.FromArgb(29, 185, 84);
                createSafeButtonIcon.Image = Properties.Resources.iconPlusGreen;
                leftSideSeparator2.BackColor = Color.FromArgb(40, 40, 40);
            };

            // Событие при клике на снопку создания сейфа
            createSafeButton.Click += (f, a) =>
            {
                createSafeButton.Focus();
                OpenSafePanel();
            };
            createSafeButtonLabel.Click += (f, a) =>
            {
                createSafeButton.Focus();
                OpenSafePanel();
            };
            createSafeButtonIcon.Click += (f, a) =>
            {
                createSafeButton.Focus();
                OpenSafePanel();
            };
        }

        /// <summary>
        ////Строим центр
        /// </summary>
        private void CreateCenter()
        {
            // Событие наведения и нажатия кнопки создания папки
            safeItemView_AddFolder.MouseEnter += (f, a) => 
                safeItemView_AddFolder.Image = Properties.Resources.addFolderGreen;
            safeItemView_AddFolder.MouseLeave += (f, a) =>
                safeItemView_AddFolder.Image = Properties.Resources.addFolderGray;
            safeItemView_AddFolder.MouseDown += (f, a) =>
                safeItemView_AddFolder.Image = Properties.Resources.addFolderDarkGray;
            safeItemView_AddFolder.MouseUp += (f, a) =>
                safeItemView_AddFolder.Image = Properties.Resources.addFolderGreen;

            // Событие наведения и нажатия кнопки действия (Act)
            safeItemView_Act.MouseEnter += (f, a) =>
                safeItemView_Act.Image = Properties.Resources.actGreen;
            safeItemView_Act.MouseLeave += (f, a) =>
                safeItemView_Act.Image = Properties.Resources.actGray;
            safeItemView_Act.MouseDown += (f, a) =>
                safeItemView_Act.Image = Properties.Resources.actDarkGreen;
            safeItemView_Act.MouseUp += (f, a) =>
                safeItemView_Act.Image = Properties.Resources.actGreen;

            // Наведение и нажатие на кнопку "Добавить" на панели элементов сейфа
            safeItemView_AddItem.MouseEnter += (f, a) =>
            {
                safeItemView_AddItem.Back = Color.FromArgb(30, 215, 96);
            };
            safeItemView_AddItem.MouseLeave += (f, a) =>
            {
                safeItemView_AddItem.Back = Color.FromArgb(29, 185, 84);
            };
            safeItemView_AddItem.MouseDown += (f, a) =>
            {
                safeItemView_AddItem.Back = Color.FromArgb(20, 131, 59);
            };
            safeItemView_AddItem.MouseUp += (f, a) =>
            {
                safeItemView_AddItem.Back = Color.FromArgb(30, 215, 96);
            };

            safeItemView_Hide.MouseEnter += (f, a) => 
            {
                safeItemView_Hide.Image = Properties.Resources.closePanelViewGreen;
            };
            safeItemView_Hide.MouseLeave += (f, a) =>
            {
                safeItemView_Hide.Image = Properties.Resources.closePanelViewGray;
            };
            safeItemView_Hide.MouseDown += (f, a) =>
            {
                safeItemView_Hide.Image = Properties.Resources.closePanelViewDarkGray;
            };
            safeItemView_Hide.MouseUp += (f, a) =>
            {
                safeItemView_Hide.Image = Properties.Resources.closePanelViewGreen;
            };

            safeItemView_AddFolder.Click += (f, a) => ShowAddFolderForm();
            safeItemView_Hide.Click += (f, a) => 
            {
                foreach (var item in safeList.Controls)
                {
                    (item as Label).ForeColor = Color.White;
                }
                safeItemView.Visible = false;
            };
        }

        #endregion


        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Main()
        {
            InitializeComponent();

            // Получаем строку подключения
            ConnectWithDB();
            
            // Используем шрифты
            UseFonts();
            // Строим верхню панель
            CreateTopMenu();
            // Строим левую панель
            CreateLeftSide();
            // Строим центр
            CreateCenter();

            #region Минимальные действия при нажатии на кнопки и т.д

            // Клик по кнопке открытия панели входа (loginButton)
            loginButton.Click += (f, a) => 
            {
                // Если панель не видна, то показываем и скрываем другую
                if (login.Visible != true)
                {
                    login.Visible = true;
                    registration.Visible = false;

                    // Передаем фокус на форму для того, чтобы показывались все надписи на плейсхолжерах
                    login.Focus();
                }
            };

            // Клик по кнопке открытия панели регистрации (registrationButton)
            registrationButton.Click += (f, a) =>
            {
                // Если панель не видна, то показываем и скрываем другую
                if (registration.Visible != true)
                {
                    registration.Visible = true;
                    login.Visible = false;

                    // Передаем фокус на форму для того, чтобы показывались все надписи на плейсхолжерах
                    registration.Focus();
                }
            };

            #endregion

            #region Обработка событий

            // Событие при активации приложения
            this.Activated += (f, a) =>
            {
                // Переключаем раскладку клавиатуры
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            };

            // Событие при изменении размера формы
            this.Resize += (f, a) =>
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    // Меняем размер списка сейфов
                    safeList.Height = leftSideSeparator2.Location.Y - 20 - safeList.Location.Y;

                    // Меняем размер поля поиска (searchText)
                    searchText.Size = new Size(700, searchText.Height);
                    // Меняем позицию кнопки очистки текста в поле поиска
                    searchTextBreak.Location = new Point(searchText.Location.X + searchText.Width + 27, searchTextBreak.Location.Y);


                    // Меняем позицию правого меню
                    rightSideMenu.Location = new Point(this.Location.X + (emailIcon.Location.X + emailIcon.Width - rightSideMenu.Width),
                        this.Location.Y + (emailIcon.Location.Y + emailIcon.Height + 10));
                }
                else
                {
                    // Меняем размер списка сейфов
                    safeList.Height = leftSideSeparator2.Location.Y - 20 - safeList.Location.Y;

                    // Меняем размер поля поиска (searchText)
                    searchText.Size = new Size(270, searchText.Height);
                    // Меняем позицию кнопки очистки текста в поле поиска
                    searchTextBreak.Location = new Point(searchText.Location.X + searchText.Width + 27, searchTextBreak.Location.Y);

                    // Меняем позицию правого меню
                    rightSideMenu.Location = new Point(this.Location.X + (emailIcon.Location.X + emailIcon.Width - rightSideMenu.Width),
                        this.Location.Y + (emailIcon.Location.Y + emailIcon.Height + 10));
                }

                // Меняем размер и позицию панели отображения элементов сейфа
                safeItemView.Location = new Point(safeItemView.Location.X, safeItemView.Location.Y);
                safeItemView.Size = new Size(this.Width - logoSeparatorVertical.Location.X - 40,
                    this.Height - logoSeparatorHorizontal.Location.Y - 40);

                // Меняем размер сепаратора у меня на панели отображения элементов сейфа
                safeItemView_MenuSeparator.Width = safeItemView_AddItem.Location.X + 95;
                // Меняем ширину и высоту панели элементов в сейфе
                safeItemView_ItemPanel.Width = safeItemView_MenuSeparator.Width;
                safeItemView_ItemPanel.Height = safeItemView.Height - safeItemView_ItemPanel.Location.Y - 30;

                // Меняем размер элементов на панели сейфа
                if (safeItemView_ItemPanel.Controls.Count != 0)
                {
                    foreach (var item in safeItemView_ItemPanel.Controls)
                    {
                        (item as Panel).Width = safeItemView.Width - 2;
                    }
                }

                // Если панель видна
                if (startPanel.Visible == true)
                {
                    // Меняем размер контрола регистрации (registration)
                    // Вычитаем поинты для того, чтобы при изменении размера формы и возвращении
                    // в нормальное сострояние панелька встала на место
                    registration.Size = new Size(this.Width, this.Height - 80);

                    // Меняем размер контрола регистрации (login)
                    // Вычитаем поинты для того, чтобы при изменении размера формы и возвращении
                    // в нормальное сострояние панелька встала на место
                    login.Size = new Size(this.Width, this.Height - 80);

                    // Меняем размер стартовой панели (startPanel)
                    // Вычитаем поинты для того, чтобы при изменении размера формы и возвращении
                    // в нормальное сострояние панелька встала на место
                    startPanel.Size = new Size(this.Width, this.Height - 40);

                    // Меняем размер разделяющей полосы (separator1)
                    separator1.Size = new Size(this.Width, 1);
                }
                else
                {
                    // Меняем размер разделяющей полосы (logoSeparator)
                    logoSeparatorHorizontal.Size = new Size(this.Width, 1);
                    // Меняем размер разделяющей полосы (logoSeparator)
                    logoSeparatorVertical.Size = new Size(1, this.Height);
                }
            };

            // Событие при изменении видимости стартовой панели (startPanel)
            startPanel.VisibleChanged += (f, a) => 
            {
                // Если панель видна
                if (!startPanel.Visible)
                {
                    // Показываем лого
                    textLogoMain.Visible = true;
                    logoSeparatorHorizontal.Visible = true;
                    logoSeparatorVertical.Visible = true;

                    // Меняем размер разделяющей полосы (logoSeparator)
                    logoSeparatorHorizontal.Size = new Size(this.Width, 1);
                    logoSeparatorVertical.Size = new Size(1, this.Height);

                    // Заполняем поле с email'ом
                    WriteEmail();

                    // Если размер формы максимальный
                    if (this.WindowState == FormWindowState.Maximized)
                        // Меняем размер списка с сейфами
                        safeList.Height = 825;

                    // REF: Заполняем список сейфов при первом входе
                    FillSafeList();
                }
                else
                {
                    // Убираем лого
                    textLogoMain.Visible = false;
                    logoSeparatorHorizontal.Visible = false;
                    logoSeparatorVertical.Visible = false;
                }
            };

            // Событие при перемещении формы
            this.Move += (f, a) => 
            {
                // Меняем позицию правого меню
                rightSideMenu.Location = new Point(this.Location.X + (emailIcon.Location.X + emailIcon.Width - rightSideMenu.Width),
                    this.Location.Y + (emailIcon.Location.Y + emailIcon.Height + 10));
                // Меняем позицию меню создания сейфа
                createSafe.Location = new Point(this.Location.X + (this.Width / 2 - createSafe.Width / 2),
                    this.Location.Y + (this.Height / 2 - createSafe.Height / 2));
            };

            // Событие при закрытие формы
            this.FormClosing += (f, a) => 
            {
                // Если пользователь не пожелал остаться в системе
                if (!Properties.Settings.Default.saveSession)
                {
                    // Обнуляем данные
                    Properties.Settings.Default.userEmail = string.Empty;
                    Properties.Settings.Default.userPassword = string.Empty;
                    Properties.Settings.Default.Save();
                }

                // Скрываем окно просмотра содержимого сейфа
                safeItemView.Visible = false;
            };

            #endregion

            #region Стилистическое описание кнопок и т.д (Ховеры, иконки)

            // Наведение на кнопку войти (loginButton)
            loginButton.MouseEnter += (f, a) => loginButton.ForeColor = Color.FromArgb(29, 185, 84);
            loginButton.MouseLeave += (f, a) => loginButton.ForeColor = Color.White;

            // Наведение на кнопку регистрация (registrationButton)
            registrationButton.MouseEnter += (f, a) => 
            {
                registrationButton.ForeColor = Color.FromArgb(29, 185, 84);
                registrationButton.Back = Color.FromArgb(18, 18, 18);
            };
            registrationButton.MouseLeave += (f, a) =>
            {
                registrationButton.ForeColor = Color.White;
                registrationButton.Back = Color.FromArgb(29, 185, 84);
            };

            // Наведение на логотип (textLogo)
            textLogo.MouseEnter += (f, a) => 
            {
                textLogo.ForeColor = Color.FromArgb(29, 185, 84);
                separator1.BackColor = Color.FromArgb(65, 65, 65);
            };
            textLogo.MouseLeave += (f, a) =>
            {
                textLogo.ForeColor = Color.FromArgb(255, 255, 255);
                separator1.BackColor = Color.FromArgb(40, 40, 40);
            };

            // Наведение на логотип (textLogo)
            textLogoMain.MouseEnter += (f, a) =>
            {
                textLogoMain.ForeColor = Color.FromArgb(29, 185, 84);
            };
            textLogoMain.MouseLeave += (f, a) =>
            {
                textLogoMain.ForeColor = Color.FromArgb(255, 255, 255);
            };

            #endregion

        }


        #region Методы

        // Событе при загрузке приложения
        private void Main_Load(object sender, EventArgs e)
        {
            // Если данные пользователя не сохранены, то
            if (Properties.Settings.Default.userEmail == string.Empty ||
                Properties.Settings.Default.userPassword == string.Empty)
            {
                // Показываем панель входа / регистрации
                startPanel.Visible = true;
                startPanel.Location = new Point(1, 33);
            }
            // Если показываем элементы
            else
            {
                //MessageBox.Show(Properties.Settings.Default.userEmail + "\n" + Properties.Settings.Default.userPassword);
                // Показываем лого
                textLogoMain.Visible = true;
                logoSeparatorHorizontal.Visible = true;
                logoSeparatorVertical.Visible = true;

                // Меняем размер разделяющей полосы (logoSeparator)
                logoSeparatorHorizontal.Size = new Size(this.Width, 1);
                logoSeparatorVertical.Size = new Size(1, this.Height);

                // REF: Заполняем список сейфов при обычном запуске
                FillSafeList();
            }
        }

        // Метод, который открывает панель создания сейфа
        private void OpenSafePanel()
        {
            // Если не октрыто ни одной панели создания сейфа
            if (countOpenMenuCreateSafe == 0)
            {
                // Создаем экземпляр панели
                createSafe = new CustomControls.CreateSafeForm();
                // Ставим права
                createSafe.Owner = this;
                // Показываем
                createSafe.Show();
                // Меняем позицию
                createSafe.Location = new Point(this.Location.X + (this.Width / 2 - createSafe.Width / 2),
                    this.Location.Y + (this.Height / 2 - createSafe.Height / 2));
            }
            // Инкрементируем счетчик открытых панелей
            countOpenMenuCreateSafe++;
        }

        /// <summary>
        /// Получаем список сейфов пользователя
        /// </summary>
        private void FillSafeList()
        {
            // Получаем коллекцию сейфов
            this.safeCollection = WorkingScripts.DateBase.GetSafeList();

            foreach (var item in safeCollection)
            {
                // Создаем контрол на левой панели
                // Передаем наименование сейфа и позицию исходя из последнего элемента
                Control control = WorkingScripts.NewSafe.CreateNewSafe
                    (safeList, this.GetCountSafe, GetFontForSafe(), item, GetLocationForSafe());

                // REF: При клике на сейф
                control.Click += (f, a) => 
                {
                    // Обновляем хук
                    this.activeSafe = item;
                    // Скрываем панель
                    safeItemView.Visible = false;
                    // Чистим поля
                    HideFieldInSafeView();
                    // Заполняем сейф
                    ShowSafeItemView(item);
                    // Заполняем список папок в активном сейфе
                    FillFolderList();
                };
                // Добавляем в панель контролы
                safeList.Controls.Add(control);
            }
        }

        #endregion

    }
}
