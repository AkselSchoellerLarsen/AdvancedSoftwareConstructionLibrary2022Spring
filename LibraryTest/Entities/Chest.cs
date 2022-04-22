using Library.Entities.Abstracts;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Entities {
    public class Chest : WorldItem {
        public Chest(Position pos) : base(pos) { }

        public override bool AllowWalkover(Creature walker) {
            return false;
        }

        public override bool CanPickup(Creature walker) {
            return true;
        }

        public override void Draw(Graphics g) {
            g.FillRectangle(Brushes.Brown,
                GraphicsHelper.RectangleCenteredOn(Position,
                0.8, 0.8));
        }

        public override bool TakesMovementToPickup(Creature picker) {
            return true;
        }

        protected override void EffectOnPickup(Creature picker) {
            Random r = new Random();
            
        }
    }
}
