using System.Collections.Generic;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework.Graphics;
using Project.GamePlay.Components.Puzzle;

namespace Project.GamePlay
{
    public class PuzzleButtons : GameObject
    {
        public List<Actor> Buttons = new List<Actor>();
        public Actor Door;

        public override void Start()
        {
            base.Start();

            Components.Add(new SearchButtonsComponent(this));
            Components.Add(new SearchDoorComponent(this));

            var puzzleLogic = new PuzzleButtonsLogicComponent(this);
            Components.Add(puzzleLogic);
        }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}
