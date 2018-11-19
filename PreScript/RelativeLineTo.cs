using PreScript.Core;

namespace PreScript
{
    public class RelativeLineTo : IOperation
    {
        private readonly IGraphicsState g;

        public RelativeLineTo(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var dy = (state.Stack.Pop() as Number).Value;
            var dx = (state.Stack.Pop() as Number).Value;

            g.LineTo(g.CurrentX + dx, g.CurrentY + dy);
        }
    }
}