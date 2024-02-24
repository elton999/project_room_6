using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities
{
    public class Document : GameObject
    {
        public override void Start()
        {
            Sprite = Scene.Content.Load<Texture2D>(FilePath.SPRITE_PATH);
            var atlas = Scene.Content.Load<AsepriteDefinitions>(FilePath.SPRITE_ATLAS_PATH);
            Body = atlas.Slices["document"].Item1;
        }
    }
}
