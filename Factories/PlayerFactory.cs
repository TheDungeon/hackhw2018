using Nez;

namespace HackHW2018.Factories
{
    public static class PlayerFactory
    {
        public static Entity MakePlayer(Scene scene, int playerIndex)
        {
            var entity = scene.createEntity(playerIndex.ToString());

            return entity;
        }
    }
}
