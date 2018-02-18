using HackHW2018.Components;

namespace HackHW2018.FSM.Player
{
    public abstract class PlayerState
    {
        public abstract void Begin(PlayerController controller);
        public abstract PlayerState Update(PlayerController controller);
        public abstract void End(PlayerController controller);
    }
}
