namespace Refactoring.Pipelines
{
    public static class CastPipe
    {
        public static Sender<TOutput> Cast<TOutput>(
            this ISender<object> sender) 
        {
            return new FunctionPipe<object, TOutput>(
                $"Cast<{typeof(TOutput).Name}>",
                p => (TOutput)p,
                sender);
        }
    }
}
