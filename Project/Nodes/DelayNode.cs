using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class DelayNode : Node
    {
        private float _timer = 0f;
        private Node _node;

        public DelayNode(Node node, float delayTime)
        {
            _node = node;
            _timer = delayTime;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            _timer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            return _timer <= 0f ? _node.Tick(gameTime) : NodeStatus.FAILURE;
        }
    }
}