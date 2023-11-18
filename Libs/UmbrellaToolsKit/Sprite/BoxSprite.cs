using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace UmbrellaToolsKit.Sprite
{
    public class BoxSprite : GameObject
    {
        public Rectangle LeftTopBoxSprite;
        public Rectangle RightTopBoxSprite;
        public Rectangle LeftBottomBoxSprite;
        public Rectangle RightBottomBoxSprite;

        public Rectangle TopBoxSprite;
        public Rectangle BottomBoxSprite;
        public Rectangle LeftBoxSprite;
        public Rectangle RightBoxSprite;

        public Rectangle ContentBoxSprite;
        public Vector2 ContentSize;

        public override void Draw(SpriteBatch spriteBatch)
        {
            BeginDraw(spriteBatch, false);
            DrawRectangle(spriteBatch);
            EndDraw(spriteBatch);
        }

        private void DrawRectanglePart(SpriteBatch spriteBatch, Vector2 _Position, Rectangle _Rectangle, Vector2 _scale)
        {
            spriteBatch.Draw(
                        Sprite,
                        _Position,
                        _Rectangle,
                        SpriteColor * Transparent,
                        Rotation,
                        Origin,
                        _scale,
                        spriteEffect,
                        1f
                        );
        }

        public void DrawRectangle(SpriteBatch spriteBatch)
        {
            DrawRectanglePart(
                       spriteBatch,
                       Position + LeftTopBoxSprite.Size.ToVector2() * Vector2.UnitX,
                       TopBoxSprite,
                       Vector2.UnitX * ContentSize.X + Vector2.UnitY
                       );

            DrawRectanglePart(
                       spriteBatch,
                       Position + LeftTopBoxSprite.Size.ToVector2() * Vector2.UnitX + Vector2.UnitY * (ContentSize.Y + LeftTopBoxSprite.Height),
                       BottomBoxSprite,
                       Vector2.UnitX * ContentSize.X + Vector2.UnitY
                       );

            DrawRectanglePart(
                       spriteBatch,
                       Position + LeftTopBoxSprite.Size.ToVector2() * Vector2.UnitY,
                       LeftBoxSprite,
                       Vector2.UnitY * ContentSize.Y + Vector2.UnitX
                       );

            DrawRectanglePart(
                       spriteBatch,
                       Position + Vector2.UnitX * (LeftTopBoxSprite.Size.ToVector2() + ContentSize) + Vector2.UnitY * RightTopBoxSprite.Height,
                       RightBoxSprite,
                       Vector2.UnitY * ContentSize.Y + Vector2.UnitX
                       );

            DrawRectanglePart(
                       spriteBatch,
                       Position + Vector2.UnitY * LeftTopBoxSprite.Size.ToVector2() + Vector2.UnitX * LeftTopBoxSprite.Width,
                       ContentBoxSprite,
                       ContentSize / ContentBoxSprite.Size.ToVector2()
                       );


            // left Top
            DrawRectanglePart(
                       spriteBatch,
                       Position,
                       LeftTopBoxSprite,
                       Vector2.One
                       );

            // right Top
            DrawRectanglePart(
                       spriteBatch,
                       new Vector2(Position.X + ContentSize.X + LeftTopBoxSprite.Width, Position.Y),
                       RightTopBoxSprite,
                       Vector2.One
                       );

            // left Bottom
            DrawRectanglePart(
                       spriteBatch,
                       new Vector2(Position.X, Position.Y + ContentSize.Y + LeftTopBoxSprite.Height),
                       LeftBottomBoxSprite,
                       Vector2.One
                       );

            // right Bottom
            DrawRectanglePart(
                       spriteBatch,
                        new Vector2(Position.X + ContentSize.X + LeftBottomBoxSprite.Width, Position.Y + ContentSize.Y + RightTopBoxSprite.Height),
                       RightBottomBoxSprite,
                       Vector2.One
                       );
        }

    }
}
