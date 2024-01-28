using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using Project.Entities.Player;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class BlockPlayerControlNode : Node
    {
        private Scene _scene;
        private Player _player;
        private bool _isDone = false;

        public BlockPlayerControlNode(Scene scene)
        {
            _scene = scene;
            if (_scene.Players.Count > 0 && _scene.Players[0] is Player)
                _player = _scene.Players[0] as Player;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_player == null) return NodeStatus.FAILURE;

            if (!_isDone)
            {
                _isDone = true;
                _player.SetInputStatus(false);
            }
            return NodeStatus.SUCCESS;
        }
    }
}