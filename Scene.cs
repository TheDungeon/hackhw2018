using Microsoft.Xna.Framework.Graphics;

namespace HackHW2018
{
    /// <summary>
    /// This is the base class for all the scenes.
    /// A scene could be a level, menu, etc...
    /// A scene owns entities, which are game objects.   
    /// </summary>
    public abstract class Scene
    {
        /// <summary>
        /// This is a reference to the Core class of the game.
        /// Use this to reference the SpriteBatch (which is used for drawing)
        /// or to reference GraphicsDevice which is used for setting the render target.
        /// </summary>
        private Core _core;

        /// <summary>
        /// This is a MonoGame representation of a back buffer.
        /// Read http://gameprogrammingpatterns.com/double-buffer.html for more information.
        /// </summary>
        private RenderTarget2D _renderTarget;
    }
}
