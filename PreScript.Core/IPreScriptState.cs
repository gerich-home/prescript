using System.Collections.Generic;

namespace PreScript.Core
{
    public interface IPreScriptState
    {
        ILinearList<IOperation> Stack { get; }
        ILinearList<IOperation> ExecStack { get; }
        ILinearList<IDictionary<string, IOperation>> DictStack { get; }
    }
}