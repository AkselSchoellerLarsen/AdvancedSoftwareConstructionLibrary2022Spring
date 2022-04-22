using Library.Config;
using Library.Entities.Abstracts;
using Library.Util;
using System.Diagnostics;

namespace Library {
    public class World {
        #region Tracing
        private TraceSource ts = new TraceSource("Library.World");
        private TraceListener consoleTrace = new ConsoleTraceListener();
        private TraceListener fileTrace = new TextWriterTraceListener("Logs/Log.txt");

        private void TraceSetup() {
            ts.Switch = new SourceSwitch("Library Tracing", "All");
            ts.Listeners.Add(consoleTrace);
            ts.Listeners.Add(fileTrace);
        }
        public void Trace(string s, string catagory = "information") {
            ConsoleWrite(s, catagory);
            LogWrite(s, catagory);
        }
        private void ConsoleWrite(string s, string catagory = "information") {
            if (Configuration.ShouldConsoleTrace) {
                consoleTrace.WriteLine(s, catagory);
                consoleTrace.Flush();
            }
        }
        private void LogWrite(string s, string catagory = "information") {
            if (Configuration.ShouldFileTrace) {
                fileTrace.WriteLine($"At {DateTime.Now}: " + s, catagory);
                fileTrace.Flush();
            }
        }
        #endregion


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
            #region Tracing
            TraceSetup();
            #endregion

            ViewPosition = new Position(0, 0);
            Creatures = new List<Creature>();
            Structures = new List<Structure>();
            Items = new List<WorldItem>();

            #region Tracing
            Trace("Attempting to configure");
            #endregion
            string configPath = Directory.GetCurrentDirectory() + "\\config_file.xml";
            Configuration.LoadConfig(configPath);
            Configuration.SaveConfig(configPath);
            #region Tracing
            Trace("Configuration completed");
            #endregion

        }

        public void Tick() {
            foreach (Creature creature in Creatures) {
                creature.Tick();
            }
        }

        public Entity? PositionOccupiedBy(Position pos) {
            Structure? structure = Structures.Find((s) => {
                if (s.Position == pos) {
                    return true;
                }
                return false;
            });
            if (structure != null) { return structure; }

            Creature? creature = Creatures.Find((c) => {
                if(c.Position == pos) {
                    return true;
                }
                return false;
            });
            if(creature != null) { return creature; }

            WorldItem? item = Items.Find((i) => {
                if (i.Position == pos) {
                    return true;
                }
                return false;
            });
            if (creature != null) { return creature; }

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