﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MortalKombat
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        public int anchuraConsola = 1280, alturaConsola = 720;


        private Texture2D jax;
        private AnimatedSprite fightingStance_jax;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = anchuraConsola;
            graphics.PreferredBackBufferHeight = alturaConsola;
            
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            // TODO: use this.Content to load your game content here
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            background = Content.Load<Texture2D>(@"Sprites/background02");
            jax = Content.Load<Texture2D>(@"Sprites/stance_jax");
            fightingStance_jax = new AnimatedSprite(jax, 2, 4);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.F1))
                graphics.ToggleFullScreen();

            // TODO: Add your update logic here

            fightingStance_jax.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, anchuraConsola, alturaConsola), Color.White);

            spriteBatch.End();

            fightingStance_jax.Draw(spriteBatch, new Vector2(200, 520));
            base.Draw(gameTime);
        }
    }
}
