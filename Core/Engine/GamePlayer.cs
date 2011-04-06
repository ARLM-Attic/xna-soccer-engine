using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Core
{
    public class GamePlayer
    {
        public Character Char;
        public AnimatedSprite Sprite;

        public GamePlayer()
        {
            Char = new Character(this);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, Camera camera)
        {
            Sprite.Draw(gameTime, camera);
        }
    }
}
