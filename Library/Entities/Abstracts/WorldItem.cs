using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Abstracts {
    public abstract class WorldItem : Entity {
        protected WorldItem(Position pos) : base(pos) {

        }

        public void OnPickup(Creature picker) {
            EffectOnPickup(picker);
            World.Singleton.Items.Remove(this);
        }
        public abstract bool AllowWalkover(Creature walker);
        public abstract bool CanPickup(Creature walker);
        public abstract bool TakesMovementToPickup(Creature picker);
        protected abstract void EffectOnPickup(Creature picker);

        public override bool Equals(object? obj) {
            if(obj == null) { return false; }
            if(obj is WorldItem) {
                WorldItem wi = (WorldItem)obj;
                if(wi.Position == this.Position) {
                    return true;
                }
            }
            return false;
        }
    }
}
