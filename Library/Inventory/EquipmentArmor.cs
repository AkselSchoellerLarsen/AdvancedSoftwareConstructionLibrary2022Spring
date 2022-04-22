using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Inventory {
    public class EquipmentArmor : Equipment {
        public int DPOffset;

        public EquipmentArmor(int dpOffset, int hpOffset = 0) : base(hpOffset) {
            DPOffset = dpOffset;
        }

    }
}
