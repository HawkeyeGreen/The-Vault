using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using The_Vault.Technic;

namespace The_Vault.World.Map.Tiles
{
    class Parteight : GameObject,ITileable
    {
        private Vector2 position;
        private string textureid = "NotFound";
        private bool fullBlock = false;
        private int partialBlock = 0;

        public Vector2 MyPosition { get => position; set => position = value; }
        public string TextureID { get => textureid; set => textureid = value; }
        public bool Blocked => fullBlock;
        public int PartialBlockGrade => partialBlock;

        public Parteight() : base("Part8")
        {

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
            return this;
        }

        public void refreshBlockStatus()
        {
            throw new NotImplementedException();
        }
    }
}
