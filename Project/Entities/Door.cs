using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;
using Project.Entities.DoorNodes;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities
{
    public class Door : Actor
    {
        public struct DoorSpriteSettings
        {
            public Rectangle Rectangle;
            public Vector2 Origin;
            public SpriteEffects SpriteEffects;
        }

        private DoorSpriteSettings _doorClosedSettings;
        private DoorSpriteSettings _doorOpenSettings;
        private AsepriteDefinitions _atlas;

        public DoorSpriteSettings DoorClosedSettings { get => _doorClosedSettings; }
        public DoorSpriteSettings DoorOpenSettings { get => _doorOpenSettings; }

        public override void Start()
        {
            base.Start();
            Scene.AllActors.Add(this);
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            _atlas = Scene.Content.Load<AsepriteDefinitions>("Sprites/Tilemap/atlas");
            Gravity2D = Vector2.Zero;

            SetRotationSprite();
            SetDoorAI();
        }

        public void SetRotationSprite()
        {
            string orientation = (string)Values[3].Value;
            SetSpriteSettings(orientation.ToLower());
        }

        public void SetSpriteSettings(string orientation)
        {
            _doorClosedSettings = new DoorSpriteSettings
            {
                Rectangle = _atlas.Slices[$"closed_door_{orientation}"][0],
                Origin = new Vector2(0, 32f),
                SpriteEffects = SpriteEffects.None
            };
            _doorOpenSettings = new DoorSpriteSettings
            {
                Rectangle = _atlas.Slices[$"opened_door_{orientation}"][0],
                Origin = new Vector2(0, 32f),
                SpriteEffects = SpriteEffects.None
            };
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