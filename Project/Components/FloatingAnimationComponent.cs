using System;
using UmbrellaToolsKit;
using Microsoft.Xna.Framework;

namespace Project.Components
{
    public class FloatingAnimationComponent : Component
    {
        private GameObject _gameObject;
        private float _speed = 5f;

        public FloatingAnimationComponent(GameObject gameObject) => _gameObject = gameObject;

        public override Status Tick(GameTime gameTime)
        {
            float timer = (float)gameTime.TotalGameTime.TotalSeconds;
            _gameObject.Origin.Y = MathF.Cos(timer * _speed) * 10f;

            return base.Tick(gameTime);
        }
    }

}

