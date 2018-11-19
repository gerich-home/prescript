using System;

namespace PreScript.Core
{
    public class DelegateOperation : IOperation
    {
        private readonly Action<IPreScriptState> _implementation;

        public DelegateOperation(Action<IPreScriptState> implementation)
        {
            _implementation = implementation;
        }

        public void Process(IPreScriptState state)
        {
            _implementation(state);
        }
    }
}