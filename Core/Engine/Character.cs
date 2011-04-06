using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Core
{
    public class Character
    {
        public Character(GamePlayer player)
        {
            Player = player;
        }

        public GamePlayer Player;
        public AnimationKey CurrentAnimation = AnimationKey.RunLest;
        public Point WorldPoint = new Point(500, 235);
        public Directions Direction { get { return Core.GetDirection(CurrentAnimation); } }
        public bool isAnimating = false;
        public bool isShooting { get { return CurrentAnimation.ToString().Contains("Shoot"); } }
        public bool isTacking { get { return CurrentAnimation.ToString().Contains("Tackle"); } }
        public DateTime LastSpecial = DateTime.Now;
        public DateTime LastAction = DateTime.Now;

        public void Move(Keys[] PresKeys)
        {
            int walkValue = 1;
            Point motion = Point.Zero;

            foreach (Keys key in PresKeys)
            {
                if (key == Keys.Up) motion.Y -= walkValue;
                if (key == Keys.Left) motion.X -= walkValue;
                if (key == Keys.Right) motion.X += walkValue;
                if (key == Keys.Down) motion.Y += walkValue;
            }

            if (isShooting || isTacking)
            {
                switch (Direction)
                {
                    case Directions.North:
                        motion.Y -= walkValue;
                        break;
                    case Directions.West:
                        motion.X -= walkValue;
                        break;
                    case Directions.Lest:
                        motion.X += walkValue;
                        break;
                    case Directions.South:
                        motion.Y += walkValue;
                        break;
                }
            }

            if (motion != Point.Zero)
            {
                isAnimating = true;

                WorldPoint.X += motion.X;
                WorldPoint.Y += motion.Y;

              //  IdleAnimation();
            }
            else
            {
                isAnimating = false;
                IdleAnimation();
            }
        }

        public void IdleAnimation()
        {
            isAnimating = false;
            string anime = CurrentAnimation.ToString();
            if (anime.Contains("North"))
                CurrentAnimation = AnimationKey.North;
            else if (anime.Contains("West"))
                CurrentAnimation = AnimationKey.West;
            else if (anime.Contains("Lest"))
                CurrentAnimation = AnimationKey.Lest;
            else
                CurrentAnimation = AnimationKey.South;
        }

        public void RunTo(Directions Dir)
        {
            if (Dir != Directions.Any)
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), "Run" + Dir.ToString(), true);
        }

        public void ShootTo(Directions Dir)
        {
            LastSpecial = DateTime.Now.AddMilliseconds(300);
            LastAction = DateTime.Now.AddMilliseconds(200);

            if (Dir != Directions.Any)
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), "Shoot" + Dir.ToString(), true);
            else
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), "Shoot" + Direction.ToString(), true);
        }

        public void TackleTo(Directions Dir)
        {
            LastSpecial = DateTime.Now.AddMilliseconds(800);
            LastAction = DateTime.Now.AddMilliseconds(350);

            if (Dir != Directions.Any)
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), "Tackle" + Dir.ToString(), true);
            else
                CurrentAnimation = (AnimationKey)Enum.Parse(typeof(AnimationKey), "Tackle" + Direction.ToString(), true);
        }
    }
}
