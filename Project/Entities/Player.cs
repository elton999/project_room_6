using UmbrellaToolsKit.Sprite;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Entities
{
    public class Player : Actor
    {
        public AsepriteAnimation Animation;

        public override void Start()
        {
            gravity2D = Vector2.Zero;
            Animation = new AsepriteAnimation(Content.Load<AsepriteDefinitions>("Sprites/Player/player_animation"));
            Sprite = Content.Load<Texture2D>("Sprites/Player/player");

            size = new Point(16, 16);
            base.Start();
        }

        public override void Update(GameTime gametime)
        {
            Animation.Play(gametime, "run", AsepriteAnimation.AnimationDirection.LOOP);
            Body = Animation.Body;

            Scene.Camera.Target = Position;
        }
    }
}
