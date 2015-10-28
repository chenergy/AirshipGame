using System;

namespace FSM
{
    public static class FSM
    {
        public static FSMContext createFSMInstance(FSMState startState, FSMAction initAction)
        {
            return new FSMContext(startState,initAction);
        }
    }
}
