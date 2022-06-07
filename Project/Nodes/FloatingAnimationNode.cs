using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class FloatingAnimationNode : Node
    {
        private GameObject _gameObject;
        private float _speed = 3f;

        public FloatingAnimationNode(GameObject gameObject) => _gameObject = gameObject;

        public override NodeStatus Tick(GameTime gameTime)
        {
            float timer = (float)gameTime.TotalGameTime.TotalSeconds;
            _gameObject.Origin.Y = MathF.Cos(timer * _speed) * 10f;

            return NodeStatus.SUCCESS;
        }
    }

}

