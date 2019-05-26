using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    [Serializable]
    public class Safe
    {
        /// <summary>
        /// Наименование сейфа
        /// </summary>
        public string SafeName { get; set; }

        /// <summary>
        /// Массив полей
        /// </summary>
        public List<string> Fields { get; set; }

        /// <summary>
        /// Создатель сейфа
        /// </summary>
        public string Creator { get; set; }
        public int SafeID { get; }

        /// <summary>
        /// Идентификатор сейфа
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="SafeName">Наименование сейфа</param>
        /// <param name="Fields">Массив полей</param>
        public Safe(string SafeName, List<string> Fields, string Creator)
        {
            this.SafeName = SafeName;
            this.Fields = Fields;
            this.Creator = Creator;
        }

        /// <summary>
        /// Возвращает идентификатор сейфа
        /// </summary>
        /// <returns></returns>
        public int getSafeID() => DateBase.GetSafeID(SafeName);
    }
}
