using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core
{
    public class GameStadium
    {
        public Texture2D TextureTemplate;
        public Texture2D TextureGrass;
        protected SpriteBatch spriteBatch;

        public GameStadium(SpriteBatch SpriteBatch, Texture2D textureTemplate, Texture2D textureGrass)
        {
            spriteBatch = SpriteBatch;
            TextureTemplate = textureTemplate;
            TextureGrass = textureGrass;
        }

        public void Draw(GameTime gameTime, Camera camera)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None, camera.TransformMatrix);

            for (int x = 0; x < TextureTemplate.Height; x += TextureGrass.Height)
            {
                for (int y = 0; y < TextureTemplate.Width; y += TextureGrass.Width)
                {
                    spriteBatch.Draw(TextureGrass, new Vector2(y, x), Color.White);
                }
            }

            spriteBatch.Draw(TextureTemplate, Vector2.Zero, Color.White);

            spriteBatch.End();
        }
    }
}
