using System.Collections.Generic;

namespace PreScript.Core
{
    public class PreScriptState : IPreScriptState
    {
        public ILinearList<IOperation> Stack { get; private set; }
        public ILinearList<IOperation> ExecStack { get; private set; }
        public ILinearList<IDictionary<string, IOperation>> DictStack { get; private set; }

        public PreScriptState(ILinearList<IOperation> stack, ILinearList<IOperation> execStack, ILinearList<IDictionary<string, IOperation>> dictStack)
        {
            Stack = stack;
            ExecStack = execStack;
            DictStack = dictStack;
        }
    }
}