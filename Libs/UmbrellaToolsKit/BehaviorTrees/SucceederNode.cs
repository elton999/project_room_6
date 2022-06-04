using System;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit.BehaviorTrees
{
    public class SucceederNode : DecoratorNode
    {
        public SucceederNode(Node node) : base(node) { }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_node.Tick(gameTime) == NodeStatus.RUNNING)
                return NodeStatus.RUNNING;

            return NodeStatus.SUCCESS;
        }
    }
}
