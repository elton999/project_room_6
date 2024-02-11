using Microsoft.Xna.Framework;
using Project.Interfaces;
using System.Collections.Generic;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.Input;

namespace Project.Entities
{
    public class HitBox : Actor
    {
        private bool _isPlayerInteracting = false;
        private bool _isIterating = false;

        public List<ICommand> OnInteractiveCommands = new List<ICommand>();
        public List<Node> OnInteractiveNodes = new List<Node>();

        public List<ICommand> OnFinishInteractiveCommands = new List<ICommand>();
        public List<Node> OnFinishInteractiveNodes = new List<Node>();

        public override void Update(GameTime gameTime)
        {
            if (KeyBoardHandler.KeyPressed("interact") && !_isIterating && _isPlayerInteracting)
            {
                _isIterating = true;
                if (OnInteractiveCommands == null) return;
                foreach (var command in OnInteractiveCommands)
                    command.Execute();
                if (OnInteractiveNodes == null) return;
                foreach (var node in OnInteractiveNodes)
                    node.Tick(gameTime);
                return;
            }

            if (KeyBoardHandler.KeyPressed("interact") && _isIterating)
            {
                _isIterating = false;
                if (OnInteractiveCommands == null) return;
                foreach (var command in OnFinishInteractiveCommands)
                    command.Execute();
                if (OnFinishInteractiveNodes == null) return;
                foreach (var node in OnFinishInteractiveNodes)
                    node.Tick(gameTime);
            }
        }

        public override void UpdateData(GameTime gameTime)
        {
            _isPlayerInteracting = overlapCheck(Scene.AllActors[0]);
        }
    }
}
