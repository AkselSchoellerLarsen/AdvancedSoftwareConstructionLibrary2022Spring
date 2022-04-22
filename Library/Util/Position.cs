using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Util {
    public class Position {
        public int x;
        public int y;

        public Position(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public static Position operator +(Position pos1, Position pos2) {
            return new Position(pos1.x + pos2.x, pos1.y + pos2.y);
        }
        public static Position operator -(Position pos1, Position pos2) {
            return new Position(pos1.x - pos2.x, pos1.y - pos2.y);
        }

        public static bool operator ==(Position pos1, Position pos2) {
            if(pos1.x == pos2.x && pos1.y == pos2.y) {
                return true;
            }
            return false;
        }
        public static bool operator !=(Position pos1, Position pos2) {
            return !(pos1 == pos2);
        }

        public override bool Equals(object? obj) {
            if(obj == null) return false;
            if(obj is Position) {
                Position other = (Position)obj;
                if(this.x == other.x && this.y == other.y) {
                    return true;
                }
            }
            return false;
        }
    }
}
