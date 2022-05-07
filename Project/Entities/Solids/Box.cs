using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;

namespace Project.Entities.Solids
{
    public class Box : Solid
    {
        public override void Start()
        {
            base.Start();

            size = new Point(16, 16);
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            Body = new Rectangle(new Point(144, 8), size);

            Scene.AllSolids.Add(this);
        }
    }
}