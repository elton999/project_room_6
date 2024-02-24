using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Sprite;
using Microsoft.Xna.Framework.Input;
using UmbrellaToolsKit.Input;

namespace Project.Entities.Player.State
{
    public class PlayerState : EntityState
    {
        protected Player _player;
        protected AsepriteAnimation _animation;
        protected Vector2 _directionIdle = new Vector2(1, 0);

        protected bool _dashButtonDown { get => Keyboard.GetState().IsKeyDown(Keys.Z); }
        protected bool _kickButtonDown { get => KeyBoardHandler.KeyDown(Input.INTERACT); }
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

            if (KeyBoardHandler.KeyDown(Input.LEFT)) _direction.X = -1;
            if (KeyBoardHandler.KeyDown(Input.RIGHT)) _direction.X = 1;

            if (KeyBoardHandler.KeyDown(Input.UP)) _direction.Y = -1;
            if (KeyBoardHandler.KeyDown(Input.DOWN)) _direction.Y = 1;
        }
    }
}