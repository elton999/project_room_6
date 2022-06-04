using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;

namespace Project.Nodes
{
    public class MoveSolidsAsActorNode: Node
    {
        private Vector2 _direction;
        private Solid _solid;

        private Actor _actorHitBox;
        private float _speed = 0.2f;

        private bool _isMoving = true;

        public MoveSolidsAsActorNode(Solid solid, Vector2 direction)
        {
            _solid = solid;
            _direction = direction;
            StartMoving();
        }

        public override Status Tick(GameTime gameTime)
        {
            _actorHitBox.UpdateData(gameTime);
            _solid.Position = _actorHitBox.Position;

            return _isMoving ? Status.RUNNING : Status.SUCCESS;
        }

        public void StartMoving()
        {
            _solid.Scene.AllSolids.Remove(_solid);
            _actorHitBox = new Actor() { size = _solid.size, Position = _solid.Position, Gravity2D = Vector2.Zero, Scene = _solid.Scene };
            _actorHitBox.OnCollisionEvent += OnBoxCollide;
            _actorHitBox.Velocity = _direction * _speed;
        }

        public void OnBoxCollide(object sender, EventArgs e)
        {
            _solid.Scene.AllSolids.Add(_solid);
            _actorHitBox.Velocity = Vector2.Zero;
            _isMoving = false;
        }
    }
}