using PreScript.Core;

namespace PreScript
{
    public class LineTo : IOperation
    {
        private readonly IGraphicsState g;

        public LineTo(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var y = (state.Stack.Pop() as Number).Value;
            var x = (state.Stack.Pop() as Number).Value;

            g.LineTo(x, y);
        }
    }
}