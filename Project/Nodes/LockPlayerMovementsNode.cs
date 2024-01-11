using System;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class LockPlayerMovementsNode : Node
    {
        public static event Action OnLockPlayerMovements;

        public override NodeStatus Tick(GameTime gameTime)
        {
            OnLockPlayerMovements?.Invoke();
            return NodeStatus.SUCCESS;
        }
    }
}
