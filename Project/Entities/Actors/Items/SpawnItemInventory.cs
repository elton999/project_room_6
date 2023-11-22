using Project.GamePlay;
using System;
using UmbrellaToolsKit;

namespace Project.Entities.Actors.Items
{
    public class SpawnItemInventory : GameObject
    {
        public override void Start()
        {
            if (PlayerInventory.CanUseItem("Key"))
            {
                Console.WriteLine("------------------------");
                SpawnItem.AddItemScene("Key", Scene, Scene.Players[0].Position);
            }
        }
    }
}
