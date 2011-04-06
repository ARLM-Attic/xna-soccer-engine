using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Core
{
    public class AnimatedSprite
    {
        private GamePlayer Player;
        private GameBall Ball;
        public List<Animation> animations = new List<Animation>();

        protected Texture2D texture;

        protected Rectangle sourceRectangle;

        protected Vector2 position;
        protected Vector2 velocity;
        protected Vector2 center;

        protected float scale;
        protected float rotation;

        protected SpriteBatch spriteBatch;

        protected int width;
        protected int height;

        public AnimatedSprite(GamePlayer player, SpriteBatch Batch, Texture2D texture, List<Animation> animations)
        {
            Player = player;
            spriteBatch = Batch;
            this.animations = animations;
            width = animations[(int)Player.Char.CurrentAnimation].FrameWidth;
            height = animations[(int)Player.Char.CurrentAnimation].FrameHeight;
            center = new Vector2(width / 2, height / 2);

            this.texture = texture;
            scale = 1.0f;
            rotation = 0.0f;

            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public AnimatedSprite(GameBall ball, SpriteBatch Batch, Texture2D texture, List<Animation> animations)
        {
            Ball = ball;
            spriteBatch = Batch;
            this.animations = animations;
            width = animations[(int)Ball.CurrentBall].FrameWidth;
            height = animations[(int)Ball.CurrentBall].FrameHeight;
            center = new Vector2(width / 2, height / 2);

            this.texture = texture;
            scale = 1.0f;
            rotation = 0.0f;

            sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
        }
        public virtual Texture2D Texture { get { return texture; } }
        public virtual float Scale { get { return scale; } }
        public virtual float Rotation { get { return rotation; } }
        public int Width { get { return width; } }
        public int Height { get { return height; } }

        public void Update(GameTime gameTime)
        {
            if (Player != null)
            {
                if (Player.Char.isAnimating)
                    animations[(int)Player.Char.CurrentAnimation].Update(gameTime);
            }
            else
            {
                animations[(int)Ball.CurrentBall].Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, Camera camera)
        {
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Deferred, SaveStateMode.None, camera.TransformMatrix);
            
            if (Player != null)
                spriteBatch.Draw(texture, new Vector2(Player.Char.WorldPoint.X, Player.Char.WorldPoint.Y), animations[(int)Player.Char.CurrentAnimation].CurrentFrameRect, Color.White);
            else
                spriteBatch.Draw(texture, new Vector2(Ball.BallPoint.X, Ball.BallPoint.Y), animations[(int)Ball.CurrentBall].CurrentFrameRect, Color.White);

            spriteBatch.End();
        }
    }
}
