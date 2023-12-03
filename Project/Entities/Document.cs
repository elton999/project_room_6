using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities
{
    public class Document : GameObject
    {
        public override void Start()
        {
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            var atlas = Scene.Content.Load<AsepriteDefinitions>("Sprites/Tilemap/atlas");
            Body = atlas.Slices["document"].Item1;
        }
    }
}
