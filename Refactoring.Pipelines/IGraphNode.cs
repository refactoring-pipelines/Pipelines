using System.Collections.Generic;
using System.Linq;

namespace Refactoring.Pipelines
{
    public interface IGraphNode
    {
        string Name { get; }
        IEnumerable<IGraphNode> Parents { get; }
    }

    public interface IGraphNodeWithOutput : ISender
    {
        IGraphNode Output { get; }
    }

    public static class IGraphNodeHelper
    {
        public static IEnumerable<IGraphNode> GetRoots(IGraphNode start)
        {
            var nodesToWalk = new List<IGraphNode> {start};

            var inputPipes = new HashSet<IGraphNode>();

            while (nodesToWalk.Any())
            {
                var node = nodesToWalk.First();
                nodesToWalk.Remove(node);

                if (node is IInputNode)
                {
                    inputPipes.Add(node);
                }
                else
                {
                    nodesToWalk.AddRange(node.Parents);
                }
            }


            return inputPipes;
        }

        public static IEnumerable<IGraphNode> GetOutputs(IGraphNode start)
        {
            var nodesToWalk = new List<IGraphNode> {start};

            var collectorPipes = new HashSet<IGraphNode>();

            while (nodesToWalk.Any())
            {
                var node = nodesToWalk.First();
                nodesToWalk.Remove(node);

                if (node.GetType().GetGenericTypeDefinition() == typeof(CollectorPipe<>))
                {
                    collectorPipes.Add(node);
                }
                else if (node is ISender graphNodeWithOutput)
                {
                    nodesToWalk.AddRange(graphNodeWithOutput.Children.Select(_ => _.CheckForwarding()));
                }
            }

            return collectorPipes;
        }
    }
}
