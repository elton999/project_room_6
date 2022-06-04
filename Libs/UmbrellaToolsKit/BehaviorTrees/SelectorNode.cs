using System;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit.BehaviorTrees
{
    public class SelectorNode : Node
    {
        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_nodes.Count == 0)
                throw new NullReferenceException();

            for (int i = 0; i < Count; i++)
            {
                if (_nodes[i].Tick(gameTime) == NodeStatus.RUNNING)
                    return NodeStatus.RUNNING;

                if (_nodes[i].Tick(gameTime) == NodeStatus.SUCCESS)
                    return NodeStatus.SUCCESS;
            }

            return NodeStatus.FAILURE;
        }
    }
}
