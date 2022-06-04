using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit.BehaviorTrees
{
    public abstract class Node
    {
        protected List<Node> _nodes = new List<Node>();
        
        public int Count { get => _nodes.Count; }

        public enum NodeStatus { RUNNING, FAILURE, SUCCESS };

        public abstract NodeStatus Tick(GameTime gameTime);

        public virtual void Add(Node node) => _nodes.Add(node); 
    }
}
