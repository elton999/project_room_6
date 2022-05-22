using Microsoft.Xna.Framework;
using System;
using UmbrellaToolsKit;

namespace Project.Components
{
    public class SwitchLevelComponent : Component
    {
        private SceneManagement _sceneManagement;
        private string _tagPlayerSpawn;
        private int _level = 1;
        private bool done = false;

        public SwitchLevelComponent(SceneManagement sceneManagement, int level, string tagPlayerSpawn)
        {
            _sceneManagement = sceneManagement;
            _level = level;
            _tagPlayerSpawn = tagPlayerSpawn;
        }

        public override Status Tick(GameTime gameTime)
        {
            if (done)
                return Status.RUNNING;

            _setNewLevel();
            _setPlayerOnNewPosition();
            done = true;

            return Status.SUCCESS;
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
