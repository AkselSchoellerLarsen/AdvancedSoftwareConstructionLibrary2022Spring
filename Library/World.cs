using Library.Config;
using Library.Entities.Abstracts;
using Library.Util;

namespace Library {
    public class World {
        private static World instance = new World();
        public static World Singleton {
            get {
                return instance;
            }
        }

        public Position ViewPosition { get; set; }
        public List<Creature> Creatures { get; private set; }
        public List<Structure> Structures { get; private set; }
        public List<WorldItem> Items { get; private set; }

        private World() {
            ViewPosition = new Position(0, 0);
            Creatures = new List<Creature>();
            Structures = new List<Structure>();
            Items = new List<WorldItem>();

            string configPath = Directory.GetCurrentDirectory() + "\\config_file.xml";
            Configuration.LoadConfig(configPath);
            Configuration.SaveConfig(configPath);
        }

        public void Tick() {
            foreach (Creature creature in Creatures) {
                creature.Tick();
            }
        }

        public Entity PositionOccupiedBy(Position? pos) {
            foreach (Creature creature in Creatures) {
                if (creature.Position == pos) {
                    return creature;
                }
            }
            foreach (Structure structure in Structures) {
                if (structure.Position == pos) {
                    return structure;
                }
            }
            foreach (WorldItem item in Items) {
                if (item.Position == pos) {
                    return item;
                }
            }
            return null;
        }

        public void OnKeyDown(KeyEventArgs e) {
            InputHandler.Singleton.HandleInput(e);
        }

        public void OnPaint(PaintEventArgs e) {
            foreach (Structure structure in Structures) {
                structure.Draw(e.Graphics);
            }
            foreach (Creature creature in Creatures) {
                creature.Draw(e.Graphics);
            }
            foreach (WorldItem item in Items) {
                item.Draw(e.Graphics);
            }
        }
    }
}