using Microsoft.Xna.Framework;
using UmbrellaToolsKit;

namespace Project.Commands
{
    public class ChangeLevelCommand : ICommand
    {
        private SceneManagement _sceneManagement;
        private string _tagPlayerSpawn;
        private int _level = 1;
        private bool done = false;

        public ChangeLevelCommand(SceneManagement sceneManagement, int level, string tagPlayerSpawn)
        {
            _sceneManagement = sceneManagement;
            _level = level;
            _tagPlayerSpawn = tagPlayerSpawn;
        }

        public void Execute()
        {
            if (done)
                return;
            _setNewLevel();
            _setPlayerOnNewPosition();
            done = true;
        }

        private void _setNewLevel()
        {
            _sceneManagement.MainScene.LevelReady = false;
            _sceneManagement.SetScene(_level);
        }

        private void _setPlayerOnNewPosition()
        {
            foreach (var gameObject in _sceneManagement.MainScene.Middleground)
            {
                if (gameObject.tag == _tagPlayerSpawn)
                {
                    _sceneManagement.MainScene.Players[0].Position = gameObject.Position;
                    break;
                }
            }
        }
    }
}