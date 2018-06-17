using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Vault.Technic
{
    abstract class GameObject
    {
        static long ID_counter = 0;
        public string MyType
        {
            get;
            set;
        }
        private long id;
        public long ID
        {
            get => id;
        }

        public GameObject()
        {
            ID_counter++;
            id = ID_counter;
        }
    }
}
