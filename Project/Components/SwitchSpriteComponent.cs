using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;

namespace Project.Components
{
    public class SwitchSpriteComponent : Component
    {
        public Texture2D Sprite;
        public Rectangle Body;
        public GameObject GameObject;

        public SwitchSpriteComponent(GameObject gameObject, Texture2D sprite, Rectangle body)
        {
            GameObject = gameObject;
            Sprite = sprite;
            Body = body;
        }

        public override Status Tick(GameTime gameTime)
        {
            if (Body == GameObject.Body && Sprite == GameObject.Sprite)
                return base.Tick(gameTime);

            GameObject.Sprite = Sprite;
            GameObject.Body = Body;

            return Status.RUNNING;
        }

    }

}

