using HackHW2018.Components;
using Nez;

namespace HackHW2018.FSM.Player
{
    public class AirborneState : PlayerState
    {
        public override void Begin(PlayerController controller)
        {
            controller.UpdateAnimation(PlayerAnimationState.Jumping);
            controller.Velocity.Y = -Mathf.sqrt(2 * controller.JumpVelocity * controller.Gravity);
        }

        public override void End(PlayerController controller)
        {
            controller.Velocity.Y = 0;
        }

        public override PlayerState Update(PlayerController controller)
        {             
            controller.Velocity.Y += Time.deltaTime * controller.Gravity;
            controller.Velocity.X += controller.MoveSpeed * Time.deltaTime;

            if (controller.Velocity.X > controller.MaxHorizVelo)
            {
                controller.Velocity.X = controller.MaxHorizVelo * controller.MaxHorizVeloModifier;
            }

            if (controller.Velocity.X > controller.MaxJumpHeight * controller.MaxJumpHeightModifier)
            {
                controller.Velocity.X = controller.MaxJumpHeight * controller.MaxJumpHeightModifier;
            }

            controller.Mover.move(controller.Velocity * Time.deltaTime, controller.Collider, controller.CollisionState);            

            if (controller.CollisionState.below) // if a quarter second passed + is colliding with ground
            {
                return new GroundedState();
            }

            return this;
        }
    }
}
