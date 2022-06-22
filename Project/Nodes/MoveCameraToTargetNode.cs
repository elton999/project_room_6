using Microsoft.Xna.Framework;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class MoveCameraToTargetNode : Node
    {
        private GameObject _target;
        public MoveCameraToTargetNode(GameObject target) => _target = target;

        public override NodeStatus Tick(GameTime gameTime)
        {
            throw new System.NotImplementedException();
        }
    }
}