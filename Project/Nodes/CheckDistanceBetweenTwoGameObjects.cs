using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class CheckDistanceBetweenTwoGameObjects : Node
    {
        private GameObject _gameObjectA;
        private GameObject _gameObjectB;

        private float _maxDistance = 20f;

        public float MaxDistance { get => _maxDistance; set => _maxDistance = value; }

        public CheckDistanceBetweenTwoGameObjects(GameObject gameObjectA, GameObject gameObjectB)
        {
            _gameObjectA = gameObjectA;
            _gameObjectB = gameObjectB;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            var direction = _gameObjectA.Position - _gameObjectB.Position;

            if (direction.Length() < _maxDistance)
                return NodeStatus.SUCCESS;

            return NodeStatus.FAILURE;
        }
    }
}