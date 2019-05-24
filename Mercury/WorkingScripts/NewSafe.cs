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
    public static class NewSafe
    {
        
        /// <summary>
        /// Создает экземпляр сейфа для показа на панели сейфов
        /// </summary>
        /// <param name="SafeName">Наименование сейфа</param>
        /// <param name="LocationY">Позиция сейфа</param>
        /// <returns>Созданный контрол</returns>
        public static Control CreateNewSafe(Control parent, int safeCount, Font font, Safe safe, int LocationY)
        {
            // Создаем контрол
            var control = new Label
            {
                ForeColor = Color.White,
                Location = new Point(1, LocationY),
                Text = safe.SafeName,
                AutoSize = false,
                Width = 150,
                Cursor = Cursors.Hand,
                Parent = parent,
                Name = "Safe_" + safeCount,
                Font = font
            };

            control.MouseEnter += (f, a) => 
            {
                if (control.ForeColor != Color.FromArgb(20, 131, 59))
                {
                    control.ForeColor = Color.FromArgb(30, 215, 96);
                }
            };
            control.MouseLeave += (f, a) => 
            {
                if (control.ForeColor != Color.FromArgb(20, 131, 59))
                {
                    control.ForeColor = Color.White;
                }
            };
            control.MouseDown += (f, a) => control.ForeColor = Color.FromArgb(70, 70, 70);
            //control.MouseUp += (f, a) => control.ForeColor = Color.FromArgb(30, 215, 96);

            control.Click += (f, a) => 
            {
                // Передаем фокус
                control.Focus();
                // Получаем список контролов у родителя
                Control[] ctrl = new Control[parent.Controls.Count];
                int i = -1;
                // Перебираем
                foreach (var item in parent.Controls)
                {
                    // Заполняем массив
                    ctrl[++i] = (Control)item;
                }

                if (control.ForeColor != Color.FromArgb(20, 131, 59))
                {
                    // Чистим все контролы
                    foreach (var item in ctrl)
                    {
                        item.ForeColor = Color.White;
                    }
                    // Выделяем
                    control.ForeColor = Color.FromArgb(20, 131, 59);
                }
            };

            // Возвращаем контрол
            return control;
        }
    }
}
