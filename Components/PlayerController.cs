using HackHW2018.FSM.Player;
using HackHW2018.State;
using Microsoft.Xna.Framework;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace HackHW2018.Components
{
    public class PlayerController : Component, IUpdatable
    {
        public float MoveSpeed = 125;
        public float Gravity = 1000;
        public float JumpVelocity = 1500;
        public Vector2 Velocity;

        public TiledMapMover Mover;
        public BoxCollider Collider;        
        public Sprite<PlayerAnimationState> Sprite;

        public PlayerState StateMachine;

        public TiledMapMover.CollisionState CollisionState = new TiledMapMover.CollisionState();

        public override void OnAddedToEntity()
        {            
            Mover = this.getComponent<TiledMapMover>();
            Collider = this.getComponent<BoxCollider>();
            StateMachine = new GroundedState();            
            Sprite = this.getComponent<Sprite<PlayerAnimationState>>();

            StateMachine.Begin(this);

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
            var nextStateMachine = StateMachine.Update(this);

            if (nextStateMachine != StateMachine)
            {
                StateMachine.End(this);
                StateMachine = nextStateMachine;
                StateMachine.Begin(this);
            }            
        }
    }
}
