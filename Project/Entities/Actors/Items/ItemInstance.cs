using Project.Entities.Factory;
using Project.GamePlay;
using UmbrellaToolsKit;

namespace Project.Entities.Actors.Items
{
    public class ItemInstance : GameObject
    {
        private ItemsFactory _itemsFactory;

        public ItemInstance() => _itemsFactory = new ItemsFactory();

        public override void Start()
        {
            string itemName = (string)Values[0].Value;
            if (!PlayerInventory.CanSpawnItem(itemName)) return;

            GameObject itemGameObject;

            switch(itemName)
            {
                case "Key":
                    itemGameObject = _itemsFactory.MakeKeyGameObject();
                    break;
                default: return;
            }

            itemGameObject.Scene = Scene;
            itemGameObject.Position = Position;
            Scene.Foreground.Add(itemGameObject);
            itemGameObject.Start();
        }
    }
}
