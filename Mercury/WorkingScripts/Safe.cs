using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public class Safe
    {
        /// <summary>
        /// Наименование сейфа
        /// </summary>
        public string SafeName { get; set; }

        /// <summary>
        /// Массив полей
        /// </summary>
        public string[] Fields { get; set; }


        /// <summary>
        /// Конструктор формы
        /// </summary>
        /// <param name="SafeName">Наименование сейфа</param>
        /// <param name="Fields">Массив полей</param>
        public Safe(string SafeName, string[] Fields)
        {
            this.SafeName = SafeName;
            this.Fields = Fields;
        }
    }
}
