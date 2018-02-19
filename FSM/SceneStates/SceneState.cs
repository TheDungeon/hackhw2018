using Nez;

namespace HackHW2018.FSM.SceneStates
{
    public abstract class SceneState
    {
        public abstract void Begin(Scene scene);
        public abstract void End(Scene scene);
        public abstract SceneState Update(Scene scene);
    }
}
