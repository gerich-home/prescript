using PreScript.Core;

namespace PreScript
{
    public class SetLineWidth : IOperation
    {
        private readonly IGraphicsState g;

        public SetLineWidth(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var lineWidth = (state.Stack.Pop() as Number).Value;

            g.LineWidth = lineWidth;
        }
    }
}