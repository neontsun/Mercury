using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercury.WorkingScripts
{
    public static class NewItem
    {
        public static Control CreateNewItem(Control parent, int folderCount, Font font, Item item, int LocationY)
        {
            // Создаем контрол
            var control = new Panel
            {
                Location = new Point(0, LocationY),
                AutoSize = false,
                Width = parent.Width - 2,
                Height = 45,
                Cursor = Cursors.Hand,
                Parent = parent,
                Name = "Item_" + folderCount
            };

            var field1 = new Label
            {
                Location = new Point(40, 14),
                Text =  item.ItemField[0].Length < 12 ? item.ItemField[0] : item.ItemField[0].Remove(12) + "...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };
            var field2 = new Label
            {
                Location = new Point(field1.Location.X + 130, 14),
                Text = item.ItemField[1].Length < 12 ? item.ItemField[1] : item.ItemField[1].Remove(12) + "...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };
            var field3 = new Label
            {
                Location = new Point(field2.Location.X + 130, 14),
                Text = item.ItemField[2].Length < 12 ? item.ItemField[2] : item.ItemField[2].Remove(12) + "...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };
            var field4 = new Label
            {
                Location = new Point(field3.Location.X + 130, 14),
                Text = item.ItemField[3].Length < 12 ? item.ItemField[3] : item.ItemField[3].Remove(12) + "...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };
            var field5 = new Label
            {
                Location = new Point(field4.Location.X + 130, 14),
                Text = item.ItemField[4].Length < 12 ? item.ItemField[4] : item.ItemField[4].Remove(12) + "...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };
            var field6 = new Label
            {
                Location = new Point(field5.Location.X + 130, 14),
                Text = item.ItemField[5].Length < 12 ? item.ItemField[5] : item.ItemField[5].Remove(11) + "...",
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };

            var delete = new PictureBox
            {
                Location = new Point(control.Width - 20, 15),
                Size = new Size(16, 16),
                AutoSize = false,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.deleteFolderWhite,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            var mark = new Label
            {
                Location = new Point(delete.Location.X + 100, 17),
                Text = "item",
                AutoSize = true,
                Visible = false,
                Name = "Mark"
            };

            control.Controls.Add(field1);
            control.Controls.Add(field2);
            control.Controls.Add(field3);
            control.Controls.Add(field4);
            control.Controls.Add(field5);
            control.Controls.Add(field6);
            control.Controls.Add(delete);
            control.Controls.Add(mark);
            
            // REF: Удаление папки
            //delete.Click += (f, a) =>
            //{
            //    var par = parent.Parent.Parent;
            //    (par as Main).folderCollectionInActiveSafe.Remove(folder);
            //    (par as Main).DeleteFolder((par as Main).activeSafe.SafeID, folder.FolderID);
            //    (par as Main).ShowSafeItemView((par as Main).activeSafe);
            //};

            control.Resize += (f, a) =>
            {
                control.Width = parent.Width - 2;
                //creator.Location = new Point(control.Width - 250, 17);
                //label.Location = new Point(creator.Location.X - 10 - 60, 17);
                //edit.Location = new Point(creator.Location.X + creator.Width + 75, 15);
                delete.Location = new Point(control.Width - 20, 15);
            };

            return control;
        }
    }
}
