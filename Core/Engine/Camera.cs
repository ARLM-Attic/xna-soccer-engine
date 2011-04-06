using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Core
{
    public class Camera
    {
        public Vector2 Position;

        public Camera(Vector2 position)
        {
            this.Position = position;
        }

        public Camera()
        {
            this.Position = Vector2.Zero;
        }

        public Matrix TransformMatrix
        {
            get
            {
                return Matrix.CreateTranslation(new Vector3(-Position, 0f));
            }
        }

        public void LockToSprite(Character Char)
        {
            Position.X = Char.WorldPoint.X + -(800 / 2);
            Position.Y = Char.WorldPoint.Y + -(600 / 2);
        }

        public void LockCamera()
        {
           /* Position.X = MathHelper.Clamp(
                Position.X,
                0,
                TileMapComponent.WidthInPixels - 800);
            Position.Y = MathHelper.Clamp(
                Position.Y,
                0,
                TileMapComponent.HeightInPixels - 600);*/
        }
    }
}
