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
        private Vector2 _oldPosition;

        public FollowerComponent(Actor target, Actor follower)
        {
            _target = target;
            _follower = follower;
            _oldPosition = follower.Position;
        }

        public override Status Tick(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _follower.Position = _oldPosition;

            _oldPosition = Vector2.Lerp(_oldPosition, _target.Position, delta * _speed);

            return Status.RUNNING;
        }
    }
}