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
        public Control CreateNewSafe(string SafeName, int LocationY)
        {
            var control = new Label
            {
                ForeColor = Color.White,
                Location = new Point(1, LocationY),
                Text = SafeName,
                AutoSize = false,
                Width = 150
            };

            return control;
        }
    }
}
