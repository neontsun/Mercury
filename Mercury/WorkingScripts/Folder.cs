using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public class Folder
    {
        /// <summary>
        ///  Название папки
        /// </summary>
        internal string FolderName { get; set; }

        /// <summary>
        /// Создатель
        /// </summary>
        internal string FolderCreator { get; set; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        internal int FolderID { get; set; }

        /// <summary>
        /// Список элементов в папке
        /// </summary>
        //internal List<Folder> Items { get; set; }


        /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="FolderName">Название папки</param>
    /// <param name="FolderCreator">Создатель</param>
        public Folder(string FolderName, string FolderCreator)
        {
            this.FolderName = FolderName;
            this.FolderCreator = FolderCreator;
        }
    }
}
