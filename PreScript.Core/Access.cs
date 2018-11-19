using System;
using System.Collections.Generic;
using System.Linq;

namespace PreScript.Core
{
    public class Access : IOperation
    {
        public readonly string Name;

        public Access(string name)
        {
            Name = name;
        }

        public void Process(IPreScriptState state)
        {
            var operation = GetValue(state.DictStack);
            state.ExecStack.Push(operation);

        }

        public IOperation GetValue(ILinearList<IDictionary<string, IOperation>> dictStack)
        {
            foreach (var dict in dictStack.Reverse())
            {
                IOperation operation;
                if (dict.TryGetValue(Name, out operation))
                {
                    return operation;
                }
            }

            throw new InvalidOperationException(string.Format("Identifier /{0} can not be found in the dictionary stack", Name));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}