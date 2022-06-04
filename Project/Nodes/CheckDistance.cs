using Microsoft.Xna.Framework;
using UmbrellaToolsKit;

namespace Project.Components
{
    public class CheckDistance : Component
    {
        private GameObject _gameObjectA;
        private GameObject _gameObjectB;

        private float _maxDistance = 20f;

        public CheckDistance(GameObject gameObjectA, GameObject gameObjectB)
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