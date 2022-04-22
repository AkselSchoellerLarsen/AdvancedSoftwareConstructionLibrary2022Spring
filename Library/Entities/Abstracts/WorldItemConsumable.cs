using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Abstracts {
    public abstract class WorldItemConsumable : WorldItem {
        protected WorldItemConsumable(Position pos) : base(pos) { }

        public override bool AllowWalkover(Creature walker) {
            return true;
        }
        public override bool TakesMovementToPickup(Creature picker) {
            return true;
        }
    }
}
