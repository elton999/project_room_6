using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateIdle : PlayerState
    {
        public PlayerStateIdle(Player player) : base(player) { }

        public override void Enter() => _player.Velocity = new Vector2(0, 0);

        public override void InputUpdate(GameTime gameTime) => SetDirection();

        public override void LogicUpdate(GameTime gametime)
        {
            _animation.Play(gametime, "idle", AsepriteAnimation.AnimationDirection.LOOP);

            if (_direction.Length() != 0)
                _player.SwitchState(new PlayerStateRun(_player));
        }
    }
}