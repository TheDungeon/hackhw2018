using HackHW2018.Firebase;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Nez;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackHW2018.Scenes
{
    public class LoadingScene : Scene
    {
        Entity waitingText;
        FirebaseEventBus eventBus;
        int amountOfPlayers = 0;

        public override void Initialize()
        {
            base.Initialize();

            addRenderer(new DefaultRenderer());
            clearColor = Color.White;

            // create the join button
            var sf = new NezSpriteFont(content.Load<SpriteFont>("mainfont"));

            var x = Core.graphicsDevice.PresentationParameters.BackBufferWidth / 2 - (sf.measureString("Players - x").X / 2);
            var y = Core.graphicsDevice.PresentationParameters.BackBufferHeight / 2 - (sf.measureString("Players - x").Y / 2);

            waitingText = createEntity("waiting-text");

            waitingText.addComponent(new Text(sf, "Players - " + amountOfPlayers, Vector2.Zero, Color.Black));
            waitingText.transform.setPosition(x, y);

            eventBus = new FirebaseEventBus();

            eventBus.ClearPlayers().Wait();
            var list = eventBus.GetInitialValues().Result;
        }
    }
}
