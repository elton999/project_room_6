using Project.Nodes;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class CloseDoorNode : Node
    {
        private PuzzleButtons _puzzleButtons;

        public CloseDoorNode(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override NodeStatus Tick(GameTime gameTime)
        {
            var door = _puzzleButtons.Door;
            door.Node = new SequenceNode();
            door.Node.Add(new Entities.DoorNodes.CloseDoorNode(door));
            door.Node.Add(new ClearBehaviorTreeNode(door));

            return NodeStatus.SUCCESS;
        }
    }
}
