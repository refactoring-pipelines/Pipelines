using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public interface IGraphNode
    {
        string Name { get; }

        IEnumerable<IGraphNode> Children { get; }
    }
}
