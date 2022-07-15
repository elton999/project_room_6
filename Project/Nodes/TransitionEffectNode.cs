using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Nodes
{
    public class TransitionEffectNode : Node
    {
        private Effect _effect;
        private Scene _scene;
        float _pixelValue = 100;
        float _speed = 0.2f;

        public TransitionEffectNode(Scene scene, bool close = true)
        {
            _scene = scene;
            _effect = _scene.Content.Load<Effect>("Shaders/TransitionScene");

            _speed = close ? _speed : -_speed;
            _pixelValue = close ? _pixelValue : 1.5f;
        }
        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_pixelValue <= 1 || _pixelValue > 100)
                return NodeStatus.SUCCESS;

            if (_scene.Effect == null) _scene.Effect = _effect;

            _setPixelValue(gameTime);

            if (_pixelValue > 100) _scene.Effect = null;

            return NodeStatus.FAILURE;
        }

        private void _setPixelValue(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.Milliseconds;
            _pixelValue -= deltaTime * _speed;

            _effect.Parameters["pixel"].SetValue(_pixelValue);
        }
    }
}

