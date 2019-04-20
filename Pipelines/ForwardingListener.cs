using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    public static class ForwardingListener
    {
        public static IGraphNode CheckForwarding(this IGraphNode that)
        {
            if (that is IForwardingListener forwardingListener)
            {
                return forwardingListener.Owner;
            }
            else
            {
                return that;
            }
        }
    }
    public class ForwardingListener<T> : IListener<T>, IForwardingListener
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
        public IGraphNode Owner => _owner;
    }
}