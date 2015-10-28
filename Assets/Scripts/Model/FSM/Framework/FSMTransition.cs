using System.Collections;
using System.Collections.Generic;

namespace FSM
{
    public class FSMTransition
    {
        private FSMState target;
        private FSMAction action;
        public FSMTransition(FSMState targetState, FSMAction action)
        {
            this.target = targetState;
            this.action = action;
        }
        public void execute(FSMContext c, object o)
        {
            action.execute(c,o);
            c.CurrentState = target;
        }

    }
}
