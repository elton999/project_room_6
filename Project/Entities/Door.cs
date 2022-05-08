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
        public ICommand Command;

        public override void Update(GameTime gameTime)
        {
            Command?.Execute();
            base.Update(gameTime);
        }

        public override void UpdateData(GameTime gameTime) => CheckCollisionWithPlayer();

        public void CheckCollisionWithPlayer()
        {
            if (overlapCheck(Scene.AllActors[0]))
            {
                var values = (ldtk.FieldInstance[])Values;

                Command = new ChangeLevelCommand(
                    Scene.GameManagement.SceneManagement,
                    (int)values[0].Value,
                    (string)values[1].Value["entityIid"]
                );
            }
        }
    }
}