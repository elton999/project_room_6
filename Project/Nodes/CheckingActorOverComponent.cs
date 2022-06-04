using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;

namespace Project.Components
{
    public class ActorOverAnyActor : Node
    {
        private Actor _actor;

        public ActorOverAnyActor(Actor actor) => _actor = actor;

        public override Status Tick(GameTime gameTime)
        {
            foreach (var solidItem in _actor.Scene.AllSolids)
                if (solidItem.overlapCheck(_actor))
                    return Node[0].Tick(gameTime);

            return Node[1].Tick(gameTime);
        }
    }
}