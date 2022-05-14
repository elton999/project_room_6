using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit.Collision;
using Project.Components;

namespace Project.Entities.Actors
{
    public class GroundButton : Actor
    {
        public override void Start()
        {
            base.Start();

            size = new Point(16, 16);
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            Body = new Rectangle(new Point(0, 56), size);

            Scene.AllActors.Add(this);
        }

        private void _setAllComponents() => Components.Add(new CheckingActorOverComponent(this));
    }
}