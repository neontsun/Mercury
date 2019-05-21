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
        /// <returns></returns>
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
    }
}
