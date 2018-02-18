using Microsoft.Xna.Framework.Graphics;
using Nez;
using Nez.Sprites;
using Nez.Tiled;

namespace HackHW2018.Factories
{
    public static class BackgroundFactory
    {
        public static Entity MakeBackground(Scene scene)
        {
            var entity = scene.createEntity("background");

            var background = scene.content.Load<TiledMap>("dungeon");
            entity.addComponent(new TiledMapComponent(background));

            return entity;
        }
    }
}
