using System;
using System.Collections.Generic;
using System.Text;

namespace Pipelines
{
    public interface INameableNode
    {
        string NodeName { get; }
    }
}
