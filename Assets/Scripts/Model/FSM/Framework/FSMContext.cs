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
			this.initAction.execute(this);
        }
		
		public FSMState CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }
		
        public void dispatch(string eventName)
        {
            currentState.dispatch(this, eventName);
        }

		public void Update (){
			currentState.update (this);
		}
    }
}
