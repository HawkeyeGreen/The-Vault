using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Vault.Technic;
using The_Vault.World.Basics;

namespace The_Vault.World.Materials
{
    class BasicMaterial : GameObject, IMaterial
    {
        private Temperature smp;
        private Temperature sdp;
        private Temperature flamingpoint;
        private bool flammable;
        private long texture_id;

        public Temperature SMP { get => smp; set => smp = value; }
        public Temperature SDP { get => sdp; set => sdp = value; }
        public Temperature Flamingpoint { get => flamingpoint; set => flamingpoint = value; }
        public bool Flammable { get => flammable; set => flammable = value; }
        public long TextureID { get => texture_id; set => texture_id = value; }

        public BasicMaterial(string type) : base(type)
        {
            
        }
    }
}
