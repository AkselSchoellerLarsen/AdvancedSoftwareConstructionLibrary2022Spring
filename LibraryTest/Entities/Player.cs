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
            HitPoints = 4;

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
            if(true) {
                World.Singleton.Creatures.Add(new AI(p));
            } else if (false) {
                World.Singleton.Structures.Add(new Wall(p));
            } else if(false) {

            }
        }

        public override void Draw(Graphics g) {
            g.FillEllipse(new SolidBrush(Color.Black),
                GraphicsHelper.RectangleCenteredOn(Position, 1, 1));

            g.FillEllipse(new SolidBrush(Color.Red),
               GraphicsHelper.RectangleCenteredOn(Position,
               1.0d * HitPoints / MaxHitPoints, 1.0d * HitPoints / MaxHitPoints));
        }
    }
}
