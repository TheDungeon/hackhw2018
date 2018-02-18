using HackHW2018.Components;

namespace HackHW2018.FSM.Player
{
    public class DeadDeadNotGoodState : PlayerState
    {
        public override void Begin(PlayerController controller)
        {
        }

        public override void End(PlayerController controller)
        {
        }

        public override PlayerState Update(PlayerController controller)
        {
            return this;
        }
    }
}
