using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Player.State
{
    public class PlayerState : EntityState
    {
        protected Player _player;
        protected AsepriteAnimation _animation;

        public PlayerState(Player player)
        {
            _player = player;
            _animation = _player.Animation;
        }

        public virtual void InputUpdate(GameTime gametime) { }
    }
}