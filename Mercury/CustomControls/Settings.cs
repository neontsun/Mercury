using pivyLab.UserForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercury.CustomControls
{
    public partial class Settings : FormTwo
    {
        public Settings()
        {
            InitializeComponent();

            // Риссуем форму
            FormStyleTwo.PaintForm(this);
        }
    }
}
