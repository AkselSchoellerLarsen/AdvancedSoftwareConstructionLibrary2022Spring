using Library.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities.Interfaces {
    public interface IHasPosition {
        public Position Position { get; set; }
    }
}
