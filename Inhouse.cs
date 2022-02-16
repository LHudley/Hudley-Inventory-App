using InventoryApp.InvClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.Model
{
    public class Inhouse : Part

    {
        internal int MachineId { get; set; }


       
        public Inhouse(int partId, string part_name, int part_inventory, double part_price, int part_min, int part_max, int machineId)
            :base(partId, part_name, part_inventory, part_price, part_min, part_max)
        {
            MachineId = machineId;
        }

        

        
    }
}
