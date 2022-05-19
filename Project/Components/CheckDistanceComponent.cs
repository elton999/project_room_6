using Microsoft.Xna.Framework;
using UmbrellaToolsKit;

namespace Project.Components
{
    public class CheckDistanceComponent : Component
    {
        private GameObject _gameObjectA;
        private GameObject _gameObjectB;

        private float _maxDistance = 20f;

        public float MaxDistance { get => _maxDistance; set => _maxDistance = value; }

        public CheckDistanceComponent(GameObject gameObjectA, GameObject gameObjectB)
        {
            _gameObjectA = gameObjectA;
            _gameObjectB = gameObjectB;
        }

        public override Status Tick(GameTime gameTime)
        {
            var direction = _gameObjectA.Position - _gameObjectB.Position;

            if (direction.Length() < _maxDistance)
                return Status.FAILURE;

            return Status.SUCCESS;
        }
    }
}