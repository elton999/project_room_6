using UmbrellaToolsKit;
using UmbrellaToolsKit.ParticlesSystem;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;
using Project.Nodes;

namespace Project.Nodes
{
    public class AddSequenceToGameObjectNode : Node
    {
        private SequenceNode _sequenceNode;
        private GameObject _gameObject;

        public AddSequenceToGameObjectNode(GameObject gameObject, SequenceNode sequenceNode)
        {
            _sequenceNode = sequenceNode;
            _gameObject = gameObject;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            _gameObject.Node = _sequenceNode;
            return NodeStatus.SUCCESS;
        }
    }
}

