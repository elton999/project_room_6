using System;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;

namespace Project.Components
{
    public class FollowerComponent : Component
    {
        private Actor _target;
        private Actor _follower;
        private float _speed = 5f;
        private float _maxDistance = 20f;
        private Vector2 _oldPosition;

        public FollowerComponent(Actor target, Actor follower)
        {
            _target = target;
            _follower = follower;
            _oldPosition = follower.Position;
        }

        public override void UpdateData(GameTime gameTime)
        {
            base.UpdateData(gameTime);

            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float timer = (float)gameTime.TotalGameTime.TotalSeconds;

            _follower.Position = _oldPosition;
            _follower.Position.Y = _oldPosition.Y + MathF.Cos(timer * _speed) * 10f;

            var direction = _target.Position - _oldPosition;

            if (direction.Length() < _maxDistance)
                return;

            _oldPosition = Vector2.Lerp(_oldPosition, _target.Position, delta * _speed);
        }
    }
}