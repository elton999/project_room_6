using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;

namespace Project.Entities.DoorComponents
{
    public class CloseDoorComponent : Component
    {
        private UmbrellaToolsKit.Collision.Actor _actor;

        public CloseDoorComponent(UmbrellaToolsKit.Collision.Actor actor) => _actor = actor;

        public override Status Tick(GameTime gameTime)
        {
            _actor.Components.Node.Clear();
            return Status.RUNNING;
        }
    }
}
