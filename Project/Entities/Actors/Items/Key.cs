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

            _setParticle();
        }

        private void _setParticle()
        {
            ParticlesSystem = new ParticlesSystem();

            ParticlesSystem.Sprite = new Texture2D(Scene.ScreenGraphicsDevice, 1, 1);
            Color[] data = new Color[1];
            data[0] = Color.White;
            ParticlesSystem.Sprite.SetData(data);
            ParticlesSystem.Sprites.Add(ParticlesSystem.Sprite);

            ParticlesSystem.ParticleMaxScale = 2;
            ParticlesSystem.ParticleVelocityAngle = 360;
            ParticlesSystem.ParticleVelocity = 4;
            ParticlesSystem.MaxParticles = 1;
            ParticlesSystem.ParticleAngleEmitter = 360;
            ParticlesSystem.ParticleAngleRotation = 0f;
            ParticlesSystem.ParticleTransparent = 1;
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