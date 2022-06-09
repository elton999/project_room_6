using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class ResetShakeSpriteNode : Node
    {
        public GameObject _gameObject;

        public ResetShakeSpriteNode(GameObject gameObject) => _gameObject = gameObject;

        public override NodeStatus Tick(GameTime gameTime)
        {
            _gameObject.Origin = Vector2.Zero;
            return NodeStatus.SUCCESS;
        }
    }
}

