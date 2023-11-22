using Microsoft.Xna.Framework;
using Project.GamePlay;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;

namespace Project.Entities.Actors.Items.Nodes
{
    public class CheckingItemInventory : Node
    {
        private Actor _actor;

        public CheckingItemInventory(Actor actor) => _actor = actor; 

        public override NodeStatus Tick(GameTime gameTime)
        {
            return PlayerInventory.CanUseItem(_actor.tag) ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
        }
    }
}
