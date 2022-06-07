using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class RemoveGameObjectFromScene : Node
    {
        private GameObject _gameObject;
        public RemoveGameObjectFromScene(GameObject gameObject) => _gameObject = gameObject;

        public override NodeStatus Tick(GameTime gameTime)
        {
            _gameObject.RemoveFromScene = true;
            return NodeStatus.SUCCESS;
        }
    }
}