using System;
using UnityEngine;

namespace FSM
{
    public class FSMContext
    {
        private FSMAction initAction;
        private FSMState currentState;
        
        public FSMContext(FSMState startState, FSMAction initAction)
        {
            this.currentState = startState;
            this.initAction = initAction;
			this.initAction.execute(this, null);
        }
		
		public FSMState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
		
        public void dispatch(string eventName, object o)
        {
            currentState.dispatch(this, eventName, o);
        }
    }
}
