using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit
{
    public class Component
    {
        public List<Component> Next = new List<Component>();

        public virtual void Update(GameTime gameTime)
        {
            for (int i = 0; i < Next.Count; i++)
                Next[i]?.Update(gameTime);
        }

        public virtual void UpdateData(GameTime gameTime)
        {
            for (int i = 0; i < Next.Count; i++)
                Next[i]?.UpdateData(gameTime);
        }

        public void Add(Component component) => Next.Add(component);

        public void Remove(Component component) => Next.Remove(component);

    }
}