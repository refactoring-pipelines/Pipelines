using System.Threading.Tasks;

namespace Refactoring.Pipelines.Async
{
    public class InputPipe<T> : Pipelines.InputPipe<T>
    {
        public InputPipe(string label) : base(label) { }

        protected override void _Send(T value)
        {
            Parallel.ForEach(Listeners, listener => { listener.OnMessage(value); });
        }
    }
}
