using Microsoft.Xna.Framework;
using UmbrellaToolsKit;

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

            int activeButtons = 0;

            foreach (var solid in _puzzleButtons.Scene.AllSolids)
                foreach (var box in _puzzleButtons.Buttons)
                    if (solid.overlapCheck(box))
                        activeButtons++;

            if (activeButtons == _puzzleButtons.Buttons.Count)
                return Node[0].Tick(gameTime);
            else
                return Node[1].Tick(gameTime);

            return Status.SUCCESS;
        }

        private void _addDoorLogic()
        {
            if (_addDoorLogicComponents)
                return;

            _addDoorLogicComponents = true;

            var door = _puzzleButtons.Door;
            var sceneManagement = door.Scene.GameManagement.SceneManagement;

            var component = new Component();
            var checkOverlapComponent = new Project.Components.CheckingActorOverActor(door, door.Scene.AllActors[0]);
            var changeLevelComponent = new Project.Components.ChangeLevelComponent(
                sceneManagement, (int)door.Values[0].Value,
                (string)door.Values[1].Value["entityIid"]);

            component.Add(checkOverlapComponent);
            component.Add(changeLevelComponent);

            Add(component);

            Add(new Entities.DoorComponents.CloseDoorComponent(_puzzleButtons.Door));
        }
    }
}
