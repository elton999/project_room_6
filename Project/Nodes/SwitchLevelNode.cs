using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class SwitchLevelNode : Node
    {
        private SceneManagement _sceneManagement;
        private string _tagPlayerSpawn;
        private int _level = 1;
        private bool done = false;

        public SwitchLevelNode(SceneManagement sceneManagement, int level, string tagPlayerSpawn)
        {
            _sceneManagement = sceneManagement;
            _level = level;
            _tagPlayerSpawn = tagPlayerSpawn;
        }

        public override NodeStatus Tick(GameTime gameTime)
        {
            if (done) return NodeStatus.SUCCESS;

            _setNewLevel();
            _setPlayerOnNewPosition();
            done = true;

            return NodeStatus.FAILURE;
        }

        private void _setNewLevel()
        {
            _sceneManagement.MainScene.LevelReady = false;
            _sceneManagement.SetScene(_level);
            _sceneManagement.MainScene.SetBackgroundColor = Color.Black;
            _setTransitionObject(_sceneManagement.MainScene);
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

        private void _setTransitionObject(Scene scene)
        {
            var transitionObject = new GameObject();
            transitionObject.Node = new SelectorNode();
            transitionObject.Node.Add(new TransitionEffectNode(scene, false));
            transitionObject.Node.Add(new UnlockPlayerMovementsNode());
            transitionObject.Scene = scene;
            scene.Middleground.Add(transitionObject);
        }
    }
}
