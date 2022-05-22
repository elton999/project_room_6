using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Project.Components;

namespace Project.Entities
{
    public class Door : Actor
    {
        public override void Start()
        {
            base.Start();
            Scene.AllActors.Add(this);

            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            Body = new Rectangle(144, 24, 24, 47);

            if ((bool)Values[2].Value)
                OpenDoor();

            Gravity2D = Vector2.Zero;
        }

        public void OpenDoor()
        {
            Components.Add(new CheckingActorOverActor(this, Scene.AllActors[0]));
            Components.Add(new SwitchLevelComponent(
                Scene.GameManagement.SceneManagement,
                (int)Values[0].Value,
                (string)Values[1].Value["entityIid"])
            );
        }
    }
}