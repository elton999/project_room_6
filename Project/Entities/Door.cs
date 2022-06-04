using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;
using Project.Entities.DoorNodes;

namespace Project.Entities
{
    public class Door : Actor
    {
        public override void Start()
        {
            base.Start();
            Scene.AllActors.Add(this);

            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");

            Gravity2D = Vector2.Zero;

            SetDoorAI();
        }

        public void SetDoorAI()
        {
            Node = new SequenceNode();
            if ((bool)Values[2].Value)
                Node.Add(new OpenDoorNode(this));
            else
                Node.Add(new CloseDoorNode(this));
        }
    }
}