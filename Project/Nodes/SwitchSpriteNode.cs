using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class SwitchSpriteNode : Node
    {
        public Texture2D Sprite;
        public Rectangle Body;
        public GameObject GameObject;

        public SwitchSpriteNode(GameObject gameObject, Texture2D sprite, Rectangle body)
        {
            GameObject = gameObject;
            Sprite = sprite;
            Body = body;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (Body == GameObject.Body && Sprite == GameObject.Sprite)
                return NodeStatus.SUCCESS;

            GameObject.Sprite = Sprite;
            GameObject.Body = Body;

            return NodeStatus.RUNNING;
        }

    }

}

