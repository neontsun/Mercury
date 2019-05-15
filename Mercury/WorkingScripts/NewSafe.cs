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
        /// Создает экземпляр сейфа для показа на панели сейфов
        /// </summary>
        /// <param name="SafeName">Наименование сейфа</param>
        /// <param name="LocationY">Позиция сейфа</param>
        /// <returns>Созданный контрол</returns>
        public Control CreateNewSafe(string SafeName, int LocationY)
        {
            // Создаем контрол
            var control = new Label
            {
                ForeColor = Color.White,
                Location = new Point(1, LocationY),
                Text = SafeName,
                AutoSize = false,
                Width = 150
            };

            // Возвращаем контрол
            return control;
        }
    }
}
