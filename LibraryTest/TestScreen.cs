using Library;

namespace LibraryTest {
    public partial class TestScreen : Form {
        public TestScreen() {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e) {
            World.Singleton.OnKeyDown(e);
        }

        protected override void OnPaint(PaintEventArgs e) {
            World.Singleton.OnPaint(e);
        }

    }
}