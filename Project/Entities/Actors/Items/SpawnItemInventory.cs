using Project.Entities.Factory;
using Project.GamePlay;
using UmbrellaToolsKit;

namespace Project.Entities.Actors.Items
{
    public class SpawnItemInventory : GameObject
    {
        private ItemsFactory _itemFactory;

        public SpawnItemInventory() => _itemFactory = new ItemsFactory();

        public override void Start()
        {
            GameObject itemGameObject = null;

            if (PlayerInventory.CanUseItem("Key"))
                itemGameObject = _itemFactory.MakeKeyGameObject();

            if (itemGameObject == null) return;

            itemGameObject.Scene = Scene;
            itemGameObject.Position = Position;
            Scene.Foreground.Add(itemGameObject);
            itemGameObject.Start();
        }
    }
}
