using Library;
using Library.Entities.Abstracts;
using Library.Inventory;
using Library.Util;
using LibraryTest.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTest.Entities {
    public class Chest : WorldItem {
        private Equipment? _equipment;
        private Creature? _dropper;
        public Chest(Position pos, Equipment? equipment = null, Creature? dropper = null) : base(pos) {
            _equipment = equipment;
            _dropper = dropper;
        }

        public override bool AllowWalkover(Creature walker) {
            return false;
        }

        public override bool CanPickup(Creature walker) {
            if(walker == _dropper) {
                return false;
            }
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
            if (_equipment is null) {
                Random r = new Random();

                int type = r.Next(3);
                int level = r.Next(5);
                
                if (type == 0) {
                    _equipment = new EquipmentRing(level);
                } else if (type == 1) {
                    _equipment = new EquipmentAxe(level);
                } else {
                    _equipment = new EquipmentPlatemail(level);
                }
            }

            if(_equipment is EquipmentRing) {
                picker.Equipment.Add(_equipment);
            } else if(_equipment is EquipmentAxe) {
                EquipmentAxe axe = (EquipmentAxe)_equipment;


                EquipmentAxe? throwOut = null;
                bool containsAxe = false;
                foreach(EquipmentAxe e in picker.Equipment.OfType<EquipmentAxe>()) {
                    if(e.APOffset < axe.APOffset) {
                        throwOut = e;
                    } else {
                        DropChest(e, picker);
                    }
                    containsAxe = true;
                }
                if (throwOut != null) {
                    picker.Equipment.Remove(throwOut);
                    DropChest(throwOut, picker);
                    picker.Equipment.Add(_equipment);
                }

                if (!containsAxe) {
                    picker.Equipment.Add(_equipment);
                }
            } else if(_equipment is EquipmentPlatemail) {
                EquipmentPlatemail mail = (EquipmentPlatemail)_equipment;


                EquipmentPlatemail? throwOut = null;
                bool containsMail = false;
                foreach (EquipmentPlatemail e in picker.Equipment.OfType<EquipmentPlatemail>()) {
                    if (e.DPOffset < mail.DPOffset) {
                        throwOut = e;
                    }
                    containsMail = true;
                }
                if (throwOut != null) {
                    picker.Equipment.Remove(throwOut);
                    DropChest(throwOut, picker);
                    picker.Equipment.Add(_equipment);
                }

                if (!containsMail) {
                    picker.Equipment.Add(_equipment);
                }
            }
        }

        private void DropChest(Equipment throwOut, Creature dropper) {
            World.Singleton.Items.Add(new Chest(dropper.Position, throwOut, dropper));
        }
    }
}
