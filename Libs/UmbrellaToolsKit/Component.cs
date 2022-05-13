using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit
{
    public class Component
    {
        public enum Status { RUNNING, FAILURE, SUCCESS };

        public List<Component> Node = new List<Component>();

        public virtual Status Tick(GameTime gameTime)
        {
            for (int i = 0; i < Node.Count; i++)
            {
                var NodeStatus = Node[i]?.Tick(gameTime);

                if (NodeStatus == Status.RUNNING)
                    return Status.RUNNING;
                else if (NodeStatus == Status.FAILURE)
                    return Status.FAILURE;
            }

            return Status.SUCCESS;
        }

        public void Add(Component component) => Node.Add(component);

        public void Remove(Component component) => Node.Remove(component);

    }
}