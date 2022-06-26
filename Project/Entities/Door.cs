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
            Origin = new Vector2(24, 32) * 0.5f;

            switch ((string)Values[3].Value)
            {
                case "Down":
                    Rotation = 180f * degToRand;
                    break;
                case "Right":
                    Rotation = 90f * degToRand;
                    break;
                case "Left":
                    Rotation = -90f * degToRand;
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