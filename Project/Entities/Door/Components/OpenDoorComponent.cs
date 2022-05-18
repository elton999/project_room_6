using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Project.Components;

namespace Project.Entities.DoorComponents
{

    public class OpenDoorComponent : Component
    {
        public Actor _door;

        public OpenDoorComponent(Actor door) => _door = door;

        public void OpenDoor()
        {
            _door.Components.Add(new CheckingActorOverActor(_door, _door.Scene.AllActors[0]));

            _door.Components.Add(new ChangeLevelComponent(
                _door.Scene.GameManagement.SceneManagement,
                (int)_door.Values[0].Value,
                (string)_door.Values[1].Value["entityIid"])
            );
        }

        public override Status Tick(GameTime gameTime)
        {
            if (_door.Components.Node.Count > 0)
                return base.Tick(gameTime);

            OpenDoor();
            return Status.RUNNING;
        }
    }
}
