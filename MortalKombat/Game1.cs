using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MortalKombat
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Texture2D background;
        public int anchuraConsola = 1280, alturaConsola = 720;

        //primer jugador
        private Texture2D stance_jax;
        private AnimatedSprite fightingStance_jax;
        private Texture2D walking_f_jax;
        private Texture2D walking_b_jax;
        private AnimatedSprite forwards_jax;
        private AnimatedSprite backwards_jax;
        private Vector2 player_position;
        private float player_speed;

        //segundo jugador
        private Texture2D stance_liukang;
        private AnimatedSprite fightingStance_liukang;
        private SpriteEffects flip = SpriteEffects.FlipVertically;

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
            player_speed = 250f;
            player_position = new Vector2(150, 420);
            graphics.IsFullScreen = false;

            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            
            //background
            background = Content.Load<Texture2D>(@"Sprites/background02");

            //jax
            stance_jax = Content.Load<Texture2D>(@"Sprites/stance_jax");
            fightingStance_jax = new AnimatedSprite(stance_jax, 2, 4);

            walking_f_jax = Content.Load<Texture2D>(@"Sprites/walking_f_jax");
            forwards_jax = new AnimatedSprite(walking_f_jax, 2, 4);

            walking_b_jax = Content.Load<Texture2D>(@"Sprites/walking_b_jax");
            backwards_jax = new AnimatedSprite(walking_b_jax, 2, 4);

            //liukang
            stance_liukang = Content.Load<Texture2D>(@"Sprites/stance_liukang");
            fightingStance_liukang = new AnimatedSprite(stance_liukang, 4, 4);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            var PlayerOneKeyState = Keyboard.GetState();

            if (PlayerOneKeyState.IsKeyDown(Keys.Left))
            {
                backwards_jax.Update();
                player_position.X -= player_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (PlayerOneKeyState.IsKeyDown(Keys.Right))
            {
                forwards_jax.Update();
                player_position.X += player_speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }


            if (player_position.X > graphics.PreferredBackBufferWidth - walking_f_jax.Width / 2)
                player_position.X = graphics.PreferredBackBufferWidth - walking_f_jax.Width / 2;

           else if (player_position.X < 0)
                player_position.X = 0;

            fightingStance_jax.Update();
            fightingStance_liukang.Update();
            
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var PlayerOneKeyState = Keyboard.GetState();
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, anchuraConsola, alturaConsola), Color.White);

            spriteBatch.End();

            if (PlayerOneKeyState.IsKeyDown(Keys.Left))
            {
                backwards_jax.Draw(spriteBatch, player_position);
            }
            else if (PlayerOneKeyState.IsKeyDown(Keys.Right))
            {
                forwards_jax.Draw(spriteBatch, player_position);
            }
            else
                fightingStance_jax.Draw(spriteBatch, player_position);


            fightingStance_liukang.Draw(spriteBatch, new Vector2(1050, 680), flip);

            base.Draw(gameTime);
        }
    }
}
