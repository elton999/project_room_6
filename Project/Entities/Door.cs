using Project.Commands;
using UmbrellaToolsKit;
using UmbrellaToolsKit.Sprite;
using UmbrellaToolsKit.Collision;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project.Entities
{
    public class Door : Actor
    {
        public Square Square = new Square();
        public ICommand Command;

        public override void Start()
        {
            Square.Scene = Scene;
            Square.size = new Point(30, 60);
            Square.SquareColor = Color.Green;
            Square.Start();
        }

        public override void Update(GameTime gameTime)
        {
            Square.Position = Position;
            Command?.Execute();
            base.Update(gameTime);
        }

        public override void UpdateData(GameTime gameTime) => CheckCollisionWithPlayer();

        public void CheckCollisionWithPlayer()
        {
            if (overlapCheck(Scene.AllActors[0]))
                Command = new ChangeLevelCommand(Scene.GameManagement.SceneManagement, 2);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            BeginDraw(spriteBatch);
            Square.DrawSprite(spriteBatch);
            EndDraw(spriteBatch);
        }
    }
}