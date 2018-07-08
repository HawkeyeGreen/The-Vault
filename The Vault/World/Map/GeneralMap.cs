using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Vault.World.Map.Tiles;
using The_Vault.World.Map.Decorators;
using Microsoft.Xna.Framework;

namespace The_Vault.World.Map
{
    class GeneralMap
    {
        private Vector2 relativePosition;
        private Rectangle currentView;

        public void actualizeView(Vector2 leftUpperPosition,GraphicsDeviceManager graphicsDevice)
        {
            relativePosition = leftUpperPosition;
            int x = graphicsDevice.PreferredBackBufferWidth / 8;
            int y = graphicsDevice.PreferredBackBufferWidth / 8;
            currentView = new Rectangle(relativePosition.ToPoint(), new Point(x, y));
        }

        public bool visible(ITileable tile)
        {
            return currentView.Contains(new Vector2(tile.MyPosition.X, tile.MyPosition.Y));
        }

        public Vector2 relativeDrawPosition(Vector2 position)
        {
            return position - relativePosition;
        }
    }
}
