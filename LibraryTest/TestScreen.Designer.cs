﻿using Library.Config;

namespace LibraryTest {
    partial class TestScreen {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(Configuration.ScreenSizeX, Configuration.ScreenSizeY);
            this.Text = "TestScreen";
        }
    }
}