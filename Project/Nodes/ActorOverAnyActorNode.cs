using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class ActorOverAnyActorNode : Node
    {
        private Actor _actor;

        public ActorOverAnyActorNode(Actor actor) => _actor = actor;

        public override NodeStatus Tick(GameTime gameTime)
        {
            foreach (var solidItem in _actor.Scene.AllSolids)
                if (solidItem.overlapCheck(_actor))
                    return NodeStatus.SUCCESS;

            return NodeStatus.FAILURE;
        }
    }
}