using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Entities.Solids
{
    public class SolidBox : Solid
    {
        public override void Start()
        {
            size = new Point(24, 32);
            Body = new Rectangle(0, 72, 24, 32);

            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");

            Scene.AllSolids.Add(this);
        }
    }
}

