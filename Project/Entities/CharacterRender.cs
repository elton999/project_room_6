using UmbrellaToolsKit;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Project.Entities
{
    public class CharacterRender : GameObject
    {
        public override void Start()
        {
            Sprite = Scene.Content.Load<Texture2D>("Sprites/characters");
            switch((string)Values[0].Value)
            {
                case "OldMan":
                    Body = new Rectangle(39,18, 14, 30);
                    break;
                case "AsianGuy":
                    Body = new Rectangle(103, 16, 15, 32);
                break;
            }
            base.Start();
        }

        public override void Update(GameTime gameTime)
        {
            var vector1 = Scene.Players[0].Position * Vector2.UnitX;
            var vector2 = (Scene.Players[0].Position - Position) * Vector2.UnitX;
            vector1.Normalize();
            vector2.Normalize();
            var dot = Vector2.Dot(vector1, vector2);
            spriteEffect = dot < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }
    }
}
