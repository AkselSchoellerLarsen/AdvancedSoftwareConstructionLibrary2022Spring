using Library.Config;
using Library.Entities.Abstracts;

namespace Library {
    public class World {
        private static World instance = new World();
        public static World Singleton {
            get {
                return instance;
            }
        }

        public (int x, int y) ViewPosition { get; private set; }
        public List<Creature> Creatures { get; private set; }

        private World() {
            ViewPosition = (0, 0);
            Creatures = new List<Creature>();

            string configPath = Directory.GetCurrentDirectory() + "\\config_file.xml";
            Configuration.LoadConfig(configPath);
            Configuration.SaveConfig(configPath);
        }

        public void OnKeyDown(KeyEventArgs e) {
            
        }

        public void OnPaint(PaintEventArgs e) {
            foreach(Creature creature in Creatures) {
                creature.Draw(e.Graphics);
            }
        }
    }
}