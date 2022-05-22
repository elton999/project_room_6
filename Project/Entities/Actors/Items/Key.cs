using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
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
            Components.Add(new CheckingActorOverActor(this, Scene.AllActors[0]));
            Components.Add(new KeyComponents.StartFollowActor(this));
        }
    }
}