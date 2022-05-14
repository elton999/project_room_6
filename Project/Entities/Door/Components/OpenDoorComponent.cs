using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;

namespace Project.Entities.DoorComponents
{

    public class OpenDoorComponent : Component
    {
        public Actor _actor;

        public OpenDoorComponent(Actor actor) => _actor = actor;

        public override Status Tick(GameTime gameTime)
        {
            return base.Tick(gameTime);
        }
    }
}
