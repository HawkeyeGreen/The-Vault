using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Vault.World.Materials;
using The_Vault.Technic;

namespace The_Vault.World.Map.Tiles
{
    class Tile : GameObject, ITileable
    {
        #region private-variables

        #endregion

        #region public-fields
        public long GameID => ID;

        public Vector3 MyPosition { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Blocked => throw new NotImplementedException();

        public int PartialBlockGrade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITileable Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMaterial Ground { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IMaterial Roof => throw new NotImplementedException();

        public ITileable RoofZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GasZone Athmosphere => throw new NotImplementedException();

        public GeneralMap Map { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion

        public Tile():base("Tile")
        {

        }

        #region public-methods
        public void blockPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void changeAthmossphereComposition(string mode, Gas gas)
        {
            throw new NotImplementedException();
        }

        public bool containsPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void draw(SpriteBatch batch)
        {
            throw new NotImplementedException();
        }

        public Parteight getAtPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public ITileable getChild(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public IMaterial getRoofMaterial(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public bool isBlocked(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void refreshBlockStatus()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
