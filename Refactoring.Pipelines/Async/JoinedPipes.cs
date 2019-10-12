using System;
using System.Collections.Generic;
using System.Text;

namespace Refactoring.Pipelines.Async
{
    public static class JoinedPipes
    {
        public static JoinedPipes<TOutput1, TOutput2> JoinTo<TOutput1, TOutput2>(
            this ISender<TOutput1> sender1,
            ISender<TOutput2> sender2)
        {
            return new JoinedPipes<TOutput1, TOutput2>(sender1, sender2);
        }
    }
}
