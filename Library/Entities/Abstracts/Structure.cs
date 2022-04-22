using Library.Util;
using Library.Util.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Abstracts {
    public abstract class Structure : Entity {
        protected Structure(Position pos) : base(pos) {
            
        }

        public abstract bool EffectOnTryEnter(Creature creature, Position from);

        public override bool Equals(object? obj) {
            if (obj == null) { return false; }
            if (obj is Structure) {
                Structure s = (Structure)obj;
                if (s.Position == this.Position) {
                    return true;
                }
            }
            return false;
        }
    }
}
