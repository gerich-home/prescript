using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PreScript.Core
{
    public class Execute : IOperation
    {
        public readonly IReadOnlyList<IOperation> Operations;

        public Execute(IReadOnlyList<IOperation> operations)
        {
            Operations = operations;
        }

        public void Process(IPreScriptState state)
        {
            foreach (var operation in Operations.Reverse())
            {
                state.ExecStack.Push(operation);
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("{ ");
            foreach (var operation in Operations)
            {
                sb.Append(operation);
                sb.Append(" ");
            }
            sb.Append(" }");

            return sb.ToString();
        }
    }
}