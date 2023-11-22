using Microsoft.Xna.Framework;
using Project.GamePlay;
using UmbrellaToolsKit;

namespace Project.Entities.Actors.Items
{
    public class SpawnItem : GameObject
    {
        public override void Start()
        {
            string itemName = (string)Values[0].Value;
            if (!PlayerInventory.CanSpawnItem(itemName)) return;

            if (itemName == "Key")
                AddItemScene(itemName, Scene, Position);
        }

        public static void AddItemScene(string name, Scene scene, Vector2 position)
        {
            if (name == "Key")
            {
                var item = new Key();
                item.Scene = scene;
                item.Position = position;
                scene.Foreground.Add(item);
                item.Start();
            }
        }
    }
}
