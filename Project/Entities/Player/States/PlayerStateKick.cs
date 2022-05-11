using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Collision;

namespace Project.Entities.Player.State
{
    public class PlayerStateKick : PlayerState
    {
        public PlayerStateKick(Player player) : base(player) { }

        public override void Enter() => SetDirection();

        public override void PhysicsUpdate(GameTime gametime)
        {
            var boxCollision = new Actor() { size = _player.size, Position = _player.Position + _direction };
            foreach (var solid in _player.Scene.AllSolids)
            {
                if (solid.overlapCheck(boxCollision))
                {
                    solid.Components.Add(new Components.MoveSolidsComponent(solid, _direction));
                    _player.SwitchState(new PlayerStateIdle(_player, _direction));
                    break;
                }
            }
            _player.SwitchState(new PlayerStateRun(_player));
        }

        public override void Exit() => _player.Gravity2D = Vector2.Zero;
    }
}