using HackHW2018.FSM.Player;
using HackHW2018.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace HackHW2018.Components
{
    public class PlayerController : Component, IUpdatable
    {
        public float MoveSpeed = 125;
        public float MaxHorizVelo = 350;
        public float MaxHorizVeloModifier = 1;
        public float Gravity = 1000;
        public float JumpVelocity = 120;
        public float MaxJumpHeight = 750;
        public float MaxJumpHeightModifier = 1;
        public Vector2 Velocity;

        public TiledMapMover Mover;
        public BoxCollider Collider;
        public Sprite<PlayerAnimationState> Sprite;

        public PlayerState RegularStateMachine;
        public SpeedModiferState SpeedState;

        public PlayerInput Input;

        public TiledMapMover.CollisionState CollisionState = new TiledMapMover.CollisionState();

        public override void OnAddedToEntity()
        {
            Mover = this.getComponent<TiledMapMover>();
            Collider = this.getComponent<BoxCollider>();
            RegularStateMachine = new GroundedState();
            SpeedState = new SpeedModiferState();
            Sprite = this.getComponent<Sprite<PlayerAnimationState>>();
            Input = this.getComponent<PlayerInput>();

            RegularStateMachine.Begin(this);
            SpeedState.Begin(this);

            base.OnAddedToEntity();
        }

        public void UpdateAnimation(PlayerAnimationState state)
        {
            Sprite.play(state);
        }

        public void PauseAnimation()
        {
            Sprite.pause();
        }

        public void ResumeAnimation()
        {
            Sprite.unPause();
        }

        public void Update()
        {
            var cam = entity.scene.camera;

            if (transform.position.X > cam.transform.position.X + cam.bounds.width / 2)
            {
                RegularStateMachine = new DeadDeadNotGoodState();
            }

            var nextStateMachine = RegularStateMachine.Update(this);
            var nextSpeedMachine = SpeedState.Update(this);

            if (nextStateMachine != RegularStateMachine)
            {
                RegularStateMachine.End(this);
                RegularStateMachine = nextStateMachine;
                RegularStateMachine.Begin(this);
            }

            if (Input.IsStopping())
            {
                SpeedState.AnimationFpsModifier = 0.33f;
                SpeedState.VelocityModifier = 0.33f;
            }

            else if (Input.IsStopping())
            {
                SpeedState.AnimationFpsModifier = 1f;
                SpeedState.VelocityModifier = 1f;
            }
        }
    }
}
