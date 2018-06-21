using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace The_Vault.World.Map.Tiles
{
    interface ITileable
    {
        Vector2 MyPosition { get; set; }
        string TextureID { get; set; }
        bool Blocked { get; }
        int PartialBlockGrade { get; set; }
        ITileable Parent { get; set; }

        void blockPosition(Vector2 position);
        ITileable getChild(Vector2 position);
        bool containsPosition(Vector2 position);
        void refreshBlockStatus();
    }
}
