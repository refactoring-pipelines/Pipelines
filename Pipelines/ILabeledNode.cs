using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public interface ILabeledNode
    {
        string NodeName { get; }
        IEnumerable<ILabeledNode> Listeners { get; }
    }
}
