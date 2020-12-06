using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MortalKombat
{
    class AnimatedSprite
    {
        public Texture2D jax { get; set; }
        public Texture2D liukang { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int totalFrames;
        private int currentUpdate;
        private int updatePerFrame = 5;

        private SpriteEffects flip = SpriteEffects.FlipVertically;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            jax = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            currentUpdate++;
            if (currentUpdate == updatePerFrame)
            {
                currentFrame++;
                if (currentFrame == totalFrames)
                    currentFrame = 0;

                currentUpdate = 0;
            }
            


        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = jax.Width / Columns;
            int height = jax.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width *2, height *2);

            spriteBatch.Begin();
            spriteBatch.Draw(jax, destinationRectangle, sourceRectangle, Color.White);

            //spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 3.1f, new Vector2(0,0), flip, 0f);

            spriteBatch.End();
        }
    }
}
