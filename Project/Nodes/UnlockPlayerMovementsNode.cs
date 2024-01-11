using System;
using Microsoft.Xna.Framework;
using UmbrellaToolsKit.BehaviorTrees;

namespace Project.Nodes
{
    public class UnlockPlayerMovementsNode : Node
    {
        public static event Action OnUnlockPlayerMovements;

        public override NodeStatus Tick(GameTime gameTime)
        {
            OnUnlockPlayerMovements?.Invoke();
            return NodeStatus.SUCCESS;
        }
    }
}
