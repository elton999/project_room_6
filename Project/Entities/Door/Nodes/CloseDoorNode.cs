using Project.Nodes;
using UmbrellaToolsKit.BehaviorTrees;
using Microsoft.Xna.Framework;

namespace Project.Entities.DoorNodes
{
    public class CloseDoorNode : Node
    {
        private Door _door;
        private bool _done = false;

        public CloseDoorNode(Door doorActor) => _door = doorActor;

        public void CloseDoor()
        {
            _door.Node.Add(new SwitchSpriteNode(_door, _door.Sprite, _door.DoorClosedSettings.Rectangle));
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
