using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ApprovalUtilities.Utilities;

namespace Refactoring.Pipelines.DotGraph
{
    public class DotGraph
    {
        public List<string> nodes = new List<string>();
        public List<string> formatting = new List<string>();
        public List<string> rankings = new List<string>();

        public string ToString()
        {
            return $@"
digraph G {{ node [style=filled, shape=rec]

# Nodes
{nodes.JoinWith("")}

# Formatting
{formatting.JoinWith("")}
{rankings.JoinWith("")}

}}
".Trim();
        }

        public static DotGraph FromPipeline(IGraphNode node)
        {
            var roots = GetRoots(node).ToList();

            var metadata = new NodeMetadata(roots);

            var nodes = DotGraphNodes.AppendNodeAndChildren(roots, metadata);
            var formatting = DotGraphFormatting.AppendFormatting(roots, metadata);
            var rankings = DotGraphRanking.AppendRankings(roots, metadata);
            return new DotGraph()
            {
                nodes = nodes,
                formatting = formatting,
                rankings = rankings,
            };
        }

        private static IEnumerable<IGraphNode> GetRoots(IGraphNode root)
        {
            var nodesToWalk = new List<IGraphNode> {root};

            var graphNodes = new HashSet<IGraphNode>();

            while (nodesToWalk.Any())
            {
                var node = nodesToWalk.First();
                nodesToWalk.Remove(node);

                if (node.GetType().GetGenericTypeDefinition() == typeof(InputPipe<>))
                {
                    graphNodes.Add(node);
                }
                else
                {
                    nodesToWalk.AddRange(node.Parents);
                }
            }

            return graphNodes;
        }


        public static List<string> ProcessTree(
            IGraphNode node,
            List<string> result,
            Action<IGraphNode, NodeMetadata, List<string>> processNode,
            Action<IGraphNode, IGraphNode, NodeMetadata, List<string>> processChild,
            NodeMetadata metadata)
        {
            if (metadata.IsNodeDataProcessed(node, processNode))
            {
                return result;
            }

            metadata.SetNodeDataProcessed(node, processNode);

            processNode(node, metadata, result);

            if (node is ISender sender)
            {
                foreach (var listener in sender.Children)
                {
                    processChild(node, listener.CheckForwarding(), metadata, result);
                    ProcessTree(listener.CheckForwarding(), result, processNode, processChild, metadata);
                }
            }

            return result;
        }
    }
}
