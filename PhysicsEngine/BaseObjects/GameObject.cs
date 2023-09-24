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
    public abstract class GameObject
    {
        public Vector2 position;
        public abstract void Update(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, GameTime gameTime, KeyboardState kstate);
        public abstract void LoadContent(Game1 g);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
