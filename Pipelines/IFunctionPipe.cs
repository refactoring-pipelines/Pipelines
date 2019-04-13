namespace Pipelines
{
    internal interface IFunctionPipe : ILabeledNode
    {
        ILabeledNode Predecessor { get; }
        ILabeledNode Collector { get; }
        string OutputName { get; }
    }
}