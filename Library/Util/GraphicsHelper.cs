using Library.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Util {
    public static class GraphicsHelper {
        public static Rectangle RectangleCenteredOn(Position position, int width, int height) {
            int gWidth = Configuration.GridSizeX;
            int gHeight = Configuration.GridSizeY;

            return new Rectangle(
                gWidth * position.x + (gWidth - width/2),
                gHeight * position.y + (gHeight - height/2),
                width,
                height);
        }
    }
}
