using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateIdle : PlayerState
    {
        public PlayerStateIdle(Player player, Vector2 direction) : base(player) => _directionIdle = direction;

        public override void Enter() => _player.Velocity = Vector2.Zero;

        public override void InputUpdate(GameTime gameTime)
        {
            SetDirection();

            if (_kickButtonDown)
                _player.SwitchState(new PlayerStateKick(_player, _directionIdle));
        }

        public override void LogicUpdate(GameTime gameTime)
        {
            _Animation(gameTime);

            if (_direction.Length() != 0)
                _player.SwitchState(new PlayerStateRun(_player));
        }

        private void _Animation(GameTime gameTime)
        {
            if (_directionIdle.X != 0)
            {
                _player.spriteEffect = _directionIdle.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                _animation.Play(gameTime, "side-idle", AsepriteAnimation.AnimationDirection.LOOP);
                return;
            }

            _animation.Play(gameTime, _directionIdle.Y > 0 ? "front-idle" : "back-idle", AsepriteAnimation.AnimationDirection.LOOP);
        }
    }
}