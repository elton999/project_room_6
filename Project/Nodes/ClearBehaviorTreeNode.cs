using Microsoft.Xna.Framework;
using System;
using UmbrellaToolsKit;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class ClearBehaviorTreeNode : Node
    {
        private GameObject _gameObject;
        public ClearBehaviorTreeNode(GameObject gameObject) => _gameObject = gameObject;

        public override NodeStatus Tick(GameTime gameTime)
        {
            _gameObject.Node = null;
            return NodeStatus.SUCCESS;
        }
    }
}
