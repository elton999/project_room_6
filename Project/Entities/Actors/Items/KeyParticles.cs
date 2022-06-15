using UmbrellaToolsKit.ParticlesSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Entities.Actors.Items
{
    public class KeyParticles : ParticlesSystem
    {
        public KeyParticles(GraphicsDevice graphicsDevice)
        {
            Sprite = new Texture2D(graphicsDevice, 1, 1);
            Color[] data = new Color[1];
            data[0] = Color.White;
            Sprite.SetData(data);
            Sprites.Add(Sprite);

            Sprite = new Texture2D(graphicsDevice, 1, 1);
            data = new Color[1];
            data[0] = new Color(new Vector4(255f, 255f, 165f, 255f) / 255f);
            Sprite.SetData(data);
            Sprites.Add(Sprite);
            Sprites.Add(Sprite);

            ParticleMaxScale = 1.5f;
            ParticleVelocityAngle = 360;
            ParticleVelocity = 3;
            MaxParticles = 1;
            ParticleAngleEmitter = 360;
            ParticleAngleRotation = 0f;
            ParticleTransparent = 1f;
        }
    }
}