using Microsoft.Xna.Framework;
using Project.GamePlay;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class CheckingIfHasItemNode : Node
    {
        private string _itemName;
        private bool _usedItem = false;

        public CheckingIfHasItemNode(string itemName) => _itemName = itemName;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_usedItem)
                return NodeStatus.SUCCESS;

            if (PlayerInventory.CanUseItem(_itemName))
            {
                _usedItem = true;
                return NodeStatus.SUCCESS;
            }

            return NodeStatus.FAILURE;
        }
    }
}
