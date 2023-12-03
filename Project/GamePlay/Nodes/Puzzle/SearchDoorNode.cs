using Microsoft.Xna.Framework;
using Project.Entities;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class SearchDoorNode : Node
    {
        private PuzzleButtons _puzzleButtons;
        private NodeStatus _status = NodeStatus.RUNNING;

        public SearchDoorNode(PuzzleButtons puzzleButtons) => _puzzleButtons = puzzleButtons;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_status == NodeStatus.RUNNING)
            {
                string _doorTag = _getDoorTag();
                _setDoor(_doorTag);

                return _status = _puzzleButtons.Door != null ? NodeStatus.SUCCESS : NodeStatus.RUNNING;
            }

            return _puzzleButtons.Door != null ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
        }

        private void _setDoor(string _doorTag)
        {
            foreach (var actor in _puzzleButtons.Scene.AllActors)
                if (_doorTag.Equals(actor.tag) && actor is Door)
                    _puzzleButtons.Door = (Door)actor;

            AddData("targetDoor", _puzzleButtons.Door);
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
