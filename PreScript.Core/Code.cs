using System.Collections.Generic;

namespace PreScript.Core
{
    public class Code : IOperation
    {
        private readonly IReadOnlyList<IOperation> _operations;

        public Code(IReadOnlyList<IOperation> operations)
        {
            _operations = operations;
        }

        public void Process(IPreScriptState state)
        {
            state.Stack.Push(new Execute(_operations));
        }
    }
}