namespace Pipelines
{
    internal interface IFunctionPipe : ILabeledNode
    {
        ILabeledNode Predecessor { get; }
        ILabeledNode Collector { get; }
        ILabeledNode Output { get; }
    }
}