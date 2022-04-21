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

        private World() {
            ViewPosition = new Position(0, 0);
            Creatures = new List<Creature>();

            string configPath = Directory.GetCurrentDirectory() + "\\config_file.xml";
            Configuration.LoadConfig(configPath);
            Configuration.SaveConfig(configPath);
        }

        public void OnKeyDown(KeyEventArgs e) {
            InputHandler.Singleton.HandleInput(e);
        }

        public void OnPaint(PaintEventArgs e) {
            foreach(Creature creature in Creatures) {
                creature.Draw(e.Graphics);
            }
        }
    }
}