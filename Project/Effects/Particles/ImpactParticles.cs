using UmbrellaToolsKit;
using UmbrellaToolsKit.ParticlesSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Effects.Particles
{
    public class ImpactParticles : ParticlesSystem
    {
        private float _speed = 8f;
        private GameObject _target;

        public ImpactParticles(GraphicsDevice graphicsDevice, GameObject target)
        {
            tag = "ImpactParticles";
            Sprite = new Texture2D(graphicsDevice, 1, 1);
            Color[] data = new Color[1];
            data[0] = Color.White;
            Sprite.SetData(data);
            Sprites.Add(Sprite);

            _target = target;

            ParticleMaxScale = 2;
            ParticleAngleRotation = 20f;
            ParticleVelocityAngle = 360;
            ParticleVelocity = 20;
            MaxParticles = 5;
            ParticleAngleEmitter = 360;
            ParticleTransparent = 0.7f;
            ParticleLifeTime = 1000f * 1000f;
            ParticleRadiusSpawn = 14;

            EmitsFor = TypeEmitter.FOR_TIME;
            EmitterTime = 30f * _speed;

            Restart();
        }

        public override void Update(GameTime gameTime)
        {
            Position = _target.Position + Vector2.One * _speed;
            base.Update(gameTime);
        }
    }
}