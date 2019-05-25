using System;
using System.Collections.Generic;

namespace Pipelines
{
    public static class ForwardingListener
    {
        public static IGraphNode CheckForwarding(this IGraphNode that)
        {
            return that is IForwardingListener forwarding ? forwarding.Owner : that;
        }
    }

    public class ForwardingListener<T> : IListener<T>, IForwardingListener
    {
        private readonly Action<T> _onMessage;

        public ForwardingListener(IGraphNode owner, Action<T> onMessage)
        {
            Owner = owner;
            _onMessage = onMessage;
        }

        public IEnumerable<IGraphNode> Children => throw new Exception("Do not call");
        public IGraphNode Owner { get; }
        IEnumerable<IGraphNode> IGraphNode.Parents => new[] { Owner };

        public void OnMessage(T value)
        {
            _onMessage(value);
        }

        public string Name => throw new Exception("Do not call");
    }
}