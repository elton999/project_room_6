using System.Collections.Generic;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework.Graphics;
using Project.Nodes;
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
            Node.CreateData();
            Node.AddData("targetPlayer", Scene.Players[0]);

            Node.Add(new SearchButtonsNode(this));
            Node.Add(new SearchDoorNode(this));

            var OpenDoorSequence = new SequenceNode();
            OpenDoorSequence.Add(new AllButtonsAreActiveNode(this));
            OpenDoorSequence.Add(new SwitchCameraTargetNode("targetDoor"));
            OpenDoorSequence.Add(new DelayNode(new OpenDoorNode(this), 0.5f));
            OpenDoorSequence.Add(new DelayNode(new SwitchCameraTargetNode("targetPlayer"), 0.5f));
            Node.Add(new InverterNode(OpenDoorSequence));

            Node.Add(new CloseDoorNode(this));
        }

        public override void Draw(SpriteBatch spriteBatch) { }
    }
}
