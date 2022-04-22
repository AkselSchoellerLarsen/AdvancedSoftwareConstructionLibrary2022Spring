using Library.Entities.Abstracts;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Entities {
    public class AI : Creature {
        public AI(Position pos) : base(pos) {
            HitPoints = 5;
        }

        protected override int BaseHitPoints => 5;

        protected override int BaseAttackPower => 1;

        protected override int BaseDefencePower => 1;

        public override void Draw(Graphics g) {
            g.FillEllipse(new SolidBrush(Color.DarkGray),
               GraphicsHelper.RectangleCenteredOn(Position, 1, 1));

            g.FillEllipse(new SolidBrush(Color.Red),
               GraphicsHelper.RectangleCenteredOn(Position,
               1.0d * HitPoints / MaxHitPoints, 1.0d * HitPoints / MaxHitPoints));
        }

        public override void Tick() {
            Random r = new Random();
            int i = r.Next(4);
            if(i == 0) {
                TryMoveTo(new Position(Position.x+1, Position.y));
            } else if(i == 1) {
                TryMoveTo(new Position(Position.x-1, Position.y));
            } else if(i == 2) {
                TryMoveTo(new Position(Position.x, Position.y+1));
            } else if(i == 3) {
                TryMoveTo(new Position(Position.x, Position.y-1));
            }
        }
    }
}
