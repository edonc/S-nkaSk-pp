using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SänkaSkäpp
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        enum GameState : byte { Start, Game, End };
        GameState currentState;
        GameMap gameMap;
        Tile[,] waterTiles;
        Boat[] boats;
        Boat boat;
        Texture2D waterTexture;
        Texture2D boattext;

        public int Rand(int min, int max)
        {
            Random rand = new Random();

            return rand.Next(min, max);
        }

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = 700;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
            currentState = GameState.Start;
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

            gameMap = new GameMap(GraphicsDevice);
            waterTexture = Content.Load<Texture2D>("water");

            waterTiles = new Tile[10, 10];
            int x = Rand(0, 10) * 50;
            int y = Rand(0, 10) * 50;

            for (int i = 0; i < waterTiles.GetLength(0); i++)
            {
                for (int j = 0; j < waterTiles.GetLength(1); j++)
                {
                    Rectangle rect = new Rectangle(i * 50, j * 50, 50, 50);
                    waterTiles[i, j] = new Tile(rect);
                }
            }
            Texture2D boattext = Content.Load<Texture2D>("tileset");
            boat = new Boat(3, boattext, 0, new Vector2(0, 150));


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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();

            for (int i = 0; i < waterTiles.GetLength(0); i++)
            {
                for (int j = 0; j < waterTiles.GetLength(1); j++)
                {
                    waterTiles[i, j].Draw(spriteBatch, waterTexture);
                }
            }

            gameMap.DrawLines(spriteBatch, Color.Gray);

            //spriteBatch.Draw(boattext, boat.pos, null, Color.White, 0, boat.origin, );

            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
