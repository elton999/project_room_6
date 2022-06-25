﻿namespace UmbrellaToolsKit.BehaviorTrees
{
    public abstract class DecoratorNode : Node
    {
        protected Node _node;

        public DecoratorNode(Node node)
        {
            _node = node;
            _node.SetParent(this);
        }
    }
}
