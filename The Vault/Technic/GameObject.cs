using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zeus.Hermes;

namespace The_Vault.Technic
{
    abstract class GameObject : HermesLoggable
    {
        static long ID_counter = 0;
        public string MyType
        {
            get;
        }
        private long id;
        public long ID
        {
            get => id;
        }

        public string Type => MyType;

        public GameObject(string type)
        {
            ID_counter++;
            id = ID_counter;
            MyType = type;

            Hermes.getInstance().log(this, " Created.");
        }
    }
}
