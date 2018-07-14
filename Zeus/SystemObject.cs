using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Hermes; 

namespace Zeus
{
    public class SystemObject : HermesLoggable
    {
        private long id;
        private string type;

        public SystemObject()
        {
            id = -101;
            type = "System";
        }

        public long ID => id;

        public string Type => type;
    }
}
