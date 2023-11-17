using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Collision;
using Project.Commands;

namespace Project.Entities.Player.State
{
    public class PlayerStateKick : PlayerState
    {
        public PlayerStateKick(Player player, Vector2 direction) : base(player) => _directionIdle = direction;

        public override void Enter() => SetDirection();

        public override void PhysicsUpdate(GameTime gameTime)
        {
            var boxCollision = new Actor() { size = _player.size, Position = _player.Position + _directionIdle };
            foreach (var solid in _player.Scene.AllSolids)
            {
                bool isOverlaping = solid.overlapCheck(boxCollision);
                bool isABox = solid.tag == "Box";
                if (isOverlaping && isABox)
                {
                    var moveBoxCommand = new MoveBoxCommand(solid, _directionIdle);
                    moveBoxCommand.Execute();

                    _player.SwitchState(new PlayerStateIdle(_player, _directionIdle));
                    break;
                }
            }
            _player.SwitchState(new PlayerStateRun(_player));
        }

        public override void Exit() => _player.Gravity2D = Vector2.Zero;
    }
}