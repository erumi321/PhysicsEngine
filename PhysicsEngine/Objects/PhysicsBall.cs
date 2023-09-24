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
    internal class PhysicsBall : Ball
    {
        Vector2 ballVelocity;

        public PhysicsBall(Game1 g, Vector2 pos, Vector2 velocity, float speed) : base(g, pos, speed)
        {
            ballVelocity = velocity;
        }
        //public void LoadContent(Game1 g)
        //{
        //    ballTexture = g.LoadNewContent<Texture2D>("ball");
        //}
        public override void Update(GraphicsDeviceManager graphics, SpriteBatch spriteBatch, GameTime gameTime, KeyboardState kstate)
        {
            ballVelocity.Y += 9.81f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += ballVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds * simulationSpeed;

            if (position.X > graphics.PreferredBackBufferWidth - ballTexture.Width / 2 && ballVelocity.X > 0)
            {
                //ballPosition.X = graphics.PreferredBackBufferWidth - ballTexture.Width / 2;
                ballVelocity.X *= -1;
            }
            else if (position.X < ballTexture.Width / 2 && ballVelocity.X < 0)
            {
                //ballPosition.X = ballTexture.Width / 2;
                ballVelocity.X *= -1;
            }

            if (position.Y > graphics.PreferredBackBufferHeight - ballTexture.Height / 2 && ballVelocity.Y > 0)
            {
                //ballPosition.Y = graphics.PreferredBackBufferHeight - ballTexture.Height / 2;
                ballVelocity.Y += 9.81f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                ballVelocity.Y *= -1;
            }
            else if (position.Y < ballTexture.Height / 2 && ballVelocity.Y < 0)
            {
                //ballPosition.Y = ballTexture.Height / 2;
                ballVelocity.Y -= 9.81f * (float)gameTime.ElapsedGameTime.TotalSeconds;
                ballVelocity.Y *= -1;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ballTexture, position, null, Color.Blue, 0f, new Vector2(ballTexture.Width / 2, ballTexture.Height / 2), Vector2.One, SpriteEffects.None, 0f);
        }
    }
}
