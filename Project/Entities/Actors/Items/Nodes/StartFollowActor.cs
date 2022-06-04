using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Project.Nodes;

namespace Project.Entities.Actors.Items.KeyComponents
{
    public class StartFollowActor : Node
    {
        public Actor _actor;

        public StartFollowActor(Actor actor) => _actor = actor;

        public override Status Tick(GameTime gameTime)
        {
            _actor.Components = new Node();
            _actor.Components.Add(new FloatingAnimationNode(_actor));
            _actor.Components.Add(new CheckDistanceBetweenTwoGameObjects(_actor.Scene.AllActors[0], _actor));
            _actor.Components.Add(new FollowerNode(_actor.Scene.AllActors[0], _actor));

            return Status.SUCCESS;
        }
    }
}
