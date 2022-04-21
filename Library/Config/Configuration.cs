using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Library.Config {
    public static class Configuration {
        public static int ScreenSizeX = 800;
        public static int ScreenSizeY = 600;
        public static int GridSizeX = 50;
        public static int GridSizeY = 50;

        public static void LoadConfig(string configFilePath) {
            try {
                XDocument doc = XDocument.Load(configFilePath);

                IEnumerable<XElement> screenX =
                    doc.Descendants().Where(tag => tag.Name == "ScreenSizeX");
                ScreenSizeX = int.Parse(screenX.ToList()[0].Value);

                IEnumerable<XElement> screenY =
                    doc.Descendants().Where(tag => tag.Name == "ScreenSizeY");
                ScreenSizeY = int.Parse(screenY.ToList()[0].Value);

                IEnumerable<XElement> gridX =
                    doc.Descendants().Where(tag => tag.Name == "GridSizeX");
                GridSizeX = int.Parse(gridX.ToList()[0].Value);

                IEnumerable<XElement> gridY =
                    doc.Descendants().Where(tag => tag.Name == "GridSizeY");
                GridSizeY = int.Parse(gridY.ToList()[0].Value);
            }
            catch (Exception e) {
                //Ignore
            }
        }

        public static void SaveConfig(string configFilePath) {
            using (XmlWriter writer = XmlWriter.Create(configFilePath)) {
                writer.WriteStartDocument();
                    writer.WriteStartElement("Configurations");
                        writer.WriteElementString("ScreenSizeX", ScreenSizeX.ToString());
                        writer.WriteElementString("ScreenSizeY", ScreenSizeY.ToString());
                        writer.WriteElementString("GridSizeX", GridSizeX.ToString());
                        writer.WriteElementString("GridSizeY", GridSizeY.ToString());
                    writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
            }
        }
    }
}
