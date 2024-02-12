using Microsoft.Xna.Framework;
using Project.Entities;
using Project.Interfaces;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.GamePlay.Nodes.Puzzle
{
    public class SearchDoorNode : Node
    {
        private IDoor _doorController;
        private GameObject _doorControllerGameObject;
        private NodeStatus _status = NodeStatus.RUNNING;

        public SearchDoorNode(IDoor doorController, GameObject doorControllerGameObject)
        {
            _doorController = doorController;
            _doorControllerGameObject = doorControllerGameObject;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_status == NodeStatus.RUNNING)
            {
                string _doorTag = _getDoorTag();
                _setDoor(_doorTag);

                return _status = _doorController.Door != null ? NodeStatus.SUCCESS : NodeStatus.RUNNING;
            }

            return _doorController.Door != null ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
        }

        private void _setDoor(string _doorTag)
        {
            var scene = _doorControllerGameObject.Scene;

            foreach (var actor in scene.AllActors)
                if (_doorTag.Equals(actor.tag) && actor is Door)
                    _doorController.Door = (Door)actor;

            AddData("targetDoor", _doorController.Door);
        }

        private string _getDoorTag()
        {
            string _doorTag = "tag";
            ldtk.FieldInstance[] fields = _doorControllerGameObject.Values;

            for (int i = 0; i < fields.Length; i++)
                if (fields[i].Identifier == "door")
                    _doorTag = (string)fields[i].Value.entityIid;
            return _doorTag;
        }
    }

}
