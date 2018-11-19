using PreScript.Core;

namespace PreScript
{
    public class SetGray : IOperation
    {
        private readonly IGraphicsState g;

        public SetGray(IGraphicsState g)
        {
            this.g = g;
        }

        public void Process(IPreScriptState state)
        {
            var gray = (state.Stack.Pop() as Number).Value;

            g.Red = gray;
            g.Green = gray;
            g.Blue = gray;
        }
    }
}