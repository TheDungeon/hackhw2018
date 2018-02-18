using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;

namespace HackHW2018.Factories
{
    public static class BackgroundFactory
    {
        public static Entity MakeBackground(Scene scene)
        {
            var entity = scene.createEntity("background");
            var background = scene.content.Load<Texture2D>("Background");

            entity.addComponent(new Sprite(background));
            entity.transform.position = new Microsoft.Xna.Framework.Vector2(0, 0);

            return entity;
        }
    }
}
