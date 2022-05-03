using UmbrellaToolsKit;

namespace Project.Commands
{
    public class ChangeLevelCommand : ICommand
    {
        private SceneManagement _sceneManagement;
        private int _level = 1;
        private bool done = false;

        public ChangeLevelCommand(SceneManagement sceneManagement, int level)
        {
            _sceneManagement = sceneManagement;
            _level = level;
        }

        public void Execute()
        {
            if (done)
                return;
            _sceneManagement.MainScene.LevelReady = false;
            _sceneManagement.SetScene(_level);
            done = true;
        }
    }
}