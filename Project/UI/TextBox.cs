using UmbrellaToolsKit.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.UI
{
    public class TextBox : BoxSprite
    {
        public string Text;
        public SpriteFont Font;

        public override void Start()
        {
            var cornerSize = new Point(8, 8);
            LeftTopBoxSprite = new Rectangle(new Point(112, 0), cornerSize);
            RightTopBoxSprite = new Rectangle(new Point(120, 0), cornerSize);
            LeftBottomBoxSprite = new Rectangle(new Point(112, 8), cornerSize);
            RightBottomBoxSprite = new Rectangle(new Point(120, 8), cornerSize);

            var boxMiddleVerticalSize = new Point(1, 8);
            TopBoxSprite = new Rectangle(new Point(120, 0), boxMiddleVerticalSize);
            BottomBoxSprite = new Rectangle(new Point(119, 8), boxMiddleVerticalSize);

            var boxMiddleHorizontalSize = new Point(8, 1);
            LeftBoxSprite = new Rectangle(new Point(112, 8), boxMiddleHorizontalSize);
            RightBoxSprite = new Rectangle(new Point(120, 8), boxMiddleHorizontalSize);

            ContentBoxSprite = new Rectangle(128, 0, 8, 8);

            Sprite = Scene.Content.Load<Texture2D>(FilePath.SPRITE_PATH);
            Font = Scene.Content.Load<SpriteFont>(FilePath.BASIC_FONT_PATH);

            base.Start();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            BeginDraw(spriteBatch, false);
            DrawRectangle(spriteBatch);
            spriteBatch.DrawString(Font, Text, Position + LeftTopBoxSprite.Size.ToVector2(), Color.White);
            EndDraw(spriteBatch);
        }
    }
}
