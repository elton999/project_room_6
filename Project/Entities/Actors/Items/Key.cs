using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.ParticlesSystem;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;
using Project.Nodes;

namespace Project.Entities.Actors.Items
{
    public class Key : Actor
    {
        public ParticlesSystem ParticlesSystem;

        public override void Start()
        {
            tag = "key";
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            size = new Point(16, 16);
            Body = new Rectangle(new Point(192, 32), new Point(16, 16));
            Gravity2D = Vector2.Zero;

            Node = new SequenceNode();
            Node.Add(new FloatingAnimationNode(this));
            Node.Add(new CheckingActorOverActorNode(Scene.AllActors[0], this));
            Node.Add(new Nodes.StartFollowPlayerNode(this));

            ParticlesSystem = new KeyParticles(Scene.ScreenGraphicsDevice);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ParticlesSystem.Position = Position - Origin + Vector2.One * 6;
            ParticlesSystem.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            BeginDraw(spriteBatch, true);
            ParticlesSystem.DrawParticles(spriteBatch);
            DrawSprite(spriteBatch);
            EndDraw(spriteBatch);
        }

    }
}