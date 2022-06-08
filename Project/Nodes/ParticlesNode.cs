using UmbrellaToolsKit;
using UmbrellaToolsKit.ParticlesSystem;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class ParticlesNode : Node
    {
        private ParticlesSystem _particlesSystem;
        private Scene _scene;

        private bool _done = false;

        public ParticlesNode(ParticlesSystem particlesSystem, Scene scene)
        {
            _particlesSystem = particlesSystem;
            _particlesSystem.Scene = scene;
            _scene = scene;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (!_done)
            {
                _scene.Backgrounds.Insert(0, _particlesSystem);
                _done = true;
                return NodeStatus.SUCCESS;
            }

            return _particlesSystem.IsPlaying ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
        }
    }
}
