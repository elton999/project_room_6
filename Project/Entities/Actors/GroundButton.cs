using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Components;

namespace Project.Entities.Actors
{
    public class GroundButton : UmbrellaToolsKit.Collision.Actor
    {
        public override void Start()
        {
            base.Start();

            size = new Point(16, 16);
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            Body = new Rectangle(new Point(0, 56), size);

            Gravity2D = Vector2.Zero;

            Scene.AllActors.Add(this);
        }

        private void _setAllComponents() => Components.Add(new CheckingActorOverComponent(this));
    }
}