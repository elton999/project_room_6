using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;

namespace Project.Components
{
    public class CheckingActorOverComponent : Component
    {
        private Actor _actor;

        public CheckingActorOverComponent(Actor actor) => _actor = actor;

        public override void UpdateData(GameTime gameTime)
        {
            foreach (var solidItem in _actor.Scene.AllSolids)
            {
                if (solidItem.overlapCheck(_actor))
                {
                    Next[0]?.UpdateData(gameTime);
                    break;
                }
            }

            Next[1]?.UpdateData(gameTime);
        }
    }
}