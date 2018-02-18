using HackHW2018.Factories;
using HackHW2018.State;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace HackHW2018.Scenes
{
    public class MainScene : Scene
    {
        public override void Initialize()
        {
            addRenderer(new DefaultRenderer());
            samplerState = SamplerState.PointClamp;

            var background = BackgroundFactory.MakeBackground(this);
            var player1 = PlayerFactory.MakePlayer(this);

            base.Initialize();
        }

        public override void Update()
        {
            camera.transform.setPosition(camera.transform.position.X + 3, camera.transform.position.Y);

            base.Update();
        }
    }
}
