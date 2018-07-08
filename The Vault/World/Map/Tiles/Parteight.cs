using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using The_Vault.Technic;
using The_Vault.World.Materials;

namespace The_Vault.World.Map.Tiles
{
    // Pixelgröße 8px*8px
    // IT Maße: 0.5m*05.m
    // Kleinste Ordnungseinheit

    class Parteight : GameObject,ITileable
    {
        private Vector3 rootPosition;
        private Vector2 helperVector;
        private string textureid = "NotFound";
        private bool fullBlock = false;
        private int partialBlock = 0;
        private ITileable parentQuarter; // Is a QuarterTile
        private ITileable roofTile;
        private IMaterial ground;
        private GasZone athmos;
        private GeneralMap map;

        #region Fields
        public Vector3 MyPosition { get => rootPosition;
            set
            {
                rootPosition = value;
                helperVector = new Vector2(value.X, value.Y);
            }
        }
        public string TextureID { get => textureid; set => textureid = value; }
        public bool Blocked => fullBlock;
        public int PartialBlockGrade { get => partialBlock; set => partialBlock = value; }
        public ITileable Parent { get => parentQuarter; set => parentQuarter = value; }
        public IMaterial Ground { get => ground; set => ground = value; }
        public IMaterial Roof { get => roofTile.Ground; }
        public GasZone Athmosphere => athmos;
        public ITileable RoofZone { get => roofTile; set => roofTile = value; }
        public long GameID => ID;
        public GeneralMap Map { get => map; set => map = value; }
        #endregion

        public Parteight(Vector3 root, GeneralMap map) : base("Part8")
        {
            helperVector = new Vector2(root.X, root.Y);
            this.map = map;
            rootPosition = root;
        }

        public void blockPosition(Vector2 position)
        {
            fullBlock = true; // Dieses Part8 ist jetzt geblockt
            partialBlock = 10; // Blocke das parteight vollständig ^^
        }

        public bool containsPosition(Vector2 position)
        {
            if (MyPosition == new Vector3(position, MyPosition.Z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // hat keine Kinder => gibt null zurück. 
        public ITileable getChild(Vector2 position)
        {
            return null;
        }

        // Muss für das kleinste Element nicht aufgerufen werden, weil dessen BlockStatus stets der höchste ist
        public void refreshBlockStatus()
        {
        }

        public IMaterial getRoofMaterial(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void changeAthmossphereComposition(string mode, Gas gas)
        {
            throw new NotImplementedException();
        }

        public Parteight getAtPosition(Vector2 position)
        {
            return this;
        }

        public bool isBlocked(Vector2 position)
        {
            return Blocked;
        }

        public void draw(SpriteBatch batch)
        {
            if (map.visible(this))
            {
                Vector2 drawPosition = map.relativeDrawPosition(helperVector);
                drawPosition.X *= 8;
                drawPosition.Y *= 8;
                batch.Draw(TextureManager.getInstance().GetTexture(textureid), drawPosition, Color.White);
            }
        }
    }
}
