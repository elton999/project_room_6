using Project.Nodes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.CutScenes
{
    public class InitialSentence : GameObject
    {
        private string _text;
        private SpriteFont _font;
        private Vector2 _textSize;

        public override void Start()
        {
            _text = "Eis que em iniquidade fui formado, e em pecado me aconcebeu minha mãe.\n Salmos 51, 5";
            _font = Scene.Content.Load<SpriteFont>(FilePath.BASIC_FONT_PATH);
            _textSize = _font.MeasureString(_text);
            base.Start();

            Node = new SequenceNode();
            Node.Add(new LockPlayerMovementsNode());
            Node.Add(new PressAnyKeyToNextNode());
            Node.Add(new DelayNode(new UnlockPlayerMovementsNode(), 0.3f));
            Node.Add(new RemoveGameObjectFromScene(this));
        }

        public override void Update(GameTime gameTime) => Node?.Tick(gameTime);
        public override void UpdateData(GameTime gameTime) { }

        public override void Draw(SpriteBatch spriteBatch)
        {
            BeginDraw(spriteBatch, false);
            Scene.ScreenGraphicsDevice.Clear(Color.Black);
            spriteBatch.DrawString(_font, _text, Scene.Sizes.ToVector2() / 2.0f - _textSize / 2.0f, Color.White);
            EndDraw(spriteBatch);
        }
    }
}
