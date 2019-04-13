namespace Pipelines
{
    internal interface IFunctionPipe
    {
        ILabeledNode Predecessor { get; }
        ILabeledNode Collector { get; }
    }
}