using System;

namespace PreScript.Core
{
    public class EmptyArray : IOperation
    {
        public void Process(IPreScriptState state)
        {
            int size;
            if (!(state.Stack.Pop() as Number).CheckInteger(out size))
            {
                throw new InvalidOperationException("Size parameter should be integer");
            }

            state.Stack.Push(new Data<IArray<IOperation>>(new Array<IOperation>(size)));
        }

        public override string ToString()
        {
            return "]";
        }
    }
}