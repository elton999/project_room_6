using System.Collections.Generic;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework.Graphics;
using Project.GamePlay.Nodes.Puzzle;

namespace Project.GamePlay
{
    public class PuzzleButtons : GameObject
    {
        public List<Actor> Buttons = new List<Actor>();
        public Actor Door;

        public override void Start()
        {
            base.Start();

            Node = new SequenceNode();
            Node.Add(new SearchButtonsNode(this));
            Node.Add(new SearchDoorNode(this));

            var OpenDoorSequence = new SequenceNode();
            OpenDoorSequence.Add(new AllButtonsAreActiveNode(this));
            OpenDoorSequence.Add(new OpenDoorNode(this));
            Node.Add(new InverterNode(OpenDoorSequence));

            Node.Add(new CloseDoorNode(this));
        }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}
