using Library.Config;
using Library.Entities.Abstracts;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Entities {
    public class Wall : Structure {
        public Wall(Position pos) : base(pos) { }

        public override void Draw(Graphics g) {
            g.FillRectangle(Brushes.Black,
                GraphicsHelper.RectangleCenteredOn(Position,
                1, 1));
        }

        public override bool EffectOnTryEnter(Creature creature, Position from) {
            return false;
        }
    }
}
