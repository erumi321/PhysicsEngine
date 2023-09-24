using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PhysicsEngine.BaseObjects
{
    public class Collider
    {
        internal Game1 game;
        public Vector2 offset;
        public GameObject parent;
        public Collider(Game1 g, Vector2 o, GameObject p)
        {
            game = g;
            offset = o;
            parent = p;
        }

        //public virtual bool CheckCollision(T other)
        //{
        //    return false;
        //}
    }
}
