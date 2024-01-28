using Microsoft.Xna.Framework;
using Project.Interfaces;
using System.Collections.Generic;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.Input;

namespace Project.Entities
{
    public class HitBox : Actor
    {
        private bool _isPlayerInteracting = false;
        private bool _isIterating = false;

        public List<ICommand> OnInteractiveCommands = new List<ICommand>();
        public List<ICommand> OnFinishInteractiveCommands = new List<ICommand>();

        public override void Update(GameTime gameTime)
        {
            if (KeyBoardHandler.KeyPressed("interact") && !_isIterating && _isPlayerInteracting)
            {
                _isIterating = true;
                if (OnInteractiveCommands == null) return;
                foreach (var command in OnInteractiveCommands)
                    command.Execute();
                return;
            }

            if (KeyBoardHandler.KeyPressed("interact") && _isIterating)
            {
                _isIterating = false;
                if (OnInteractiveCommands == null) return;
                foreach (var command in OnFinishInteractiveCommands)
                    command.Execute();
            }
        }

        public override void UpdateData(GameTime gameTime)
        {
            _isPlayerInteracting = overlapCheck(Scene.AllActors[0]);
        }
    }
}
