using PreScript.Core;

namespace PreScript
{
    public class CurveTo : IOperation
    {
        private readonly IGraphicsState g;

        public CurveTo(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var y3 = (state.Stack.Pop() as Number).Value;
            var x3 = (state.Stack.Pop() as Number).Value;
            var y2 = (state.Stack.Pop() as Number).Value;
            var x2 = (state.Stack.Pop() as Number).Value;
            var y1 = (state.Stack.Pop() as Number).Value;
            var x1 = (state.Stack.Pop() as Number).Value;

            g.CurveTo(x1, y1, x2, y2, x3, y3);
        }
    }
}