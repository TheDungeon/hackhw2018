using HackHW2018.Firebase;
using HackHW2018.FSM.SceneStates;
using Microsoft.Xna.Framework;
using Nez;
using System.Collections.Generic;

namespace HackHW2018.Scenes
{
    public class LoadingScene : Scene
    {
        public FirebaseEventBus EventBus;
        public List<FirebasePlayerFormat> Players;
        SceneState sceneState;

        public override void Initialize()
        {
            base.Initialize();
            addRenderer(new DefaultRenderer());
            sceneState = new WaitingForPlayers();
            Players = new List<FirebasePlayerFormat>();
            clearColor = Color.White;
            EventBus = new FirebaseEventBus();

            EventBus.ClearPlayers().Wait();
            sceneState.Begin(this);
        }

        public override void Update()
        {
            base.Update();

            var nextState = sceneState.Update(this);

            if (nextState != sceneState)
            {
                var lastState = sceneState;

                sceneState.End(this);
                sceneState = nextState;
                sceneState.Begin(this);
            }

            if (sceneState.GetType() == typeof(StartGame))
            {
                var mainScene = new MainScene(Players);                

                Core.scene = mainScene;
            }
        }
    }
}
