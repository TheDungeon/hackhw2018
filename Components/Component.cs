using System;

namespace HackHW2018.Components
{
    public abstract class Component : IDisposable
    {
        private Entity _entity;

        public abstract void Update();
        public abstract void Render();

        public Component(Entity entity)
        {
            _entity = entity;
        }

        public void Dispose()
        {
        }
    }
}
