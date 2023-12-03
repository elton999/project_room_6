using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Solids
{
    public class Box : Solid
    {
        private AsepriteDefinitions _atlas;
        public override void Start()
        {
            base.Start();

            tag = "Box";
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            _atlas = Scene.Content.Load<AsepriteDefinitions>("Sprites/Tilemap/atlas");

            size = _atlas.Slices["box_puzzle"][0].Size;
            Body = _atlas.Slices["box_puzzle"][0];

            Scene.AllSolids.Add(this);
        }
    }
}