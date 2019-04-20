using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public class ForwardingListener<T> : IListener<T>
    {
        private readonly IGraphNode _owner;
        private readonly Action<T> _onMessage;

        public ForwardingListener(IGraphNode owner, Action<T> onMessage)
        {
            _owner = owner;
            _onMessage = onMessage;
        }

        public void OnMessage(T value)
        {
            _onMessage(value);
        }

        public string Name => _owner.Name;

        public IEnumerable<IGraphNode> Children => _owner.Children;
    }
}