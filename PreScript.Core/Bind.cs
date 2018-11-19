using System.Linq;

namespace PreScript.Core
{
    public class Bind : IOperation
    {
        public void Process(IPreScriptState state)
        {
            var execute = state.Stack.Pop() as Execute;

            var bindedOperations = from operation in execute.Operations
                                   let access = operation as Access
                                   select access == null ? operation : access.GetValue(state.DictStack);

            state.Stack.Push(new Execute(bindedOperations.ToList()));
        }

        public override string ToString()
        {
            return "}";
        }
    }
}