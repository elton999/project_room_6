using Microsoft.Xna.Framework;
using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;

namespace Project.Components
{
    public class CheckingActorOverActor : Component
    {
        private Actor _actorA;
        private Actor _actorB;

        public CheckingActorOverActor(Actor actorA, Actor actorB)
        {
            _actorA = actorA;
            _actorB = actorB;
        }

        public override Status Tick(GameTime gameTime) => _actorA.overlapCheck(_actorB) ? Status.SUCCESS : Status.RUNNING;
    }
}
