using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Project.Components;

namespace Project.Entities.Actors.Items
{
    public class Key : UmbrellaToolsKit.Collision.Actor
    {
        public override void Start()
        {
            tag = "key";
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            size = new Point(16, 16);
            Body = new Rectangle(new Point(192, 32), new Point(16, 16));
            Gravity2D = Vector2.Zero;

            Components.Add(new FloatingAnimationComponent(this));
            Components.Add(new CheckDistanceComponent(Scene.AllActors[0], this));
            Components.Add(new FollowerComponent(Scene.AllActors[0], this));
        }

        public override void UpdateData(GameTime gameTime)
        {
            base.UpdateData(gameTime);
        }

    }
}