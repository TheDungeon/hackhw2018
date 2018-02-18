using HackHW2018.Components;
using System.Collections.Generic;

namespace HackHW2018.FSM.Player
{
    public class SpeedModiferState : PlayerState
    {
        private float _animationFpsModifier = 1;
        private PlayerController controller;

        public float AnimationFpsModifier
        {
            get => _animationFpsModifier;
            set
            {
                _animationFpsModifier = value;

                var jump = AnimationsFpses[PlayerAnimationState.Jumping];

                var run = AnimationsFpses[PlayerAnimationState.Running];

                controller.Sprite.getAnimation(PlayerAnimationState.Jumping).setFps(jump * _animationFpsModifier);
                controller.Sprite.getAnimation(PlayerAnimationState.Running).setFps(run * _animationFpsModifier);

                var currentAnimation = controller.Sprite.currentAnimation;
                controller.UpdateAnimation(PlayerAnimationState.Idle);
                controller.UpdateAnimation(currentAnimation);
            }
        }
        
        public float VelocityModifier = 1;
                
        Dictionary<PlayerAnimationState, float> AnimationsFpses;

        public override void Begin(PlayerController controller)
        {
            this.controller = controller;
            AnimationsFpses = new Dictionary<PlayerAnimationState, float>();

            var jump = controller.Sprite.getAnimation(PlayerAnimationState.Jumping).fps;
            AnimationsFpses[PlayerAnimationState.Jumping] = jump;

            var run = controller.Sprite.getAnimation(PlayerAnimationState.Running).fps;
            AnimationsFpses[PlayerAnimationState.Running] = run;

            controller.Sprite.getAnimation(PlayerAnimationState.Jumping).setFps(jump * AnimationFpsModifier);
            controller.Sprite.getAnimation(PlayerAnimationState.Running).setFps(run * AnimationFpsModifier);

            var currentAnimation = controller.Sprite.currentAnimation;
            controller.UpdateAnimation(PlayerAnimationState.Idle);
            controller.UpdateAnimation(currentAnimation);
        }

        public override void End(PlayerController controller)
        {
            controller.Sprite.getAnimation(PlayerAnimationState.Running).setFps(AnimationsFpses[PlayerAnimationState.Running]);
            controller.Sprite.getAnimation(PlayerAnimationState.Jumping).setFps(AnimationsFpses[PlayerAnimationState.Jumping]);
        }

        public override PlayerState Update(PlayerController controller)
        {
            controller.MaxHorizVeloModifier = VelocityModifier;
            controller.MaxJumpHeightModifier = VelocityModifier;

            return this;
        }
    }
}
