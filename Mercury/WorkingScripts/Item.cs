using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercury.WorkingScripts
{
    public class Item
    {
        internal int ItemID { get; set; }

        internal string ItemCreator { get; set; }

        internal List<string> ItemField { get; set; }



        public Item(string ItemCreator, List<string> ItemField)
        {
            //this.ItemID = ItemID;
            this.ItemCreator = ItemCreator;
            this.ItemField = ItemField;
        }
    }
}
