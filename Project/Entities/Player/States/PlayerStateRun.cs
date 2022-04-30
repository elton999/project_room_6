using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerStateRun : PlayerState
    {
        Vector2 _direction = Vector2.Zero;
        public PlayerStateRun(Player player) : base(player) { }

        public override void InputUpdate(GameTime gameTime)
        {
            _direction = Vector2.Zero;
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left)) _direction.X = -1;
            else if (keyboard.IsKeyDown(Keys.Right)) _direction.X = 1;

            if (keyboard.IsKeyDown(Keys.Up)) _direction.Y = -1;
            else if (keyboard.IsKeyDown(Keys.Down)) _direction.Y = 1;
        }

        public override void LogicUpdate(GameTime gametime)
        {
            _animation.Play(gametime, "run", AsepriteAnimation.AnimationDirection.LOOP);

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