﻿using Library.Config;
using Library.Entities.Interfaces;
using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Abstracts {
    public abstract class Entity : IEntity {
        protected Entity(Position pos) {
            Position = pos;
        }

        public Position Position { get; set; }
        public int StartX {
            get {
                return Configuration.GridSizeX *
                    (Position.x - World.Singleton.ViewPosition.x);
            }
        }
        public int StartY {
            get {
                return Configuration.GridSizeY *
                    (Position.y - World.Singleton.ViewPosition.y);
            }
        }
        public int Width { get { return Configuration.GridSizeX; } }
        public int Height { get { return Configuration.GridSizeY; } }

        public abstract void Draw(Graphics g);
    }
}
