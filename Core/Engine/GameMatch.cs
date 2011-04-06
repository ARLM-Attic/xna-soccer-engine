using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Core
{
    public class GameMatch
    {
        public SpriteBatch spriteBatch;
        public GameTeam HomeTeam;
        public GameTeam AwayTeam;
        public string Timer = "00:00";
        public DateTime MatchTime = DateTime.Now;
        public double Minutes = 5;
        public int Min = 0;
        public SpriteFont Font;
        public GameBall Ball;
        public GameStadium Stadium;

        public GameMatch(SpriteBatch SpriteBatch, SpriteFont font, GameTeam Home, GameTeam Away, GameStadium stadium, GameBall ball, double minutes)
        {
            spriteBatch = SpriteBatch;
            Font = font;
            HomeTeam = Home;
            AwayTeam = Away;
            Stadium = stadium;
            Ball = ball;
            Minutes = minutes;
        }

        public void StartMatch()
        {
            Timer = "0 minutes";
            MatchTime = DateTime.Now.AddSeconds(18);
        }

        public void Update(GameTime gameTime)
        {
            if (DateTime.Now > MatchTime)
            {
                MatchTime = DateTime.Now.AddSeconds(18);
                Min++;
                Timer = Min + " minutes";
            }

            Ball.Update(gameTime);
        }

        public void Draw(GameTime gameTime, Camera camera)
        {
            Stadium.Draw(gameTime, camera);

            Ball.Draw(gameTime, camera);

            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            spriteBatch.DrawString(Font, Timer, new Vector2(25, 8), Color.White);

            spriteBatch.End();
        }
    }
}
