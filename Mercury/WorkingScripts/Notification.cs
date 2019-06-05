using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public class Notification
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        internal int NotificationID { get; set; }

        /// <summary>
        /// Идентификатор сейфа
        /// </summary>
        internal int SafeID { get; set; }

        /// <summary>
        /// Название сейфа
        /// </summary>
        internal string SafeName { get; set; }

        /// <summary>
        /// Создатель сейфа
        /// </summary>
        internal string CreatorSafe { get; set; }

        public Notification(int NotificationID, int SafeID, string SafeName, string CreatorSafe)
        {
            this.NotificationID = NotificationID;
            this.SafeID = SafeID;
            this.SafeName = SafeName;
            this.CreatorSafe = CreatorSafe;
        }
    }
}
