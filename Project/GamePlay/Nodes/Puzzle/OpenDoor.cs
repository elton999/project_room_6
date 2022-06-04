using Microsoft.Xna.Framework;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class OpenDoorNode : Node
    {
        private Actor _door;

        public OpenDoorNode(Actor door) =>_door = door;

        public override NodeStatus Tick(GameTime gameTime)
        {
            _door.Node = new SequenceNode();
            _door.Node.Add(new Entities.DoorNodes.OpenDoorNode(_door));

            return NodeStatus.SUCCESS;
        }
    }
}
