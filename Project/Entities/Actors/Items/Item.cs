using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Sprite;
using UmbrellaToolsKit.Collision;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.ParticlesSystem;
using Project.Nodes;
using Project.Entities.Actors.Items.Nodes;

namespace Project.Entities.Actors.Items
{
    public class Item : Actor
    {
        public ParticlesSystem ParticlesSystem;
        public AsepriteDefinitions Atlas;

        public override void Start()
        {
            Sprite = Scene.Content.Load<Texture2D>(FilePath.SPRITE_PATH);
            Atlas = Scene.Content.Load<AsepriteDefinitions>(FilePath.SPRITE_ATLAS_PATH);
            Gravity2D = Vector2.Zero;

            var nodeSequenceCollect = new SequenceNode();
            var nodeSequenceSpawn = new SequenceNode();

            Node = new SequenceNode();
            Node.Add(new FloatingAnimationNode(this));

            nodeSequenceSpawn.Add(new CheckingItemInventory(this));
            nodeSequenceSpawn.Add(new StartFollowPlayerNode(this));
            Node.Add(new InverterNode(nodeSequenceSpawn));

            nodeSequenceCollect.Add(new CheckingActorOverActorNode(Scene.AllActors[0], this));
            nodeSequenceCollect.Add(new AddItemToInventory(this));
            nodeSequenceCollect.Add(new StartFollowPlayerNode(this));
            Node.Add(nodeSequenceCollect);

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
