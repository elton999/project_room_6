using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class ShakeSpriteNode : Node
    {
        private GameObject _gameObject;
        private float _magnitude;

        public ShakeSpriteNode(GameObject gameObject, float magnitude)
        {
            _gameObject = gameObject;
            _magnitude = magnitude;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            var random = new Random();
            _gameObject.Origin.X = ((float)random.NextDouble() * 2f - 1f) * _magnitude;
            _gameObject.Origin.Y = ((float)random.NextDouble() * 2f - 1f) * _magnitude;
            return NodeStatus.SUCCESS;
        }
    }
}