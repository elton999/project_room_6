using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit
{
    public class Component
    {
        public Component Next;

        public virtual void Update(GameTime gameTime) => Next?.Update(gameTime);
        public virtual void UpdateData(GameTime gameTime) => Next?.UpdateData(gameTime);

        public void Add(Component component)
        {
            if (Next == null)
                Next = component;
            else
                Next.Add(component);
        }
    }
}