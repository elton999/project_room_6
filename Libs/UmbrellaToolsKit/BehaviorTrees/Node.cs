using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace UmbrellaToolsKit.BehaviorTrees
{
    public enum NodeStatus { RUNNING, FAILURE, SUCCESS };

    public abstract class Node
    {
        protected List<Node> _nodes = new List<Node>();
        protected Node _parent;

        private Dictionary<string, object> _dataContext;

        public int Count { get => _nodes.Count; }

        public abstract NodeStatus Tick(GameTime gameTime);

        public virtual void Add(Node node)
        {
            node._parent = this;
            _nodes.Add(node);
        }

        public void CreateData() => _dataContext = new Dictionary<string, object>();

        public void AddData(string key, object data)
        {
            if (_dataContext != null)
            {
                if (_dataContext.ContainsKey(key))
                    _dataContext[key] = data;
                else
                    _dataContext.Add(key, data);
                return;
            }

            _getDataFromRoot();

            AddData(key, data);
        }

        public object GetData(string key)
        {
            if (_dataContext != null)
                if (_dataContext.ContainsKey(key))
                    return _dataContext[key];
                else
                    return null;

            _getDataFromRoot();

            return GetData(key);
        }

        public void ClearData(string key)
        {
            if (_dataContext != null)
            {
                _dataContext.Remove(key);
                return;
            }

            _getDataFromRoot();

            ClearData(key);
        }

        public Node GetParent() => _parent;

        public Node SetParent(Node parent) => _parent = parent;

        public Dictionary<string, object> GetDataContext() => _dataContext;

        private void _getDataFromRoot()
        {
            Node node = _parent;

            while (node != null)
            {
                if (node.GetDataContext() != null)
                    _dataContext = node.GetDataContext();

                node = node.GetParent();
            }
        }
    }
}