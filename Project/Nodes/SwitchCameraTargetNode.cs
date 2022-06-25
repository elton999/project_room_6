using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class SwitchCameraTargetNode : Node
    {
        private string _target;

        public SwitchCameraTargetNode(string target) => _target = target;

        public override NodeStatus Tick(GameTime gameTime)
        {
            var targetGO = (GameObject)GetData(_target);
            targetGO.Scene.Camera.Target = targetGO;
            return NodeStatus.SUCCESS;
        }
    }
}