using Project.Interfaces;
using Project.UI;
using UmbrellaToolsKit;

namespace Project.Commands
{
    public class ClearAllTextBoxCommand : ICommand
    {
        private Scene _scene;

        public ClearAllTextBoxCommand(Scene scene) => _scene = scene;

        public void Execute() 
        {
            foreach (var gameobject in _scene.UI)
                if (gameobject is TextBox)
                    gameobject.RemoveFromScene = true;
        }
    }
}
