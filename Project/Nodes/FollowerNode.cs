using System;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class FollowerNode : Node
    {
        private GameObject _target;
        private GameObject _follower;
        private float _speed = 5f;
        private Vector2 _oldPosition;

        public FollowerNode(GameObject target, GameObject follower)
        {
            _target = target;
            _follower = follower;
            _oldPosition = follower.Position;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _follower.Position = _oldPosition;

            _oldPosition = Vector2.Lerp(_oldPosition, _target.Position, delta * _speed);

            return NodeStatus.RUNNING;
        }
    }
}