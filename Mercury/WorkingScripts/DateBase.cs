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
        /// Возвращает список сефсов пользователя
        /// </summary>
        public static List<Safe> GetSafeList()
        {
            using (var conn = new SqlConnection(Properties.Settings.Default.stringConnection))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();

                    cmd.CommandText = "SELECT [SafeName], [Email], [FieldOne], [FieldTwo], " +
                                             "[FieldThree], [FieldFour], [FieldFive], [FieldSix] " +
                                      "FROM [Safe] s " +
                                      "INNER JOIN [User] u ON u.[User_ID] = s.[User_ID] " + 
                                      "INNER JOIN [Category] c ON s.[Category_ID] = c.[Category_ID] " +
                                      "WHERE [Email] = @Email";
                    cmd.Parameters.AddWithValue("@Email", Properties.Settings.Default.userEmail);

                    List<Safe> safeCollection = new List<Safe>();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var fields = new List<string>(); 
                        while (reader.Read())
                        {
                            if (reader[2].ToString() != string.Empty)
                                fields.Add(reader[2].ToString());
                            if (reader[3].ToString() != string.Empty)
                                fields.Add(reader[3].ToString());
                            if (reader[4].ToString() != string.Empty)
                                fields.Add(reader[4].ToString());
                            if (reader[5].ToString() != string.Empty)
                                fields.Add(reader[5].ToString());
                            if (reader[6].ToString() != string.Empty)
                                fields.Add(reader[6].ToString());
                            if (reader[7].ToString() != string.Empty)
                                fields.Add(reader[7].ToString());

                            var safe = new Safe(reader[0].ToString(), fields, reader[1].ToString());
                            safeCollection.Add(safe);
                        }
                    }
                    return safeCollection;
                }
            }
        }
    }
}
