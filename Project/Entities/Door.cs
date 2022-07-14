using System;
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

            SetRotationSprite();
            SetDoorAI();
        }

        public void SetRotationSprite()
        {
            float degToRand = MathF.PI / 180f;

            switch ((string)Values[3].Value)
            {
                case "Up":
                    Rotation = 0;
                    Origin = new Vector2(0, 32f);
                    break;
                case "Down":
                    Rotation = 180f * degToRand;
                    Origin = new Vector2(24f, 32f + 24f);
                    break;
                case "Right":
                    Rotation = 90f * degToRand;
                    Origin = new Vector2(0, 32f + 24f);
                    break;
                case "Left":
                    Rotation = -90f * degToRand;
                    Origin = new Vector2(24f, 32f);
                    break;
            }
        }

        public void SetDoorAI()
        {
            Node = new SequenceNode();
            if ((bool)Values[2].Value)
            {
                Node.Add(new OpenDoorNode(this));
                return;
            }
            Node.Add(new CloseDoorNode(this));
        }
    }
}