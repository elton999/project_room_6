using Microsoft.Xna.Framework;
using Project.GamePlay;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Entities.Actors.Items.Nodes
{
    public class UseItemFromInventoryNode : Node
    {
        private string _itemName;
        private bool _usedItem = false;

        public UseItemFromInventoryNode(string itemName) => _itemName = itemName;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_usedItem) return NodeStatus.SUCCESS;

            if (PlayerInventory.UseItem(_itemName))
            {
                _usedItem = true;
                return NodeStatus.SUCCESS;
            }

            return NodeStatus.FAILURE;
        }
    }
}
