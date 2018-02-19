using HackHW2018.Components;
using Microsoft.Xna.Framework.Input;
using Nez;
using System;

namespace HackHW2018.FSM.Player
{
    public class GroundedState : PlayerState
    {

        public override void Begin(PlayerController controller)
        {
            controller.UpdateAnimation(PlayerAnimationState.Running);
        }

        public override void End(PlayerController controller)
        {
        }

        public override PlayerState Update(PlayerController controller)
        {
            controller.Velocity.X += Math.Min(controller.MoveSpeed * Time.deltaTime, 750);
            controller.Velocity.Y += Time.deltaTime * controller.Gravity;

            if (controller.Velocity.X > controller.MaxHorizVelo * controller.MaxHorizVeloModifier)
            {
                controller.Velocity.X = controller.MaxHorizVelo * controller.MaxHorizVeloModifier;
            }

            controller.Mover.move(controller.Velocity * Time.deltaTime, controller.Collider, controller.CollisionState);

            if (controller.CollisionState.below)
            {
                controller.Velocity.Y = 0;
            }

            if (Input.isKeyReleased(Keys.Space))
            {
                return new AirborneState();
            }

            return this;
        }
    }
}
