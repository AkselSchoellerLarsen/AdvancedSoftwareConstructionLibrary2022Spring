using Library;

namespace LibraryTest {
    public partial class TestScreen : Form {
        public TestScreen() {
            InitializeComponent();

            Task.Run(() => {
                while(true) {
                    Thread.Sleep(1000);
                    Invalidate();
                }
            });
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            World.Singleton.OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            World.Singleton.OnPaint(e);
        }

    }
}