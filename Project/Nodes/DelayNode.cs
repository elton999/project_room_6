using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class DelayNode : DecoratorNode
    {
        private float _timer = 0f;

        public DelayNode(Node node, float delayTime) : base(node) => _timer = delayTime;

        public override NodeStatus Tick(GameTime gameTime)
        {
            _timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            return _timer <= 0f ? _node.Tick(gameTime) : NodeStatus.RUNNING;
        }
    }
}