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
            HitPoints = 4;
        }

        protected override int BaseHitPoints => 5;

        protected override int BaseAttackPower => 1;

        protected override int BaseDefencePower => 1;

        public override void Draw(Graphics g) {
            g.FillEllipse(new SolidBrush(Color.DarkGray),
               GraphicsHelper.RectangleCenteredOn(Position, 1, 1));

            g.FillEllipse(new SolidBrush(Color.DarkRed),
               GraphicsHelper.RectangleCenteredOn(Position,
               1.0d * HitPoints / MaxHitPoints, 1.0d * HitPoints / MaxHitPoints));

            Pen dpPen = new Pen(Color.Silver);
            dpPen.Width = DefencePower;

            g.DrawEllipse(dpPen,
               GraphicsHelper.RectangleCenteredOn(Position, 1.1, 1.1));

            Pen apPen = new Pen(Color.Gold);
            apPen.Width = (AttackPower + 1) / 2;

            g.DrawEllipse(apPen,
               GraphicsHelper.RectangleCenteredOn(Position, 1.3, 1.3));
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
