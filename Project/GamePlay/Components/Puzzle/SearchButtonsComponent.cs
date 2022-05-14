using Microsoft.Xna.Framework;
using System.Collections.Generic;
using UmbrellaToolsKit;

namespace Project.GamePlay.Components.Puzzle
{
    public class SearchButtonsComponent : Component
    {
        private PuzzleButtons _puzzleButtons;
        private Status _status = Status.RUNNING;

        public SearchButtonsComponent(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override Status Tick(GameTime gameTime)
        {
            if (_status == Status.RUNNING)
            {
                var _buttonTags = new List<string>();
                ldtk.FieldInstance[] fields = _puzzleButtons.Values;
                _puzzleButtons.Buttons.Clear();

                for (int i = 0; i < fields.Length; i++)
                    if (fields[i].Identifier == "buttons")
                        for (int j = 0; j < fields[i].Value.Count; j++)
                            _buttonTags.Add((string)fields[i].Value[j].entityIid);

                foreach (var actor in _puzzleButtons.Scene.AllActors)
                    if (_buttonTags.Contains(actor.tag))
                        _puzzleButtons.Buttons.Add(actor);
                    
                return _status = _puzzleButtons.Buttons.Count == _buttonTags.Count ? Status.SUCCESS : Status.RUNNING;
            }

            return _puzzleButtons.Buttons.Count > 0 ? Status.SUCCESS : Status.FAILURE;
        }
    }
}
