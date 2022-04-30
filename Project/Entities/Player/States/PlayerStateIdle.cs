using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateIdle : PlayerState
    {
        bool _pressedAnyDirectionButtton = false;

        public PlayerStateIdle(Player player) : base(player) { }

        public override void Enter() => _player.velocity = new Vector2(0, 0);

        public override void InputUpdate(GameTime gameTime)
        {
            var keyboard = Keyboard.GetState();

            _pressedAnyDirectionButtton = keyboard.IsKeyDown(Keys.Up) ||
                                        keyboard.IsKeyDown(Keys.Down) ||
                                        keyboard.IsKeyDown(Keys.Left) ||
                                        keyboard.IsKeyDown(Keys.Right);
        }

        public override void LogicUpdate(GameTime gametime)
        {
            _animation.Play(gametime, "idle", AsepriteAnimation.AnimationDirection.LOOP);

            if (_pressedAnyDirectionButtton)
                _player.SwitchState(new PlayerStateRun(_player));
        }
    }
}