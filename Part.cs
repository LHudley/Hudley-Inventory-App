using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.InvClasses
{
    public abstract class Part
    {
        

        //Part abstract base class
        public int PartId { get; set; }
        public string PartName { get; set; }
        public int PartInv { get; set; }
        public double PartPrice { get; set; }
        public int PartMin { get; set; }
        public int PartMax { get; set; }
       


        //Creating Part constructor
        public Part( int partId, string part_name, int part_inventory, double part_price, int part_min, int part_max)
        {
            PartId = partId;
            PartName = part_name;
            PartInv = part_inventory;
            PartPrice = part_price;
            PartMin = part_min;
            PartMax = part_max;

        }

       
    }
}
