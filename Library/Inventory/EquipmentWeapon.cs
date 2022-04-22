using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Inventory {
    public class EquipmentWeapon : Equipment {
        public int APOffset;

        public EquipmentWeapon(int apOffset, int hpOffset = 0) : base(hpOffset) {
            APOffset = apOffset;
        }

    }
}
