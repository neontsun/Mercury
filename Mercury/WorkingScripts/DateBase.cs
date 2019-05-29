using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public static class DateBase
    {

        /// <summary>
        /// Внесение данных в таблицу БД.
        /// </summary>
        /// <param name="Table">Таблица для внесения.</param>
        /// <param name="Field">Массив полей.</param>
        /// <param name="Value">Массив значений.</param>
        public static void InsertData(string Table, string[] Field, string[] Value)
        {
            // Создаем подключение
            using (var connect = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                // Формируем запрос
                using (var cmd = connect.CreateCommand())
                {
                    // Открываем соединение
                    connect.Open();


                    // Сборка данных в запрос
                    cmd.CommandText = "INSERT INTO [" + Table + "] (";

                    foreach (var ArrEllField in Field)
                    {
                        cmd.CommandText += "[" + ArrEllField + "], ";
                    }
                    cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2);
                    cmd.CommandText += ")";

                    cmd.CommandText += " VALUES (";


                    foreach (var ArrEllValue in Value)
                    {
                        cmd.CommandText += "'" + ArrEllValue + "', ";
                    }
                    cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2);
                    cmd.CommandText += ")";


                    // Отправляем запрос на выполнение
                    cmd.ExecuteNonQuery();
                }
            }
        }


        /// <summary>
        /// Проверка на наличие данных в БД.
        /// КОЛИЧЕСТВО ЭЛЕМЕНТОВ В МАССИВАХ Field и Value ДОЛЖНО СТРОГО СОВПАДАТЬ!
        /// </summary>
        /// <param name="Table">Таблица для проверки.</param>
        /// <param name="Field">Массив полей.</param>
        /// <param name="Value">Массив значений.</param>
        /// <returns>Логический ответ. Вернет true, если в базе присутсвуют данные, false, если нет.</returns>
        public static bool CheckData(string Table, string[] Field, string[] Value)
        {
            // Логический ответ
            bool result = false;

            // Создаем подключение
            using (var connect = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                // Формируем запрос
                using (var cmd = connect.CreateCommand())
                {
                    // Открываем соединение
                    connect.Open();


                    // Начинаем формирование запроса
                    cmd.CommandText = "SELECT ";

                    foreach (var field in Field)
                    {
                        cmd.CommandText += "[" + field + "], ";
                    }
                    cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2);

                    cmd.CommandText += " FROM [" + Table + "] WHERE ";

                    for (int i = 0; i < Field.Length; i++)
                    {
                        cmd.CommandText += Field[i] + " = '" + Value[i] + "' AND ";
                    }
                    cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 4);


                    // Выполняем запрос, а затем возвращаем значение
                    // первого столбца первой записи.
                    // Если данных из запроса нет в БД, то вернется null.
                    var check = cmd.ExecuteScalar();

                    // Проверяем на null
                    if (check != null)
                    {
                        result = true;
                    }
                }
            }

            // Возвращаем результат
            return result;
        }


        /// <summary>
        /// Проверяет существование аккаунта
        /// </summary>
        /// <param name="Table">Таблица.</param>
        /// <param name="Field">Поле проверки. Предположительно Email.</param>
        /// <param name="Value">Проверяемое значение.</param>
        public static bool ExistenceCheck(string Table, string Field, string Value)
        {
            // Переменная результата
            var result = false;

            // Создаем подключение к базе
            using (var connect = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                // Создаем запрос
                using (var cmd = connect.CreateCommand())
                {
                    // Открываем соединение
                    connect.Open();

                    // Формируем запрос
                    cmd.CommandText = "SELECT " + Field + " FROM [" + Table + "] WHERE " + Field + " = '" + Value + "'";

                    // Значение, которое венрулось запросом
                    var request = cmd.ExecuteScalar();

                    // Проверка на существование
                    if (request != null)
                    {
                        result = true;
                    }
                }
            }

            // Возвращаем результат
            return result;
        }

        /// <summary>
        /// Возвращает ID последней записи
        /// </summary>
        /// <param name="Table">Таблица</param>
        public static int GetLastIDFromCategory()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT TOP 1 * FROM [Category] ORDER BY Category_ID DESC";
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Возвращает ID из таблицы User
        /// </summary>
        /// <param name="Table"></param>
        /// <param name="Where"></param>
        public static int GetUserID(string Where)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT [User_ID] FROM [User] WHERE [Email] = @Email";
                    cmd.Parameters.AddWithValue("@Email", Where);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Возвращает список сейфов пользователя
        /// </summary>
        public static List<Safe> GetSafeList()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    
                    cmd.CommandText = "SELECT [SafeName], dbo.GetSafeCreator(us.[Safe_ID]) Creator, us.[Safe_ID], [FieldOne], [FieldTwo], " +
                                             "[FieldThree], [FieldFour], [FieldFive], [FieldSix] " +
                                      "FROM [User-Safe] us " +
                                      "INNER JOIN [Safe] s ON us.[Safe_ID] = s.[Safe_ID] " +
                                      "INNER JOIN [Category] ct ON ct.[Category_ID] = s.[Category_ID] " +
                                      "INNER JOIN [User] u ON u.[User_ID] = us.[User_ID] " +
                                      "WHERE[Email] = @Email"; //  AND [UserIsCreator] = 1
                    cmd.Parameters.AddWithValue("@Email", Properties.Settings.Default.userEmail);

                    List<Safe> safeCollection = new List<Safe>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var fields = new List<string>();
                            for (int i = 3; i < 9; i++)
                            {
                                if (reader[i].ToString() != string.Empty)
                                {
                                    fields.Add(reader[i].ToString());
                                }
                            }
                            //var creator = 
                            var safe = new Safe(reader[0].ToString(), fields, reader[1].ToString());
                            safe.SafeID = (int)reader[2];
                            safeCollection.Add(safe);
                        }
                    }
                    return safeCollection;
                }
            }
        }

        /// <summary>
        /// Возвращает количество членов в сейфе
        /// </summary>
        /// <param name="safeID"></param>
        /// <returns></returns>
        public static int GetCountMembersInSafe(int safeID)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT COUNT(us.[User-Safe_ID]) " +
                                      "FROM [User-Safe] us " +
                                      "WHERE us.[Safe_ID] = @SafeID";
                    cmd.Parameters.AddWithValue("@SafeID", safeID);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Возвращает ID последней записи
        /// </summary>
        /// <param name="Table">Таблица</param>
        public static int GetLastIDFromFolder()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT TOP 1 * FROM [Folder] ORDER BY Folder_ID DESC";
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Возвращает ID последней записи
        /// </summary>
        /// <param name="Table">Таблица</param>
        public static int GetLastIDFromSafe()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT TOP 1 * FROM [Safe] ORDER BY Safe_ID DESC";
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        /// <summary>
        /// Возвращает список папок в активном сейфе
        /// </summary>
        /// <param name="safe"></param>
        public static List<Folder> GetFolderList(Safe safe)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT f.[Folder_ID], [FolderName], [Email] " +
                                      "FROM [Folder-Safe] fs " +
                                      "INNER JOIN [Folder] f ON fs.[Folder_ID] = f.[Folder_ID] " +
                                      "INNER JOIN [User] u ON f.[User_ID] = u.[User_ID] " +
                                      "WHERE fs.[Safe_ID] = @SafeID";
                    cmd.Parameters.AddWithValue("@SafeID", safe.SafeID);

                    List<Folder> folderCollection = new List<Folder>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var folder = new Folder(reader[1].ToString(), reader[2].ToString());
                            folder.FolderID = (int)reader[0];
                            folderCollection.Add(folder);
                        }
                    }
                    return folderCollection;
                }
            }
        }

        /// <summary>
        /// Удаляет сейф
        /// </summary>
        /// <param name="safe"></param>
        public static void DeleteSafe(Safe safe)
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    // TODO: Поправить запрос
                    // При удалении сейфа, если в нем несколько папок, созданных 
                    // разными пользователями, то выскакивает исключение
                    cmd.CommandText = "BEGIN TRANSACTION;" +
                                      "DECLARE @CatID int;" +
                                      "DECLARE @safe int;" +
                                      "DECLARE @FolderID int;" +
                                      "SET @safe = @SafeID;" +
                                      "SET @FolderID = ( " +
                                      "     SELECT fs.[Folder_ID] " +
                                      "     FROM [Folder-Safe] fs " +
                                      "     WHERE fs.[Safe_ID] = @safe " +
                                      ") " +
                                      "SET @CatID = ( " +
                                      "   SELECT ct.[Category_ID] " +
                                      "   FROM [Safe] s " +
                                      "   INNER JOIN [Category] ct ON s.[Category_ID] = ct.[Category_ID] " +
                                      "   WHERE s.[Safe_ID] = @safe " +
                                      ")" +
                                      "DELETE " +
                                      "FROM [User-Safe] " +
                                      "WHERE [Safe_ID] = @safe;" +
                                      "DELETE " +
                                      "FROM [Folder-Safe] " +
                                      "WHERE [Folder_ID] = @FolderID;" +
                                      "DELETE " +
                                      "FROM [Safe] " +
                                      "WHERE [Safe_ID] = @safe;" +
                                      "DELETE " +
                                      "FROM [Category] " +
                                      "WHERE [Category_ID] = @CatID;" +
                                      "DELETE " +
                                      "FROM [Folder] " +
                                      "WHERE [Folder_ID] = @FolderID;" +
                                      "COMMIT;";

                    cmd.Parameters.AddWithValue("@SafeID", safe.SafeID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Внесение данных в таблицу БД.
        /// </summary>
        /// <param name="Table">Таблица для внесения.</param>
        /// <param name="Field">Массив полей.</param>
        /// <param name="Value">Массив значений.</param>
        public static void UpdateSafe(Safe safe, List<string> Values, string safeName)
        {
            // Создаем подключение
            using (var connect = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                // Формируем запрос
                using (var cmd = connect.CreateCommand())
                {
                    // Открываем соединение
                    connect.Open();


                    cmd.CommandText = "DECLARE @CatID int;" +
                                      "SET @CatID = ( " +
                                      "     SELECT s.[Category_ID]" +
                                      "     FROM [Safe] s " +
                                      "     WHERE s.[Safe_ID] = @SafeID " +
                                      ") " +
                                      "UPDATE [Category] " +
                                      "SET [FieldOne] = @ParametersOne, " +
                                      "    [FieldTwo] = @ParametersTwo, " +
                                      "    [FieldThree] = @ParametersThree, " +
                                      "    [FieldFour] = @ParametersFour, " +
                                      "    [FieldFive] = @ParametersFive, " +
                                      "    [FieldSix] = @ParametersSix " +
                                      "WHERE [Category_ID] = @CatID; " +
                                      "UPDATE [Safe] " +
                                      "SET [SafeName] = @SafeName " +
                                      "WHERE [Safe_ID] = @SafeID;";
                    cmd.Parameters.AddWithValue("@SafeID", safe.SafeID);
                    cmd.Parameters.AddWithValue("@SafeName", safeName);
                    cmd.Parameters.AddWithValue("@ParametersOne", Values[0]);
                    cmd.Parameters.AddWithValue("@ParametersTwo", Values[1] != null ? Values[1] : string.Empty);
                    cmd.Parameters.AddWithValue("@ParametersThree", Values[2] != null ? Values[2] : string.Empty);
                    cmd.Parameters.AddWithValue("@ParametersFour", Values[3] != null ? Values[3] : string.Empty);
                    cmd.Parameters.AddWithValue("@ParametersFive", Values[4] != null ? Values[4] : string.Empty);
                    cmd.Parameters.AddWithValue("@ParametersSix", Values[5] != null ? Values[5] : string.Empty);

                    // Отправляем запрос на выполнение
                    cmd.ExecuteNonQuery();

                    //// Сборка данных в запрос
                    //cmd.CommandText = "UPDATE [" + Table + "] SET ";

                    //for (int i = 0; i < Field.Length; i++)
                    //{
                    //    cmd.CommandText += "[" + Field[i] + "] = ";
                    //}
                    //cmd.CommandText = cmd.CommandText.Remove(cmd.CommandText.Length - 2);
                    
                }
            }
        }

    }
}
