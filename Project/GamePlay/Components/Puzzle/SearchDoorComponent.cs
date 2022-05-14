using Microsoft.Xna.Framework;
using System.Collections.Generic;
using UmbrellaToolsKit;

namespace Project.GamePlay.Components.Puzzle
{
    public class SearchDoorComponent : Component
    {
        private PuzzleButtons _puzzleButtons;
        private Status _status = Status.RUNNING;

        public SearchDoorComponent(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override Status Tick(GameTime gameTime)
        {
            if (_status == Status.RUNNING)
            {
                string _doorTag = _getDoorTag();
                _setDoor(_doorTag);

                return _status = _puzzleButtons.Door != null ? Status.SUCCESS : Status.RUNNING;
            }

            return _puzzleButtons.Door != null ? Status.SUCCESS : Status.FAILURE;
        }

        private void _setDoor(string _doorTag)
        {
            foreach (var actor in _puzzleButtons.Scene.AllActors)
                if (_doorTag.Equals(actor.tag))
                    _puzzleButtons.Door = actor;
        }

        private string _getDoorTag()
        {
            string _doorTag = "tag";
            ldtk.FieldInstance[] fields = _puzzleButtons.Values;

            for (int i = 0; i < fields.Length; i++)
                if (fields[i].Identifier == "door")
                    _doorTag = (string)fields[i].Value.entityIid;
            return _doorTag;
        }
    }

}
