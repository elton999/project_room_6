using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Project.Nodes;

namespace Project.Entities.Actors.Items.Nodes
{
    public class StartFollowPlayerNode : Node
    {
        public Actor _actor;

        public StartFollowPlayerNode(Actor actor) => _actor = actor;

        public override NodeStatus Tick(GameTime gameTime)
        {
            var player = _actor.Scene.AllActors[0];
            _actor.Node = new SelectorNode();
            _actor.Node.Add(new FloatingAnimationNode(_actor));
            _actor.Node.Add(new CheckDistanceBetweenTwoGameObjectsNode(_actor.Scene.AllActors[0], _actor));
            _actor.Node.Add(new FollowerNode(_actor.Scene.AllActors[0], _actor));

            return NodeStatus.SUCCESS;
        }
    }
}
