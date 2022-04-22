using Library.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Inventory {
    public class EquipmentRingmail : EquipmentArmor {
        public EquipmentRingmail(int dpOffset, int hpOffset = 0) : base(dpOffset, hpOffset) {
            
        }
    }
}
