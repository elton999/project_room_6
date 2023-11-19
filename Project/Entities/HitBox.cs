using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Project.Interfaces;
using System.Collections.Generic;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.Input;

namespace Project.Entities
{
    public class HitBox : Actor
    {
        private bool _isPlayerInterecting = false;
        private bool _isIterecting = false;

        public List<ICommand> OnInterectiveCommands;
        public List<ICommand> OnFinishInterectiveCommands;

        public override void Update(GameTime gameTime)
        {
            if (KeyBoardHandler.KeyPressed("interect") && !_isIterecting && _isPlayerInterecting)
            {
                _isIterecting = true;
                if (OnInterectiveCommands == null) return;
                foreach(var command in OnInterectiveCommands)
                    command.Execute();
            }

            if(KeyBoardHandler.KeyPressed("interect") && _isIterecting)
            {
                _isIterecting = false;
                if (OnInterectiveCommands == null) return;
                foreach (var command in OnFinishInterectiveCommands)
                    command.Execute();
            }
        }

        public override void UpdateData(GameTime gameTime)
        {
            _isPlayerInterecting = overlapCheck(Scene.AllActors[0]);
        }
    }
}
