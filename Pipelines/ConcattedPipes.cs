using System;
using System.Collections.Generic;
using System.Linq;

namespace Pipelines
{
    //public static class ConcattedPipes
    //{
    //    public static ConcattedPipes<TOutput1, TOutput2> ConcatWith<TOutput1, TOutput2>(
    //        this Sender<TOutput1> sender1,
    //        ISender<IEnumerable<TOutput2>> sender2)
    //    {
    //        return new ConcattedPipes<TOutput1, TOutput2>(sender1, sender2);
    //    }
    //}

    public static class ConcattedPipes
    {
        public static FunctionPipe<Tuple<IEnumerable<TOutput>, IEnumerable<TOutput>>, List<TOutput>>
            ConcatWith<TOutput>(this ISender<IEnumerable<TOutput>> sender1, ISender<IEnumerable<TOutput>> sender2)
        {
            return sender1.JoinTo(sender2).Process(t => t.Item1.Concat(t.Item2).ToList());
            //return new ConcattedPipes<TOutput1, TOutput2>(sender1, sender2);
        }
    }
}
