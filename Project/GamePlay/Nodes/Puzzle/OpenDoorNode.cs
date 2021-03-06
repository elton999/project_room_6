using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class OpenDoorNode : Node
    {
        private PuzzleButtons _puzzleButtons;

        public OpenDoorNode(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (!(bool)GetData("wasOpened"))
            {
                var door = _puzzleButtons.Door;
                door.Node = new SequenceNode();
                door.Node.Add(new Entities.DoorNodes.OpenDoorNode(door));

                var player = door.Scene.AllActors[0];
                AddData("target", player);
                AddData("wasOpened", true);
            }

            return NodeStatus.SUCCESS;
        }
    }
}
