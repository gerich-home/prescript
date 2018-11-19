using System;

namespace PreScript.Core
{
    public class CloseCodeMarker : IOperation
    {
        public void Process(IPreScriptState state)
        {
            throw new InvalidOperationException("} operator should go after { operator");
        }

        public override string ToString()
        {
            return "}";
        }
    }
}