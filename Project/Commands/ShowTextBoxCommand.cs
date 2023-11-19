using Project.Interfaces;
using UmbrellaToolsKit;
using Microsoft.Xna.Framework;
using Project.UI;

namespace Project.Commands
{
    public class ShowTextBoxCommand : ICommand
    {
        private string _text;
        private Scene _scene;

        private TextBox _textBox;

        public ShowTextBoxCommand(string text, Scene scene)
        {
            _scene = scene;

            _textBox = new TextBox();
            _textBox.Scene = scene;
            SetText(text);
        }

        public void Execute()
        {
            SetText(_text);
            _textBox.Start();
            _scene.UI.Add(_textBox);
            _textBox.ContentSize = GetStringSize();
            _textBox.Position = _scene.Sizes.ToVector2() / 2f - (_textBox.ContentSize + Vector2.One * 16) / 2f;
            _textBox.Position = _textBox.Position.ToPoint().ToVector2();
        }

        public void SetText(string text)
        {
            _text = text;
            _textBox.Text = text;
        }

        private Vector2 GetStringSize() =>  _textBox.Font.MeasureString(_text);

    }
}
