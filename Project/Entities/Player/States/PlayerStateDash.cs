using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateDash : PlayerState
    {
        float _timer = .2f;
        public PlayerStateDash(Player player) : base(player) { }

        public override void Enter() => SetDirection();

        public override void LogicUpdate(GameTime gametime)
        {
            _timer -= (float)gametime.ElapsedGameTime.TotalSeconds;

            if (_timer <= 0)
                _player.SwitchState(new PlayerStateIdle(_player));
        }

        public override void PhysicsUpdate(GameTime gametime)
        {
            _player.velocity = _direction * _player.SpeedDash * (float)gametime.ElapsedGameTime.Milliseconds;
        }

        public override void Exit() => _player.gravity2D = Vector2.Zero;
    }
}