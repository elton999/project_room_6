using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Sprite;
using Microsoft.Xna.Framework.Input;

namespace Project.Entities.Player.State
{
    public class PlayerState : EntityState
    {
        protected Player _player;
        protected AsepriteAnimation _animation;
        protected Vector2 _directionIdle = new Vector2(1, 0);

        protected bool _dashButtonDown { get => Keyboard.GetState().IsKeyDown(Keys.Z); }
        protected bool _kickButtonDown { get => Keyboard.GetState().IsKeyDown(Keys.X); }
        protected Vector2 _direction = Vector2.Zero;

        public PlayerState(Player player)
        {
            _player = player;
            _animation = _player.Animation;
        }

        public virtual void InputUpdate(GameTime gameTime) { }

        public void SetDirection()
        {
            _direction = Vector2.Zero;
            var keyboard = Keyboard.GetState();

            if (keyboard.IsKeyDown(Keys.Left)) _direction.X = -1;
            if (keyboard.IsKeyDown(Keys.Right)) _direction.X = 1;

            if (keyboard.IsKeyDown(Keys.Up)) _direction.Y = -1;
            if (keyboard.IsKeyDown(Keys.Down)) _direction.Y = 1;
        }
    }
}