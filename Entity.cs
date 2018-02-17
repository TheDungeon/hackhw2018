using HackHW2018.Collections;
using HackHW2018.Components;
using HackHW2018.Utils;
using Microsoft.Xna.Framework;
using System;

namespace HackHW2018
{
    /// <summary>
    /// This represents an object in the game.
    /// Entities can own other objects and have components.
    /// All Entities will have a transform which represent their world position.
    /// Read http://gameprogrammingpatterns.com/component.html for more information.
    /// </summary>
    public class Entity : IDisposable
    {
        /// <summary>
        /// This is an entities personal reference to the scene.
        /// The entity may want to mutate the scene.
        /// Questioning this pattern because of decoupling.
        /// </summary>
        public Scene Scene;

        /// <summary>
        /// This is a transform component.
        /// Every entity is required to have it.
        /// Transforms describe position, scale, rotation, and the origin.
        /// </summary>
        public Transform Transform;

        /// <summary>
        /// This is a list of components this object owns.        
        /// </summary>
        public ComponentList Components;

        /// <summary>
        /// This must be set to true in order to render this entity.
        /// </summary>
        public bool Visible;

        /// <summary>
        /// This must be set to true in order to update this entity.
        /// </summary>
        public bool Updatable;

        public Entity(Scene scene)
        {
            Scene = scene;

            Transform = new Transform(this, new Vector2(0, 0), new Vector2(1, 1), 1);
        }

        /// <summary>
        /// This is called during the end of the lifetime of a scene.
        /// Use this for any clean up code you may have.
        /// </summary>
        public virtual void Dispose()
        {           
            foreach (var component in Components)
            {
                component.Dispose();
            }
            Components = null;
        }

        /// <summary>
        /// This is called during the Update(GameTime) portion of the main MonoGame loop.
        /// </summary>
        public virtual void Update()
        {
            Components.UpdateLists();
            Components.Update();
        }

        /// <summary>
        /// This method is called during the Draw(GameTime) portion of the main MonoGame loop.
        /// </summary>
        public virtual void Render()
        {
            Components.Update();
        }
    }
}
