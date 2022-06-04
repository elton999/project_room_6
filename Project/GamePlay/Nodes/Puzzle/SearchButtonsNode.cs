using Microsoft.Xna.Framework;
using System.Collections.Generic;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class SearchButtonsNode : Node
    {
        private PuzzleButtons _puzzleButtons;
        private NodeStatus _status = NodeStatus.RUNNING;

        public SearchButtonsNode(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_status == NodeStatus.RUNNING)
            {
                _puzzleButtons.Buttons.Clear();

                List<string> _buttonTags = _getButtonsTag();
                _setButtons(_buttonTags);

                return _status = _puzzleButtons.Buttons.Count == _buttonTags.Count ? NodeStatus.SUCCESS : NodeStatus.RUNNING;
            }

            return _puzzleButtons.Buttons.Count > 0 ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
        }

        private void _setButtons(List<string> _buttonTags)
        {
            foreach (var actor in _puzzleButtons.Scene.AllActors)
                if (_buttonTags.Contains(actor.tag))
                    _puzzleButtons.Buttons.Add(actor);
        }

        private List<string> _getButtonsTag()
        {
            var _buttonTags = new List<string>();
            ldtk.FieldInstance[] fields = _puzzleButtons.Values;

            for (int i = 0; i < fields.Length; i++)
                if (fields[i].Identifier == "buttons")
                    for (int j = 0; j < fields[i].Value.Count; j++)
                        _buttonTags.Add((string)fields[i].Value[j].entityIid);

            return _buttonTags;
        }
    }
}
