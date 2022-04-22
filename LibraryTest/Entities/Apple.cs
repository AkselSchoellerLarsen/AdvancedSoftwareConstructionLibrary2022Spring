using Library.Entities.Abstracts;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Entities {
    public class Apple : WorldItemConsumable {
        private int _size;
        
        public Apple(Position pos, int size) : base(pos) {
            _size = size;
        }

        public override bool CanPickup(Creature walker) {
            if(walker.HitPoints < walker.MaxHitPoints) {
                return true;
            }
            return false;
        }

        public override void Draw(Graphics g) {
            g.FillEllipse(new SolidBrush(Color.Green),
               GraphicsHelper.RectangleCenteredOn(Position,
               1.0d * _size / 5, 1.0d * _size / 5));
        }

        protected override void EffectOnPickup(Creature picker) {
            picker.HitPoints += _size;
        }
    }
}
