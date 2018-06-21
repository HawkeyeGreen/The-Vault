using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using The_Vault.Technic;
using The_Vault.World.Materials;

namespace The_Vault.World.Map.Tiles
{
    class QuarterTile : GameObject, ITileable
    {
        List<Tile> children;
        Tile parentTile;


        public Vector2 MyPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string TextureID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Blocked => throw new NotImplementedException();

        public int PartialBlockGrade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITileable Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMaterial Ground { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public QuarterTile() : base("QuarterTile")
        {

        }

        public static QuarterTile createQuarterTilefromInterface(ITileable quarter)
        {
            return new QuarterTile();
        }

        public void blockPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public bool containsPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public ITileable getChild(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void refreshBlockStatus()
        {
            throw new NotImplementedException();
        }
    }
}
