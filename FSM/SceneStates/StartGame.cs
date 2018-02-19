using HackHW2018.Scenes;
using Nez;

namespace HackHW2018.FSM.SceneStates
{
    public class StartGame : SceneState
    {
        public override void Begin(Scene scene)
        {
            (scene as LoadingScene).EventBus.SetWaitingFalse().Wait();
        }

        public override void End(Scene scene)
        {
        }

        public override SceneState Update(Scene scene)
        {
            return this;
        }
    }
}
