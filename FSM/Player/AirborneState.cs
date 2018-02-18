using HackHW2018.Components;
using HackHW2018.State;
using Microsoft.Xna.Framework;
using Nez;

namespace HackHW2018.FSM.Player
{
    public class AirborneState : PlayerState
    {       
        bool Peaked = false;
        int Sign = 1;
        
        public override void Begin(PlayerController controller)
        {
            controller.UpdateAnimation(PlayerAnimationState.Jumping);
        }

        public override void End(PlayerController controller)
        {
            controller.Velocity.Y = 0;
        }

        public override PlayerState Update(PlayerController controller)
        {
            controller.Velocity.Y -= (controller.JumpVelocity * Time.deltaTime) * Sign;
            controller.Velocity.Y += Time.deltaTime * controller.Gravity;

            controller.Mover.move(controller.Velocity * Time.deltaTime, controller.Collider, controller.CollisionState);

            if (controller.Velocity.Y < -500)
            {
                Sign *= -1;
                Peaked = true;
            }

            if (Peaked && controller.CollisionState.below) // if a quarter second passed + is colliding with ground
            {
                return new GroundedState();
            }

            return this;
        }
    }
}
