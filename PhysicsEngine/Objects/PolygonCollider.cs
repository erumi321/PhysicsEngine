using PhysicsEngine.BaseObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PhysicsEngine.Objects
{
    internal class PolygonCollider : Collider
    {
        public int width;
        public int height;
        public int sides;
        public PolygonCollider(Game1 game, Vector2 offset, GameObject parent, Vector2 size, int sides) : base(game, offset, parent)
        {
            this.width = (int)size.X;
            this.height = (int)size.Y;
            this.sides = sides;
        }

        public bool CheckCollision(PolygonCollider other)
        {
            int i = 0;
            for(int x = width + (int)offset.X + (int)parent.position.X; x > -width + (int)offset.X + (int)parent.position.X; x--)
            {
                for(int y = height + (int)offset.Y + (int)parent.position.Y; y > -height + (int)offset.Y + (int)parent.position.Y; y--)
                {
                    double x1 = (Math.Pow(x - (int)offset.X - (int)parent.position.X, 2) / Math.Pow(width, 2));
                    double y1 = (Math.Pow(y - (int)offset.Y - (int)parent.position.Y, 2) / Math.Pow(height, 2));
                    double a1 = Math.Atan2((y - offset.Y - parent.position.Y) * width, (x - offset.X - parent.position.Y) * height) - (0.5 * Math.PI * (Math.Sign(x - offset.X - parent.position.X) - 1));
                    double d1 = Math.Pow(Math.Cos(Math.PI / sides) * (1 / Math.Cos((Math.PI - Math.Acos(Math.Cos(sides * a1))) / sides)), 2);
                    double s1 = x1 + y1 - d1;
                    double x2 = (Math.Pow(x - (int)other.offset.X - other.parent.position.X, 2) / Math.Pow(other.width, 2));
                    double y2 = (Math.Pow(y - (int)other.offset.Y - other.parent.position.Y, 2) / Math.Pow(other.height, 2));
                    double a2 = Math.Atan2((y - other.offset.Y - other.parent.position.Y) * other.width, (x - other.offset.X - other.parent.position.X) * other.height) - (0.5 * Math.PI * (Math.Sign(x - other.offset.X - other.parent.position.X) - 1));
                    double d2 = Math.Pow(Math.Cos(Math.PI / other.sides) * (1 / Math.Cos((Math.PI - Math.Acos(Math.Cos(other.sides * a2))) / other.sides)), 2);
                    double s2 = x2 + y2 - d2;

                    double i1 = s1 - Math.Abs(s1);
                    double i2 = s2 - Math.Abs(s2);

                    if (i1 * i2 > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
