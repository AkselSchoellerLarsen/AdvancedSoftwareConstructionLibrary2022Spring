using Library.Config;
using Library.Entities.Interfaces;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Abstracts {
    public abstract class Entity : IEntity {
        protected Entity(Position pos) {
            Position = pos;
        }

        public Position Position { get; set; }

        public abstract void Draw(Graphics g);
    }
}
