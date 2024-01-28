using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Input;

namespace Project.Nodes
{
    public class PressAnyKeyToNextNode : Node
    {
        private bool _canPassToNextNode = false;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (KeyBoardHandler.KeyPressed("interact") || _canPassToNextNode)
            {
                _canPassToNextNode = true;
                return NodeStatus.SUCCESS;
            }

            return NodeStatus.FAILURE;
        }
    }
}
