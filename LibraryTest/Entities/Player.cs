using Library;
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
        protected override int BaseHitPoints => 5;

        protected override int BaseAttackPower => 1;

        protected override int BaseDefencePower => 1;

        public Player(Position pos) : base(pos) {
            HitPoints = 1;

            //Maybe place WASD controls here?
        }

        public override void Tick() {
            Random r = new Random();
            int x = 0;
            int y = 0;

            while (x < 10 && x > -10) {
                x = r.Next(-20, 20);
            }
            while (y < 10 && y > -10) {
                y = r.Next(-20, 20);
            }
            Position p = new Position(Position.x + x, Position.y + y);

            if(World.Singleton.PositionOccupiedBy(p) == null) {
                int i = r.Next(10);
                if(i < 2) {
                    World.Singleton.Creatures.Add(new AI(p));
                } else if (i < 5) {
                    World.Singleton.Structures.Add(new Wall(p));
                } else if(i < 9) {
                    World.Singleton.Items.Add(new Apple(p, r.Next(1, 4)));
                } else {
                    World.Singleton.Items.Add(new Chest(p));
                }
            }
            World.Singleton.ViewPosition = new Position(Position.x-5, Position.y-5);
        }

        public override void Draw(Graphics g) {
            g.FillEllipse(new SolidBrush(Color.Black),
                GraphicsHelper.RectangleCenteredOn(Position, 1, 1));

            g.FillEllipse(new SolidBrush(Color.Red),
               GraphicsHelper.RectangleCenteredOn(Position,
               1.0d * HitPoints / MaxHitPoints, 1.0d * HitPoints / MaxHitPoints));

            Pen dpPen = new Pen(Color.Silver);
            dpPen.Width = DefencePower;

            g.DrawEllipse(dpPen,
               GraphicsHelper.RectangleCenteredOn(Position, 1.1, 1.1));

            Pen apPen = new Pen(Color.Gold);
            apPen.Width = (AttackPower+1)/2;

            g.DrawEllipse(apPen,
               GraphicsHelper.RectangleCenteredOn(Position, 1.3, 1.3));
        }
    }
}
