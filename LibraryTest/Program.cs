using Library;
using Library.Util;
using LibraryTest.Entities;

namespace LibraryTest {
    internal static class Program {
        static void Main(string[] args) {
            ApplicationConfiguration.Initialize();

            SetupGameWorld();

            Application.Run(new TestScreen());
        }

        private static void SetupGameWorld() {
            World.Singleton.ViewPosition = new Position(0, 0);
            
            World.Singleton.Creatures.Add(new Player(new Position(0, 0)));
            World.Singleton.Creatures.Add(new Player(new Position(1, 1)));
            World.Singleton.Creatures.Add(new Player(new Position(5, 5)));

        }
    }
}