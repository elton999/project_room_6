using Microsoft.Xna.Framework;
using System;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;

namespace Project.Nodes
{
    public class CheckingActorOverActorNode : Node
    {
        private Actor _actorA;
        private Actor _actorB;

        public CheckingActorOverActorNode(Actor actorA, Actor actorB)
        {
            _actorA = actorA;
            _actorB = actorB;
        }

        public override NodeStatus Tick(GameTime gameTime) => _actorA.overlapCheck(_actorB) ? NodeStatus.SUCCESS : NodeStatus.FAILURE;
    }
}
