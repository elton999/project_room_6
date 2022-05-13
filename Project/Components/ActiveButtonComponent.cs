using System;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;

namespace Project.Components
{
    public class ActiveButtonComponent : Component
    {
        private event EventHandler _active;
        private Actor _actor;

        public ActiveButtonComponent(EventHandler active, Actor actor)
        {
            _active = active;
            _actor = actor;
        }

        public override Status Tick(GameTime gameTime)
        {
            _active?.Invoke(_actor, EventArgs.Empty);
            return base.Tick(gameTime);
        }
    }
}

