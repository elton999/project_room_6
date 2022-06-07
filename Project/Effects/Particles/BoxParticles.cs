using UmbrellaToolsKit;
using UmbrellaToolsKit.ParticlesSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Effects.Particles
{
    public class BoxParticles : ParticlesSystem
    {
        private GameObject _target;

        public BoxParticles(GraphicsDevice graphicsDevice, GameObject target) : base()
        {
            Sprite = new Texture2D(graphicsDevice, 1, 1);
            Color[] data = new Color[1];
            data[0] = Color.White;
            Sprite.SetData(data);
            Sprites.Add(Sprite);

            _target = target;

            ParticleMaxScale = 5;
            ParticleAngleRotation = 20f;
            ParticleVelocityAngle = 360;
            ParticleVelocity = 10;
            MaxParticles = 8;
            ParticleAngleEmitter = 360;
            ParticleTransparent = 0.2f;
            ParticleLifeTime = 1000;
            ParticleRadiusSpawn = 8;
        }

        public override void Update(GameTime gameTime)
        {
            Position = _target.Position + Vector2.One * 8f;
            base.Update(gameTime);
        }
    }
}