using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class AllButtonsAreActiveNode : Node
    {
        private PuzzleButtons _puzzleButtons;

        public AllButtonsAreActiveNode(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override NodeStatus Tick(GameTime gameTime)
        {
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
    }
}