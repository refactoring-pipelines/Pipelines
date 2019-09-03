using System.Collections.Generic;

namespace Refactoring.Pipelines
{
    internal class OutputNode : IGraphNode
    {
        private readonly string _name;
        private readonly IGraphNode _owner;

        public OutputNode(IGraphNode owner, string name)
        {
            _owner = owner;
            _name = name;
        }

        string IGraphNode.Name =>
            _name;

        IEnumerable<IGraphNode> IGraphNode.Parents =>
            new[] {_owner};

        public override bool Equals(object other) { return other is OutputNode that && _owner == that._owner; }

        public override int GetHashCode() { return 0; }
    }
}
