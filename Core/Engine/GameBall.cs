using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Core.Enums;

namespace Core
{
    public class GameBall
    {
        public Point BallPoint = new Point();
        public Balls CurrentBall = Balls.NormalBall;
        public AnimatedSprite Sprite;

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
