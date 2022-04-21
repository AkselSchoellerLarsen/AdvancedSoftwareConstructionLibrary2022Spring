using Library.Util.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Interfaces {
    public interface ICreature : IHasPosition {
        public void Draw(Graphics g);
    }
}
