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
    }
}
