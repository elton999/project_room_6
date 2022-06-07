using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Project.Nodes;

namespace Project.Entities.Actors.Items.Nodes
{
    public class StartFollowPlayerNode : Node
    {
        public Actor _actor;
        public bool _done = false;

        public StartFollowPlayerNode(Actor actor) => _actor = actor;

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (_done)
                return NodeStatus.SUCCESS;

            _done = true;

            var player = _actor.Scene.AllActors[0];
            _actor.Node = new SequenceNode();
            _actor.Node.Add(new FloatingAnimationNode(_actor));
            var checkDistance = new CheckDistanceBetweenTwoGameObjectsNode(_actor.Scene.AllActors[0], _actor);
            _actor.Node.Add(new InverterNode(checkDistance));
            _actor.Node.Add(new FollowerNode(_actor.Scene.AllActors[0], _actor));

            System.Console.WriteLine("start follow");

            return NodeStatus.SUCCESS;
        }
    }
}
