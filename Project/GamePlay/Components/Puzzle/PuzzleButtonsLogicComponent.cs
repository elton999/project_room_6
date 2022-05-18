using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Project.Entities.DoorComponents;
using Project.Components;

namespace Project.GamePlay.Components.Puzzle
{
    public class PuzzleButtonsLogicComponent : Component
    {
        private PuzzleButtons _puzzleButtons;
        private bool _addDoorLogicComponents = false;

        public PuzzleButtonsLogicComponent(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override Status Tick(GameTime gameTime)
        {
            _addDoorLogic();

            if (_getActiveButtonsCount() == _puzzleButtons.Buttons.Count)
                return Node[0].Tick(gameTime);

            return Node[1].Tick(gameTime);
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
            var openDoorComponent = new OpenDoorComponent(_puzzleButtons.Door);

            openDoorComponent.Add(new SwitchSpriteComponent(door, door.Sprite, new Rectangle(144, 24, 24, 32)));
            Add(openDoorComponent);
        }

        private void _setCloseDoorSequence(Actor door)
        {
            var closeDoorComponent = new Entities.DoorComponents.CloseDoorComponent(_puzzleButtons.Door);

            closeDoorComponent.Add(new SwitchSpriteComponent(door, door.Sprite, new Rectangle(168, 24, 24, 32)));
            Add(closeDoorComponent);
        }
    }
}