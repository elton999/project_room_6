using Project.Nodes;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;
using Project.Interfaces;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class CloseDoorNode : Node
    {
        private IDoor _DoorController;

        public CloseDoorNode(IDoor doorController) => _DoorController = doorController;

        public override NodeStatus Tick(GameTime gameTime)
        {
            AddData("wasOpened", false);
            var door = _DoorController.Door;
            door.Node = new SequenceNode();
            door.Node.Add(new Entities.DoorNodes.CloseDoorNode(door));
            door.Node.Add(new ClearBehaviorTreeNode(door));

            return NodeStatus.SUCCESS;
        }
    }
}
