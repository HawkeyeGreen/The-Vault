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
    class QuarterTile : GameObject, ITileable
    {
        private List<List<Parteight>> children;
        private List<Parteight> linearChildren;
        private Vector3 rootPosition;
        private Vector2 helperVector2;
        private Tile parentTile;
        private Rectangle rectangle;
        private bool fullBlock;
        private bool uniformedBlock;
        private GeneralMap map;


        #region fields

        public Vector3 MyPosition
        {
            get => rootPosition;
            set
            {
                rootPosition = value;
                helperVector2 = new Vector2(value.X, value.Y);
            }
        }
        public string TextureID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool Blocked => fullBlock;

        public int PartialBlockGrade { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITileable Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IMaterial Ground { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IMaterial Roof => throw new NotImplementedException();

        public ITileable RoofZone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public GasZone Athmosphere => throw new NotImplementedException();

        public long GameID => ID;

        public GeneralMap Map { get => map; set => map = value; }

        public Parteight getAtPosition(Vector2 position)
        {
            throw new NotImplementedException();
        }

        #endregion

        public QuarterTile(List<List<Parteight>> children) : base("QuarterTile")
        {
            rootPosition = children[0][0].MyPosition;
            map = children[0][0].Map;
            linearChildren = new List<Parteight>();

            this.children = children;
            foreach(List<Parteight> parts in children)
            {
                foreach (Parteight child in parts)
                {
                    child.Parent = this;
                    linearChildren.Add(child);
                }
            }
            helperVector2 = new Vector2(rootPosition.X, rootPosition.Y);
            Point sides = new Point(2, 2); // 2 x 2 PartEights
            rectangle = new Rectangle(helperVector2.ToPoint(), sides);
        }

        public void blockPosition(Vector2 position)
        {
            Vector2 difference = getDiffVector(position);
            children[(int)difference.X][(int)difference.Y].blockPosition(position);
            refreshBlockStatus();
        }

        public bool containsPosition(Vector2 position)
        {
            return rectangle.Contains(position);
        }

        public ITileable getChild(Vector2 position)
        {
            Vector2 difference = getDiffVector(position);
            return children[(int)difference.X][(int)difference.Y];
        }

        public void refreshBlockStatus()
        {
            fullBlock = children[0][0].Blocked & children[0][1].Blocked & children[1][0].Blocked & children[1][1].Blocked;
            if(children[0][0].Blocked == children[0][1].Blocked == children[1][0].Blocked == children[1][1].Blocked)
            {
                uniformedBlock = true;
            }
        }

        public IMaterial getRoofMaterial(Vector2 position)
        {
            throw new NotImplementedException();
        }

        public void changeAthmossphereComposition(string mode, Gas gas)
        {
            throw new NotImplementedException();
        }

        public bool isBlocked(Vector2 position)
        {
            if(uniformedBlock == true)
            {
                return Blocked;
            }
            else
            {
                Vector2 difference = getDiffVector(position);
                return children[(int)difference.X][(int)difference.Y].Blocked;
            }
        }

        private Vector2 getDiffVector(Vector2 position) => position - helperVector2;

        public void draw(SpriteBatch batch)
        {
            if(map.visible(this))
            {
                foreach (Parteight part8 in linearChildren) { part8.draw(batch); }
            }
        }
    }
}
