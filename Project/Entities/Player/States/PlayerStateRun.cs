using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateRun : PlayerState
    {
        private Vector2 _lastDirection = new Vector2(0, 1);

        public PlayerStateRun(Player player) : base(player) { }

        public override void InputUpdate(GameTime gameTime) => SetDirection();

        public override void LogicUpdate(GameTime gameTime)
        {
            _Animation(gameTime);

            if (_dashButtonDown)
                _player.SwitchState(new PlayerStateDash(_player));

            if (_direction.X != 0)
                _player.spriteEffect = _direction.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        }

        public override void PhysicsUpdate(GameTime gameTime)
        {
            _player.Velocity = (_direction / _direction.Length()) * _player.Speed;

            if (_direction.Length() == 0)
                _player.SwitchState(new PlayerStateIdle(_player, _lastDirection));

            _lastDirection = _direction;
        }

        private void _Animation(GameTime gameTime)
        {
            if (_direction.X != 0)
            {
                _animation.Play(gameTime, "side-run", AsepriteAnimation.AnimationDirection.LOOP);
                return;
            }

            _animation.Play(gameTime, _direction.Y > 0 ? "front" : "back", AsepriteAnimation.AnimationDirection.LOOP);
        }
    }
}