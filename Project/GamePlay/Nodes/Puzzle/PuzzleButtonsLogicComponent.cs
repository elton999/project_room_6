using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class PuzzleButtonsLogicComponent : Node
    {
        private PuzzleButtons _puzzleButtons;
        private bool _addDoorLogicComponents = false;

        public PuzzleButtonsLogicComponent(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override NodeStatus Tick(GameTime gameTime)
        {
            _addDoorLogic();

            if (_getActiveButtonsCount() == _puzzleButtons.Buttons.Count)
                return NodeStatus.SUCCESS;

            return NodeStatus.FAILURE;
        }

        private int _getActiveButtonsCount()
        {
            int activeButtons = 0;

            foreach (var solid in _puzzleButtons.Scene.AllSolids)
                foreach (var box in _puzzleButtons.Buttons)
                    if (solid.overlapCheck(box))
                        activeButtons++;

            return activeButtons;
        }

        private void _addDoorLogic()
        {
            if (_addDoorLogicComponents)
                return;

            _addDoorLogicComponents = true;

            var door = _puzzleButtons.Door;

            _setOpenDoorSequence(door);
            _setCloseDoorSequence(door);
        }

        private void _setOpenDoorSequence(Actor door)
        {
            var sceneManagement = door.Scene.GameManagement.SceneManagement;
            var openDoorComponent = new OpenDoorNode(_puzzleButtons.Door);

            //openDoorComponent.Add(new SwitchSpriteNode(door, door.Sprite, new Rectangle(144, 24, 24, 32)));
            //Add(openDoorComponent);
        }

        private void _setCloseDoorSequence(Actor door)
        {
            var closeDoorComponent = new Entities.DoorComponents.CloseDoorNode(_puzzleButtons.Door);

            //closeDoorComponent.Add(new SwitchSpriteNode(door, door.Sprite, new Rectangle(168, 24, 24, 32)));
            //Add(closeDoorComponent);
        }
    }
}