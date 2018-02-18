using HackHW2018.Scenes;
using Nez;
namespace HackHW2018
{
    /// <summary>
    /// This is the main type for the game.
    /// </summary>
    public class MainGame : Core
    {
        Scene.SceneResolutionPolicy policy;

        public MainGame()
            : base(windowTitle: "Fug.io")
        {
            
        }

        protected override void Initialize()
        {
            scene = new MainScene();
            base.Initialize();
        }
    }
}
