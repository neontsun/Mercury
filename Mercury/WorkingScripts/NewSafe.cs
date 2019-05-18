using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercury.WorkingScripts
{
    public class NewSafe
    {
        /// <summary>
        /// Наименование сейфа
        /// </summary>
        internal string SafeName { get; set; }

        /// <summary>
        /// Позиция по Y
        /// </summary>
        internal int LocationY { get; set; }



        /// <summary>
        /// Конструктор
        /// </summary>
        public NewSafe(string SafeName, int LocationY)
        {
            // Записываем поля
            this.SafeName = SafeName;
            this.LocationY = LocationY;
        }

        /// <summary>
        /// Создает экземпляр сейфа для показа на панели сейфов
        /// </summary>
        /// <param name="SafeName">Наименование сейфа</param>
        /// <param name="LocationY">Позиция сейфа</param>
        /// <returns>Созданный контрол</returns>
        public Control CreateNewSafe()
        {
            // Создаем контрол
            var control = new Label
            {
                ForeColor = Color.White,
                Location = new Point(1, this.LocationY),
                Text = this.SafeName,
                AutoSize = false,
                Width = 150
            };

            control.Click += (f, a) => 
            {

            };

            // Возвращаем контрол
            return control;
        }
    }
}
