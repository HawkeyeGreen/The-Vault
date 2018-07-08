using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using The_Vault.World.Materials;
using Microsoft.Xna.Framework.Graphics;

namespace The_Vault.World.Map.Tiles
{
    interface ITileable
    {
        long GameID { get; }
        Vector3 MyPosition { get; set; }
        bool Blocked { get; }
        int PartialBlockGrade { get; set; }
        ITileable Parent { get; set; }
        IMaterial Ground { get; set; }
        IMaterial Roof { get; }
        ITileable RoofZone { get; set; }
        GasZone Athmosphere { get; }
        GeneralMap Map { get; set; }

        void blockPosition(Vector2 position);
        ITileable getChild(Vector2 position);
        bool containsPosition(Vector2 position);
        bool isBlocked(Vector2 position);
        void refreshBlockStatus();
        IMaterial getRoofMaterial(Vector2 position);
        void changeAthmossphereComposition(string mode, Gas gas);
        Parteight getAtPosition(Vector2 position);
        void draw(SpriteBatch batch);
    }
}
