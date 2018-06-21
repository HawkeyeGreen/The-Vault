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
    // Pixelgröße 8px*8px
    // IT Maße: 0.5m*05.m
    // Kleinste Ordnungseinheit

    class Parteight : GameObject,ITileable
    {
        private Vector2 position;
        private string textureid = "NotFound";
        private bool fullBlock = false;
        private int partialBlock = 0;
        private QuarterTile parentQuarter;
        private IMaterial ground;

        public Vector2 MyPosition { get => position; set => position = value; }
        public string TextureID { get => textureid; set => textureid = value; }
        public bool Blocked => fullBlock;
        public int PartialBlockGrade { get => partialBlock; set => partialBlock = value; }
        public ITileable Parent { get => parentQuarter; set => parentQuarter = QuarterTile.createQuarterTilefromInterface(value); }
        public IMaterial Ground { get => ground; set => ground = value; }

        public Parteight(QuarterTile parentQuarter) : base("Part8")
        {
            this.parentQuarter = parentQuarter;
        }

        public void blockPosition(Vector2 position)
        {
            fullBlock = true; // Dieses Part8 ist jetzt geblockt
            partialBlock = 10; // Blocke das parteight vollständig ^^
        }

        public bool containsPosition(Vector2 position)
        {
            if (MyPosition == position)
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
    }
}
