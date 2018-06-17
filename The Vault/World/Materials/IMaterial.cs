using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Vault.World.Basics;

namespace The_Vault.World.Materials
{
    interface IMaterial
    {
        Temperature SMP { get; set; }
        Temperature SDP { get; set; }
        Temperature Flamingpoint { get; set; }
        bool Flammable { get; set; }
        long TextureID { get; set; }

    }
}
