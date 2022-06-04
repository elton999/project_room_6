using Project.Nodes;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Entities.DoorNodes
{
    public class CloseDoorNode : Node
    {
        private Actor _door;
        private bool _done = false;

        public CloseDoorNode(Actor doorActor) => _door = doorActor;

        public void CloseDoor()
        {
            _door.Node.Add(new SwitchSpriteNode(_door, _door.Sprite, new Rectangle(168, 24, 24, 47)));
            _done = true;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_done)
                return NodeStatus.SUCCESS;

            CloseDoor();

            return NodeStatus.FAILURE;
        }
    }
}
