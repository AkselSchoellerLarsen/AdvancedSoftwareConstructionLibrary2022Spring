using Library.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Inventory {
    public class EquipmentAxe : EquipmentWeapon {
        public EquipmentAxe(int level) : base(level*2) {

        }
    }
}
