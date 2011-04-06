using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using Core.Enums;

namespace Core
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Core : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Core()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        public static Point VectorToCell(Vector2 vector)
        {
            return new Point(
                        (int)(vector.X / 128),
                        (int)(vector.Y / 128));
        }

        public static Vector2 ViewPortVector
        {
            get
            {
                return new Vector2(800 + 128,
                    600 + 128);
            }
        }

        public static Directions GetDirection(AnimationKey currentAnimation)
        {
            if (currentAnimation.ToString().Contains("North"))
                return Directions.North;
            else if (currentAnimation.ToString().Contains("West"))
                return Directions.West;
            else if (currentAnimation.ToString().Contains("Lest"))
                return Directions.Lest;
            else if (currentAnimation.ToString().Contains("South"))
                return Directions.South;

            return Directions.South;
        }
    }
}
