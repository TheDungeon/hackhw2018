using HackHW2018.Collections;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace HackHW2018
{
    /// <summary>
    /// This is the base class for all the scenes.
    /// A scene could be a level, menu, etc...
    /// A scene owns entities, which are game objects.   
    /// </summary>
    public abstract class Scene : IDisposable
    {
        /// <summary>
        /// This is a reference to the Core class of the game.
        /// Use this to reference the SpriteBatch (which is used for drawing)
        /// or to reference GraphicsDevice which is used for setting the render target.
        /// </summary>
        public Core Core;

        /// <summary>
        /// This is a MonoGame representation of a back buffer.
        /// Read http://gameprogrammingpatterns.com/double-buffer.html for more information.
        /// </summary>
        protected RenderTarget2D RenderTarget;

        /// <summary>
        /// Each scene should have their own content manager.
        /// </summary>
        protected ContentManager ContentManager;

        /// <summary>
        /// This is a managed list of all the entities in this scene.
        /// </summary>
        protected EntityList Entities;

        public Scene(Core core, int sceneWidth, int sceneHeight)
        {
            Core = core;
            ContentManager = new ContentManager(core.Services);
            RenderTarget = new RenderTarget2D(core.GraphicsDevice, sceneWidth, sceneHeight);
        }

        public virtual void Dispose()
        {
            RenderTarget.Dispose();
            ContentManager.Dispose();
        }

        public virtual void Begin()
        {
            Core.GraphicsDevice.SetRenderTarget(RenderTarget);
        }

        public virtual void End()
        {            
        }

        public virtual void PreUpdate()
        {
            Entities.UpdateLists();
        }

        public virtual void Update()
        {
            Entities.Update();
        }

        public virtual void PostUpdate()
        {
        }

        public virtual void PreRender()
        {
            Core.GraphicsDevice.SetRenderTarget(RenderTarget);
            Core.SpriteBatch.Begin();
        }

        public virtual void Render()
        {
            Entities.Render();
        }

        public virtual void PostRender()
        {
            Core.SpriteBatch.End();
        }
    }
}
