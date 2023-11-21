using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Drawing;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.ParticlesSystem;
using Project.Nodes;
using Project.Entities.Actors.Items.Nodes;

namespace Project.Entities.Actors.Items
{
    public class Item : Actor
    {
        public ParticlesSystem ParticlesSystem;

        public override void Start()
        {
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");
            Gravity2D = Vector2.Zero;

            var nodeSelectCollect = new SelectorNode();
            var nodeSelectSpawn = new SelectorNode();

            Node = new SequenceNode();
            Node.Add(new FloatingAnimationNode(this));
            
            nodeSelectCollect.Add(new CheckingActorOverActorNode(Scene.AllActors[0], this));
            nodeSelectCollect.Add(new StartFollowPlayerNode(this));
            Node.Add(nodeSelectCollect);

            nodeSelectSpawn.Add(new CheckingItemInventory(this));
            nodeSelectSpawn.Add(new StartFollowPlayerNode(this));
            Node.Add(nodeSelectSpawn);

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
