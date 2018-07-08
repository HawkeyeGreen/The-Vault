using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using The_Vault.Technic;
using The_Vault.World.Map.Tiles;
using The_Vault.World.Map;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Vault
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<QuarterTile> quarters;
        Localmap map;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //graphics.IsFullScreen = true;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.ApplyChanges();
            map = new Localmap();
            map.actualizeView(new Vector2(0, 0), graphics);

            quarters = new List<QuarterTile>();

            for (int x  = 0; x < 100; x++)
            {
                for(int y = 0; y < 100; y++)
                {
                    List<Parteight> upper = new List<Parteight>();
                    upper.Add(new Parteight(new Vector3(0 + x, 0 + y, 0), map));
                    //upper[0].TextureID = "Grass01";
                    upper.Add(new Parteight(new Vector3(0 + x, 0 + y, 0), map));
                    //upper[1].TextureID = "Grass01";

                    List<Parteight> lower = new List<Parteight>();
                    lower.Add(new Parteight(new Vector3(1 + x, 0 + y, 0), map));
                    lower.Add(new Parteight(new Vector3(1 + x, 0 + y, 0), map));
                    //lower[0].TextureID = "Grass01";
                    //lower[1].TextureID = "Grass01";

                    List<List<Parteight>> part8s = new List<List<Parteight>>();
                    part8s.Add(upper);
                    part8s.Add(lower);

                    quarters.Add(new QuarterTile(part8s));
                }
            }
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            TextureManager.getInstance().initialize(Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            foreach(QuarterTile quarter in quarters)
            {
                quarter.draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
