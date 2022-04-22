using Library.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Util {
    public static class GraphicsHelper {

        public static Rectangle RectangleCenteredOn(Position position, int width, int height) {
            int viewX = position.x - World.Singleton.ViewPosition.x;
            int viewY = position.y - World.Singleton.ViewPosition.y;

            int gWidth = Configuration.GridSizeX;
            int gHeight = Configuration.GridSizeY;

            return new Rectangle(
                gWidth * viewX + (gWidth - width/2),
                gHeight * viewY + (gHeight - height/2),
                width,
                height);
        }
    }
}
