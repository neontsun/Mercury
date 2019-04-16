using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.Case
{
    public class Safe
    {
        // Наименование сейфа
        public string SafeName { get; set; }
        // Массив полей
        public string[] Fields { get; set; }



        public Safe(string SafeName, string[] Fields)
        {
            this.SafeName = SafeName;
            this.Fields = Fields;
        }
    }
}
