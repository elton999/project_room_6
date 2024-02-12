using Microsoft.Xna.Framework;
using Project.Interfaces;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class OpenDoorNode : Node
    {
        private IDoor _doorController;

        public OpenDoorNode(IDoor doorController) => _doorController = doorController;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (!(bool)GetData("wasOpened"))
            {
                var door = _doorController.Door;
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
