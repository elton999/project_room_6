using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Nodes;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Sprite;

namespace Project.Entities.Actors
{
    public class GroundButton : UmbrellaToolsKit.Collision.Actor
    {
        private AsepriteDefinitions _atlas;

        public override void Start()
        {
            base.Start();
            Sprite = Scene.Content.Load<Texture2D>(FilePath.SPRITE_PATH);
            _atlas = Scene.Content.Load<AsepriteDefinitions>(FilePath.SPRITE_ATLAS_PATH);

            size = _atlas.Slices["puzzle_slot"].Item1.Size;
            Body = _atlas.Slices["puzzle_slot"].Item1;

            Gravity2D = Vector2.Zero;

            Scene.AllActors.Add(this);

            _setAllComponents();
        }

        private void _setAllComponents()
        {
            Node = new SequenceNode();
            Node.Add(new ActorOverAnyActorNode(this));
        }
    }
}