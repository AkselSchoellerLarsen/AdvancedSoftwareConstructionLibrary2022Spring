using Library.Config;
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

        public override void OnAttacked(Creature attacker) {
            throw new NotImplementedException();
        }

        public override void Tick() {
            throw new NotImplementedException();
        }

        public override void Draw(Graphics g) {
            g.FillEllipse(new SolidBrush(Color.Black),
                GraphicsHelper.RectangleCenteredOn(Position,
                Configuration.GridSizeX, Configuration.GridSizeY));

            g.FillEllipse(new SolidBrush(Color.White),
                GraphicsHelper.RectangleCenteredOn(Position,
                (int)(Configuration.GridSizeX*0.3), (int)(Configuration.GridSizeY*0.3)));
        }
    }
}
