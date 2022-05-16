using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
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

            _setOpenDoorSequence();
            _setCloseDoorSequence();
        }

        private void _setOpenDoorSequence()
        {
            var door = _puzzleButtons.Door;
            var sceneManagement = door.Scene.GameManagement.SceneManagement;

            var component = new Component();
            var checkOverlapComponent = new CheckingActorOverActor(door, door.Scene.AllActors[0]);
            var changeLevelComponent = new ChangeLevelComponent(
                sceneManagement,
                (int)door.Values[0].Value,
                (string)door.Values[1].Value["entityIid"]
            );

            component.Add(checkOverlapComponent);
            component.Add(changeLevelComponent);

            Add(component);
        }

        private void _setCloseDoorSequence() => Add(new Entities.DoorComponents.CloseDoorComponent(_puzzleButtons.Door));
    }
}