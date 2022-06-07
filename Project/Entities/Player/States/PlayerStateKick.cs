using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;
using Project.Nodes;
using Project.Effects.Particles;

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
                if (!solid.overlapCheck(boxCollision) || solid.tag != "Box")
                    continue;
                _setMoveBehavior(solid);
                break;
            }
            _player.SwitchState(new PlayerStateRun(_player));
        }

        public override void Exit() => _player.Gravity2D = Vector2.Zero;

        private void _setMoveBehavior(Solid solid)
        {
            solid.Node = new SequenceNode();

            var collideOnWallSelector = new SelectorNode();

            var moveBoxNode = new MoveSolidsAsActorNode(solid, _directionIdle);
            collideOnWallSelector.Add(new InverterNode(moveBoxNode));

            var particles = new BoxParticles(_player.Scene.ScreenGraphicsDevice, solid);
            var particlesNode = new ParticlesNode(particles, _player.Scene);
            collideOnWallSelector.Add(new InverterNode(particlesNode));

            solid.Node.Add(collideOnWallSelector);
            solid.Node.Add(new RemoveGameObjectFromScene(particles));
            solid.Node.Add(new ClearBehaviorTreeNode(solid));

            _player.SwitchState(new PlayerStateIdle(_player, _directionIdle));
        }
    }
}