namespace Refactoring.Pipelines
{
    public static class CastPipe
    {
        public static FunctionPipe<TInput, TOutput> Cast<TInput, TOutput>(
            this ISender<TInput> sender) where TOutput : TInput 
        {
            return new FunctionPipe<TInput, TOutput>(
                $"Cast<{typeof(TOutput).Name}>",
                p => (TOutput)p,
                sender);
        }
    }
}
