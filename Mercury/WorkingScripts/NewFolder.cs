using Mercury.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercury.WorkingScripts
{
    public static class NewFolder
    {
        public static Control CreateNewFolder(Control parent, int folderCount, Font font, Folder folder, int LocationY)
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
                Name = "Folder_" + folderCount
            };

            var creator = new Label
            {
                Text = folder.FolderCreator,
                AutoSize = true,
                Location = new Point(control.Width - 250, 17),
                ForeColor = Color.White,
                Font = new Font(font.FontFamily, 9, FontStyle.Regular)
            };
            var icon = new PictureBox
            {
                Location = new Point(0, 8),
                Size = new Size(24, 24),
                AutoSize = false,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.folderWhite
            };
            var folderName = new Label
            {
                Location = new Point(40, 14),
                Text = folder.FolderName,
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };
            var label = new Label
            {
                Location = new Point(creator.Location.X - 10 - 60, 17),
                Text = "Создатель: ",
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 120),
                Font = new Font(font.FontFamily, 9, FontStyle.Regular)
            };
            var mark = new Label
            {
                Location = new Point(folderName.Location.X + folderName.Width + 20, 17),
                Text = "folder",
                AutoSize = true,
                Visible = false,
                Name = "Mark"
            };
            var edit = new PictureBox
            {
                Location = new Point(creator.Location.X + creator.Width + 75, 15),
                Size = new Size(16, 16),
                AutoSize = false,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.folderEditWhite,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            var delete = new PictureBox
            {
                Location = new Point(edit.Location.X + edit.Width + 30, 15),
                Size = new Size(16, 16),
                AutoSize = false,
                Cursor = Cursors.Hand,
                Image = Properties.Resources.deleteFolderWhite,
                SizeMode = PictureBoxSizeMode.Zoom
            };

            control.Controls.Add(icon);
            control.Controls.Add(folderName);
            control.Controls.Add(creator);
            control.Controls.Add(label);
            control.Controls.Add(mark);
            control.Controls.Add(edit);
            control.Controls.Add(delete);

            control.MouseEnter += (f, a) => 
            {
                icon.Image = Properties.Resources.folderGreen;
                folderName.ForeColor = Color.FromArgb(29, 185, 84);
            };
            control.MouseLeave += (f, a) =>
            {
                icon.Image = Properties.Resources.folderWhite;
                folderName.ForeColor = Color.White;
            };
            icon.MouseEnter += (f, a) =>
            {
                icon.Image = Properties.Resources.folderGreen;
                folderName.ForeColor = Color.FromArgb(29, 185, 84);
            };
            icon.MouseLeave += (f, a) =>
            {
                icon.Image = Properties.Resources.folderWhite;
                folderName.ForeColor = Color.White;
            };
            folderName.MouseEnter += (f, a) =>
            {
                icon.Image = Properties.Resources.folderGreen;
                folderName.ForeColor = Color.FromArgb(29, 185, 84);
            };
            folderName.MouseLeave += (f, a) =>
            {
                icon.Image = Properties.Resources.folderWhite;
                folderName.ForeColor = Color.White;
            };
            edit.MouseEnter += (f, a) =>
            {
                edit.Image = Properties.Resources.folderEditGreen;
            };
            edit.MouseLeave += (f, a) =>
            {
                edit.Image = Properties.Resources.folderEditWhite;
            };
            delete.MouseEnter += (f, a) =>
            {
                delete.Image = Properties.Resources.deleteFolderGreen;
            };
            delete.MouseLeave += (f, a) =>
            {
                delete.Image = Properties.Resources.deleteFolderWhite;
            };

            // REF: Удаление папки
            delete.Click += (f, a) => 
            {
                var par = parent.Parent.Parent;
                (par as Main).folderCollectionInActiveSafe.Remove(folder);
                (par as Main).DeleteFolder((par as Main).activeSafe.SafeID, folder.FolderID);
                (par as Main).ShowSafeItemView((par as Main).activeSafe);
            };

            control.Resize += (f, a) => 
            {
                control.Width = parent.Width - 2;
                creator.Location = new Point(control.Width - 250, 17);
                label.Location = new Point(creator.Location.X - 10 - 60, 17);
                edit.Location = new Point(creator.Location.X + creator.Width + 75, 15);
                delete.Location = new Point(edit.Location.X + edit.Width + 30, 15);
            };

            return control;
        } 
    }
}
