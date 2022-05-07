using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;

namespace Project.Components
{
    public class MoveSolidsComponent : Component
    {
        private Vector2 _direction;
        private Solid _solid;

        private Actor _actorBox;
        private float _speed = 0.2f;
        private bool _isMoving = false;

        public MoveSolidsComponent(Solid solid, Vector2 direction)
        {
            _solid = solid;
            _direction = direction;
            StartMoving();
        }

        public override void UpdateData(GameTime gameTime)
        {
            _actorBox.UpdateData(gameTime);
            _solid.Position = _actorBox.Position;
            base.UpdateData(gameTime);
        }

        public void StartMoving()
        {
            _solid.Scene.AllSolids.Remove(_solid);
            _actorBox = new Actor() { size = _solid.size, Position = _solid.Position, Gravity2D = Vector2.Zero, Scene = _solid.Scene };
            _actorBox.OnCollisionEvent += OnBoxCollide;
            _actorBox.Velocity = _direction * _speed;
        }

        public void OnBoxCollide(object sender, EventArgs e)
        {
            _solid.Scene.AllSolids.Add(_solid);
            _actorBox.Velocity = Vector2.Zero;
            _solid.Components.Next = null;
        }
    }
}