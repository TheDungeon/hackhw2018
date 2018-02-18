using HackHW2018.Scenes;
using Nez;
namespace HackHW2018
{
    /// <summary>
    /// This is the main type for the game.
    /// </summary>
    public class MainGame : Core
    {        
        public MainGame()
            : base(windowTitle: "Fug.io")
        {
            Scene.setDefaultDesignResolution(1280, 720, Scene.SceneResolutionPolicy.FixedHeightPixelPerfect);
            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            scene = new MainScene();
            base.Initialize();
        }
    }
}
