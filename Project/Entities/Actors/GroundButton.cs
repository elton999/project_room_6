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
            _atlas = Scene.Content.Load<AsepriteDefinitions>("Sprites/Tilemap/atlas");
            Sprite = Scene.Content.Load<Texture2D>("Sprites/Tilemap/tilemap");

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