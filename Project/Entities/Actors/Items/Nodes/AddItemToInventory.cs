using Microsoft.Xna.Framework;
using Project.GamePlay;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Entities.Actors.Items.Nodes
{
    public  class AddItemToInventory : Node
    {
        private GameObject _gameObject;

        public AddItemToInventory(GameObject gameObject) => _gameObject = gameObject;

        public override NodeStatus Tick(GameTime gameTime)
        {
            PlayerInventory.AddItemToInvetory(_gameObject.tag);
            return NodeStatus.SUCCESS;
        }
    }
}
