using Library.Entities.Abstracts;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Entities {
    public class Player : Creature {
        public Player(Position pos) : base(pos) {
        
        }
    }
}
