using Microsoft.Xna.Framework;
using UmbrellaToolsKit;

namespace Project.GamePlay.Components.Puzzle
{
    public class PuzzleButtonsLogicComponent : Component
    {
        private PuzzleButtons _puzzleButtons;

        public PuzzleButtonsLogicComponent(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override Status Tick(GameTime gameTime)
        {
            int activeButtons = 0;

            foreach (var solid in _puzzleButtons.Scene.AllSolids)
                foreach (var box in _puzzleButtons.Buttons)
                    if (solid.overlapCheck(box))
                        activeButtons++;

            if (activeButtons == _puzzleButtons.Buttons.Count)
                Node[0].Tick(gameTime);
            else
                Node[1].Tick(gameTime);

            return Status.SUCCESS;
        }
    }
}
