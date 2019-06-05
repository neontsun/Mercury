using Mercury.CustomControls;
using pivyLab.Control;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mercury.WorkingScripts
{
    public static class NewNotification
    {
        
        public static Control CreateNewNotification(Control parent, 
            int notificationCount, Font font, Notification notification, int LocationY)
        {
            // Создаем контрол
            var control = new Panel
            {
                Location = new Point(0, LocationY),
                AutoSize = false,
                Width = parent.Width - 2,
                Height = 120,
                //Cursor = Cursors.Hand,
                Parent = parent,
                Name = "Notification_" + notificationCount
                //BorderStyle = BorderStyle.FixedSingle
            };

            var safeIDLabel = new Label
            {
                Location = new Point(5, 5),
                Text = "ID:",
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 120),
                Font = font
            };
            var safeID = new Label
            {
                Location = new Point(safeIDLabel.Location.X + 25, 6),
                Text = notification.SafeID.ToString(),
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };

            var safeNameLabel = new Label
            {
                Location = new Point(5, safeID.Location.Y + safeID.Height),
                Text = "Наименование сейфа:",
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 120),
                Font = font
            };
            var safeName = new Label
            {
                Location = new Point(safeNameLabel.Location.X + 135, safeNameLabel.Location.Y),
                Text = notification.SafeName,
                AutoSize = true,
                ForeColor = Color.White,
                Font = font
            };

            var creatorLabel = new Label
            {
                Location = new Point(5, safeName.Location.Y + safeName.Height),
                Text = "Отправитель:",
                AutoSize = true,
                ForeColor = Color.FromArgb(120, 120, 120),
                Font = font
            };
            var creator = new Label
            {
                Text = notification.CreatorSafe,
                AutoSize = true,
                Location = new Point(creatorLabel.Location.X + 90, creatorLabel.Location.Y),
                ForeColor = Color.White,
                Font = font
            };

            var buttonGreen = new FlatEllButton
            {
                Location = new Point(5, creator.Location.Y + creator.Height + 5),
                Width = 100,
                Height = 30,
                Back = Color.FromArgb(29, 185, 84),
                Text = "Принять",
                RoundRadius = 2,
                Font = font,
                ForeColor = Color.White,
                AutoSize = false,
                Cursor = Cursors.Hand,
                Name = "True_" + notificationCount
            };
            var buttonRed = new FlatEllButton
            {
                Location = new Point(buttonGreen.Location.X + buttonGreen.Width + 5, buttonGreen.Location.Y),
                Width = 100,
                Height = 32,
                Back = Color.FromArgb(226, 33, 52),
                Text = "Отклонить",
                RoundRadius = 2,
                Font = font,
                ForeColor = Color.White,
                AutoSize = false,
                Cursor = Cursors.Hand,
                Name = "False_" + notificationCount
        };

            var separator = new Separator
            {
                Location = new Point(0, buttonGreen.Location.Y + buttonGreen.Height + 7),
                Width = parent.Width,
                Height = 1,
                BackColor = Color.FromArgb(40, 40, 40)
            };

            buttonGreen.MouseEnter += (f, a) => buttonGreen.Back = Color.FromArgb(30, 215, 96);
            buttonGreen.MouseLeave += (f, a) => buttonGreen.Back = Color.FromArgb(29, 185, 84);
            buttonGreen.MouseDown += (f, a) => buttonGreen.Back = Color.FromArgb(20, 131, 59);

            buttonRed.MouseEnter += (f, a) => buttonRed.Back = Color.FromArgb(228, 52, 70);
            buttonRed.MouseLeave += (f, a) => buttonRed.Back = Color.FromArgb(226, 33, 52);
            buttonRed.MouseDown += (f, a) => buttonRed.Back = Color.FromArgb(148, 19, 32);

            buttonRed.Click += (f, a) => 
            {
                // Удаляем контрол
                parent.Controls.Remove(control);
                // Удаляем из списка
                (parent as NotificationForm).list.Remove(notification);
                // Удаляем из базы
                DateBase.DeleteNotification(notification.NotificationID);
                // Очищаем и подгружаем
                (parent as NotificationForm).LoadNotification();
            };
            buttonGreen.Click += (f, a) => 
            {
                // Удаляем контрол
                parent.Controls.Remove(control);
                // Удаляем из списка
                (parent as NotificationForm).list.Remove(notification);
                // Удаляем из базы
                DateBase.DeleteNotification(notification.NotificationID);
                // Очищаем и подгружаем
                (parent as NotificationForm).LoadNotification();
                // Добавляем пользователя в сейф
                DateBase.AddUserInSafe(notification.SafeID, DateBase.GetUserID(Properties.Settings.Default.userEmail));
                // Обновляем список сейфов
                (parent as NotificationForm).ReloadSafeList();
                (parent as NotificationForm).UpdateNotificationCount();
            };

            control.Controls.Add(safeIDLabel);
            control.Controls.Add(safeID);
            control.Controls.Add(safeNameLabel);
            control.Controls.Add(safeName);
            control.Controls.Add(creatorLabel);
            control.Controls.Add(creator);
            control.Controls.Add(buttonGreen);
            control.Controls.Add(buttonRed);
            control.Controls.Add(separator);

            

            return control;
        }
    }
}
