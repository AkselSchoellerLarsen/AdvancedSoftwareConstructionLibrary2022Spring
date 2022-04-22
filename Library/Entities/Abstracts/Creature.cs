using Library.Util;

namespace Library.Entities.Abstracts {
    public abstract class Creature : Entity {
        protected Creature(Position pos) : base(pos) {

        }


        public void TryMoveTo(Position target) {
            Entity e = World.Singleton.PositionOccupiedBy(target);
            if (e == null) {
                Position = target;
            } else if (e is Structure) {
                Structure s = (Structure)e;
                if (s.EffectOnTryEnter(this, Position)) {
                    Position = target;
                }
            } else if (e is WorldItem) {
                WorldItem i = (WorldItem)e;
                if (i.CanPickup(this)) {
                    i.OnPickup(this);
                    if (i.TakesMovementToPickup(this)) {
                        return;
                    } else {
                        Position = target;
                    }
                } else if(i.AllowWalkover(this)) {
                    Position = target;
                }
            } else if (e is Creature) {
                Creature c = (Creature)e;
                c.OnAttacked(this);
            }
        }

        public abstract void OnAttacked(Creature attacker);

        public abstract void Tick();

    }
}