using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public interface ILabeledNode
    {
        string IncomingName { get; }
        string OutgoingName { get; }
        IEnumerable<ILabeledNode> Listeners { get; }
    }
}
