using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Project.Nodes;

namespace Project.Entities.DoorNodes
{
    public class OpenDoorNode : Node
    {
        private bool done = false;

        public Actor _door;

        public OpenDoorNode(Actor door) => _door = door;

        public void OpenDoor()
        {
            _door.Node.Add(new SwitchSpriteNode(_door, _door.Sprite, new Rectangle(144, 24, 24, 47)));
            _door.Node.Add(new CheckingActorOverActorNode(_door, _door.Scene.AllActors[0]));
            _door.Node.Add(new SwitchLevelNode(
                _door.Scene.GameManagement.SceneManagement,
                (int)_door.Values[0].Value,
                (string)_door.Values[1].Value["entityIid"])
            );
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (done) return NodeStatus.SUCCESS;

            OpenDoor();
            done = true;

            return NodeStatus.SUCCESS;
        }
    }
}
