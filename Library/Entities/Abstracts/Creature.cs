using Library.Config;
using Library.Inventory;
using Library.Util;

namespace Library.Entities.Abstracts {
    public abstract class Creature : Entity {
        private int _hitPoints;

        protected Creature(Position pos) : base(pos) {
            Equipment = new List<Equipment>();
        }

        public List<Equipment> Equipment { get; }

        public virtual int HitPoints {
            get {
                return _hitPoints;
            }
            set {
                if(value > MaxHitPoints) {
                    _hitPoints = MaxHitPoints;
                } else if(value <= 0) {
                    World.Singleton.Creatures.Remove(this);
                } else {
                    _hitPoints = value;
                }
            }
        }
        public int MaxHitPoints {
            get {
                int re = BaseHitPoints;

                foreach (Equipment equip in Equipment) {
                    re += equip.HPOffset;
                }

                return re;
            }
        }
        public int AttackPower {
            get {
                int re = BaseAttackPower;

                foreach (EquipmentWeapon weapon in Equipment.OfType<EquipmentWeapon>()) {
                    re += weapon.APOffset;
                }

                return re;
            }
        }
        public int DefencePower {
            get {
                int re = BaseDefencePower;

                foreach (EquipmentArmor armor in Equipment.OfType<EquipmentArmor>()) {
                    re += armor.DPOffset;
                }

                return re;
            }
        }
        protected abstract int BaseHitPoints { get; }
        protected abstract int BaseAttackPower { get; }
        protected abstract int BaseDefencePower { get; }

        public void TryMoveTo(Position target) {
            #region Tracing
            if(Configuration.LogLevel < 2) World.Singleton.Trace($"{this} is trying to move to {target}");
            #endregion

            Entity? e = World.Singleton.PositionOccupiedBy(target);
            if (e != null) {
                if (e is Structure) {
                    Structure s = (Structure)e;
                    if (!s.EffectOnTryEnter(this, Position)) {
                        #region Tracing
                        if (Configuration.LogLevel < 3) World.Singleton.Trace($"{this} failed to enter {s}");
                        #endregion
                        return;
                    }
                } else if (e is WorldItem) {
                    WorldItem i = (WorldItem)e;
                    if (i.CanPickup(this)) {
                        i.OnPickup(this);
                        #region Tracing
                        if (Configuration.LogLevel < 4) World.Singleton.Trace($"{this} picked up {i}");
                        #endregion
                        if (i.TakesMovementToPickup(this)) {
                            return;
                        }
                    } else if (!i.AllowWalkover(this)) {
                        #region Tracing
                        if (Configuration.LogLevel < 3) World.Singleton.Trace($"{this} walked over {i}");
                        #endregion
                        return;
                    }
                } else if (e is Creature) {
                    Creature c = (Creature)e;
                    c.OnAttacked(this);
                    #region Tracing
                    if (Configuration.LogLevel < 3) World.Singleton.Trace($"{this} attacked {c}");
                    #endregion
                    return;
                }
            }
            Position = target;

            #region Tracing
            if (Configuration.LogLevel < 2) World.Singleton.Trace($"{this} moved to {target}");
            #endregion
        }

        public virtual void OnAttacked(Creature attacker) {
            int damage = attacker.AttackPower / this.DefencePower;
            #region Tracing
            if (Configuration.LogLevel < 4) World.Singleton.Trace($"{attacker} dealt {damage} damage to {this}");
            #endregion
            this.HitPoints -= damage;
        }

        public abstract void Tick();

        public override bool Equals(object? obj) {
            if (obj == null) { return false; }
            if (obj is Creature) {
                Creature c = (Creature)obj;
                if (c.Position == this.Position) {
                    return true;
                }
            }
            return false;
        }
    }
}