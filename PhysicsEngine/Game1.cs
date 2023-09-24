using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using PhysicsEngine.Objects;
using PhysicsEngine.BaseObjects;
using System.Diagnostics;
namespace PhysicsEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<GameObject> _objects;
        private List<PolygonCollider> _colliders;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        internal int RegisterCollider(PolygonCollider c)
        {
            _colliders.Add(c);
            return _colliders.Count;
        }

        internal int RegisterObject(GameObject o)
        {
            _objects.Add(o);
            return _objects.Count;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _objects = new List<GameObject>();
            _colliders = new List<PolygonCollider>();


            Ball pB = new Ball(this, new Vector2(_graphics.PreferredBackBufferWidth / 2 - 80f, _graphics.PreferredBackBufferHeight / 2), 20f);
            Ball pB2 = new Ball(this, new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), 0f);
            RegisterObject(pB);
            RegisterObject(pB2);

            PolygonCollider c_pB = new PolygonCollider(this, new Vector2(0, 0), pB, new Vector2(32f, 32f), 3);
            PolygonCollider c_pB2 = new PolygonCollider(this, new Vector2(0, 0), pB2, new Vector2(32f, 32f), 3);

            RegisterCollider(c_pB);
            RegisterCollider(c_pB2);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach(GameObject obj in _objects)
            {
                obj.LoadContent(this);
            }
            // TODO: use this.Content to load your game content here
        }

        public T LoadNewContent<T>(string name)
        {
            return Content.Load<T>(name);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            KeyboardState kstate = Keyboard.GetState();
            
            foreach(GameObject obj in _objects)
            {
                obj.Update(_graphics, _spriteBatch, gameTime, kstate);
            }

            for(int i = 0; i < _colliders.Count; i++)
            {
                //Debug.WriteLine(_colliders[i].parent.position);
                for (int j = i + 1; j < _colliders.Count; j++)
                {
                    bool b = _colliders[i].CheckCollision(_colliders[j]);
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();
            foreach(GameObject obj in _objects)
            {
                obj.Draw(_spriteBatch);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}