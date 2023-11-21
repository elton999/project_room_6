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
            if (!PlayerInventory.CanSpawnItem(_actor.tag))
            {
                foreach (var item in _actor.Scene.Foreground)
                    if(item.tag == _actor.tag)
                        return NodeStatus.SUCCESS;
            }

            return NodeStatus.FAILURE;
        }
    }
}
