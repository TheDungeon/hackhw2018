using HackHW2018.Scenes;
using Nez;

namespace HackHW2018.FSM.SceneStates
{
    public class WaitingForPlayers : SceneState
    {
        LoadingScene loadingScene;

        public override void Begin(Scene scene)
        {
            loadingScene = scene as LoadingScene;
            loadingScene.EventBus.SetWaiting().Wait();
        }

        public override void End(Scene scene)
        {
        }

        public override SceneState Update(Scene scene)
        {
            loadingScene.Players = loadingScene.EventBus.FetchPlayers().Result;

            if (loadingScene.Players.Count >= 1)
            {
                return new StartGame();
            }

            return this;
        }
    }
}
