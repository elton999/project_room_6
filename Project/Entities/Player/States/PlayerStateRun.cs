using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateRun : PlayerState
    {
        public PlayerStateRun(Player player) : base(player) { }

        public override void InputUpdate(GameTime gameTime) => SetDirection();

        public override void LogicUpdate(GameTime gametime)
        {
            _animation.Play(gametime, "run", AsepriteAnimation.AnimationDirection.LOOP);

            if (_dashButtonDown)
                _player.SwitchState(new PlayerStateDash(_player));

            if (_direction.X != 0)
                _player.spriteEffect = _direction.X > 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

        }

        public override void PhysicsUpdate(GameTime gametime)
        {
            _player.velocity = (_direction / _direction.Length()) * _player.Speed;

            if (_direction.Length() == 0)
                _player.SwitchState(new PlayerStateIdle(_player));
        }
    }
}