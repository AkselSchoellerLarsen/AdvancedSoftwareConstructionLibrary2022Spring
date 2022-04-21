using Library.Config;
using Library.Entities.Interfaces;
using Library.Util;

namespace Library.Entities.Abstracts {
    public abstract class Creature : ICreature {
        public Creature(Position pos) {
            Position = pos;
        }

        public Position Position { get; set; }
        public int StartX { get {
            return Configuration.GridSizeX *
                (Position.x-World.Singleton.ViewPosition.x);
        } }
        public int StartY { get {
            return Configuration.GridSizeY *
                (Position.y - World.Singleton.ViewPosition.y);
        } }
        public int Width { get { return Configuration.GridSizeX; } }
        public int Height { get { return Configuration.GridSizeY; } }

        public void Draw(Graphics g) {
            DrawInSquare(g, new Rectangle(StartX, StartY, Width, Height));
        }

        protected abstract void DrawInSquare(Graphics g, Rectangle boundingBox);
    }
}
