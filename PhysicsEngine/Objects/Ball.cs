using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PhysicsEngine.BaseObjects;

namespace PhysicsEngine.Objects
{
    internal class Ball : GameObject
    {
        internal Texture2D ballTexture;
        internal float simulationSpeed;
        public Ball(Game1 g, Vector2 pos, float speed)
        {
            position = pos;
            simulationSpeed = speed;
        }

        public override void LoadContent(Game1 g)
        {
            ballTexture = g.LoadNewContent<Texture2D>("triangle");
        }
        public override void Update(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, GameTime gameTime, KeyboardState kstate)
        {

            if (kstate.IsKeyDown(Keys.Up))
            {
                position.Y -= simulationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Down))
            {
                position.Y += simulationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Left))
            {
                position.X -= simulationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Right))
            {
                position.X += simulationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }

            if (position.X > graphics.PreferredBackBufferWidth - ballTexture.Width / 2)
            {
                position.X = graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
            }
            else if (position.X < ballTexture.Width / 2)
            {
                position.X = ballTexture.Width / 2;
            }

            if (position.Y > graphics.PreferredBackBufferHeight - ballTexture.Height / 2)
            {
                position.Y = graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
            }
            else if (position.Y < ballTexture.Height / 2)
            {
                position.Y = ballTexture.Height / 2;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ballTexture, position, null, Color.White, 0f, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
