using System;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit.BehaviorTrees
{
    public class InverterNode : DecoratorNode
    {
        public InverterNode(Node node) : base(node){}

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_node.Tick(gameTime) == NodeStatus.FAILURE)
                return NodeStatus.SUCCESS;

            if (_node.Tick(gameTime) == NodeStatus.SUCCESS)
                return NodeStatus.FAILURE;

            return NodeStatus.RUNNING;
        }
    }
}
