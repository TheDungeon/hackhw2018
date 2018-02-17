using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HackHW2018
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Core : Game
    {
        public GraphicsDeviceManager Graphics;
        public SpriteBatch SpriteBatch;

        private Scene _currentScene;
        private Scene _nextScene;

        public Scene Scene
        {
            get => _currentScene;
            set => _nextScene = value;
        }
        
        public Core()
        {
            Graphics = new GraphicsDeviceManager(this);

            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;            
            Graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }

        private void OnClientSizeChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void Initialize()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);            

            base.Initialize();
        }
        
        protected override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            

            base.Draw(gameTime);
        }
    }
}
