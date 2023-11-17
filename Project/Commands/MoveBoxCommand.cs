using Microsoft.Xna.Framework;
using Project.Effects.Particles;
using Project.Interfaces;
using Project.Nodes;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;

namespace Project.Commands
{
    public class MoveBoxCommand : ICommand
    {
        private Solid _solid;
        private Vector2 _direcation;

        public MoveBoxCommand(Solid solid, Vector2 direction) 
        {
            _solid = solid;
            _direcation = direction;
        }

        public void Execute() 
        {
            _solid.Node = new SequenceNode();
            var collideOnWallSelector = new SelectorNode();

            var moveBoxNode = new MoveSolidsAsActorNode(_solid, _direcation);
            collideOnWallSelector.Add(new InverterNode(moveBoxNode));

            var particles = new BoxParticles(_solid.Scene.ScreenGraphicsDevice, _solid);
            var particlesNode = new ParticlesNode(particles, _solid.Scene);
            collideOnWallSelector.Add(new InverterNode(particlesNode));

            _solid.Node.Add(collideOnWallSelector);
            _solid.Node.Add(new RemoveGameObjectFromScene(particles));

            var sequenceOnCollide = new SequenceNode();
            var impactParticles = new ImpactParticles(_solid.Scene.ScreenGraphicsDevice, _solid);
            var impactParticlesNode = new InverterNode(new ParticlesNode(impactParticles, _solid.Scene));

            sequenceOnCollide.Add(new ShakeSpriteNode(_solid, 1f));
            sequenceOnCollide.Add(impactParticlesNode);
            sequenceOnCollide.Add(new ResetShakeSpriteNode(_solid));
            sequenceOnCollide.Add(new RemoveGameObjectFromScene(impactParticles));
            sequenceOnCollide.Add(new ClearBehaviorTreeNode(_solid));
            _solid.Node.Add(new AddSequenceToGameObjectNode(_solid, sequenceOnCollide));
        }
    }
}
