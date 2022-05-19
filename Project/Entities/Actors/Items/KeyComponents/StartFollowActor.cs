using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Project.Components;

namespace Project.Entities.Actors.Items.KeyComponents
{
    public class StartFollowActor : Component
    {
        public Actor _actor;

        public StartFollowActor(Actor actor) => _actor = actor;

        public override Status Tick(GameTime gameTime)
        {
            _actor.Components = new Component();
            _actor.Components.Add(new FloatingAnimationComponent(_actor));
            _actor.Components.Add(new CheckDistanceComponent(_actor.Scene.AllActors[0], _actor));
            _actor.Components.Add(new FollowerComponent(_actor.Scene.AllActors[0], _actor));

            return Status.SUCCESS;
        }
    }
}
