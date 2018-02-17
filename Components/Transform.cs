using Microsoft.Xna.Framework;

namespace HackHW2018.Components
{
    /// <summary>
    /// This class represents the position of an object relative to the world.
    /// 
    /// </summary>
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Scale;
        public float Rotation;

        public Transform(Entity entity, Vector2 position, Vector2 scale, float rotation)
            :base(entity)
        {
            Position = position;
            Scale = scale;
            Rotation = rotation;
        }

        public override void Render()
        {
        }

        public override void Update()
        {
        }
    }
}
