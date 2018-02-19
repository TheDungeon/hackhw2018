using HackHW2018.Factories;
using HackHW2018.Firebase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using System.Collections.Generic;

namespace HackHW2018.Scenes
{
    public class MainScene : Scene
    {
        public int MapWidth = 0;
        float TimePassed = 0;
        public bool Paused = false;
        public FirebaseEventBus EventBus;

        public List<FirebasePlayerFormat> Players;

        public MainScene(List<FirebasePlayerFormat> list)
        {
            Players = list;
            addRenderer(new DefaultRenderer());
            EventBus = new FirebaseEventBus();
        }

        public override void Initialize()
        {            
            samplerState = SamplerState.PointClamp;

            var background = BackgroundFactory.MakeBackground(this);
            var tiledMap = background.getComponent<TiledMapComponent>();

            ScenePopulationFactory.PopulateScene(this, tiledMap.tiledMap.getObjectGroup("EntityLayer"));

            MapWidth = (int)tiledMap.width;

            var player1 = PlayerFactory.MakePlayer(this);
            //var player2 = PlayerFactory.MakePlayer(this);
            //var player3 = PlayerFactory.MakePlayer(this);
            //var player4 = PlayerFactory.MakePlayer(this);

            base.Initialize();
        }


        public override void Update()
        {
            if (!Paused)
            {
                TimePassed += Time.deltaTime;

                Vector2 nextCameraPosition = new Vector2(camera.transform.position.X, camera.transform.position.Y);

                if (TimePassed >= 1.0f)
                {
                    nextCameraPosition.X += 4;
                }

                if (nextCameraPosition.X + camera.bounds.width > MapWidth)
                {
                    nextCameraPosition.X = MapWidth - camera.bounds.width;
                }

                camera.transform.setPosition(nextCameraPosition);

                base.Update();
            }


            if (Input.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.S))
                Paused = !Paused;
        }
    }
}
