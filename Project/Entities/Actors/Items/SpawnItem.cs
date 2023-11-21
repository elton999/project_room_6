using Project.GamePlay;
using System;
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
            {
                var item = new Key();
                item.Scene = this.Scene; 
                item.Position = this.Position;
                Scene.Foreground.Add(item);
                item.Start();
            }
        }
    }
}
