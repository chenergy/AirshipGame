using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FSM
{
    public class FSMState
    {
        private FSMAction entryAction;
        private FSMAction updateAction;
        private FSMAction exitAction;
        private Dictionary<string, FSMTransition> transitionList;
        private string name;

        public string Name
        {
            get { return name; }
        }

        public FSMState(string name, FSMAction entryAction, FSMAction updateAction, FSMAction exitAction)
        {
            this.name = name;
            this.entryAction = entryAction;
            this.updateAction = updateAction;
            this.exitAction = exitAction;
            this.transitionList = new Dictionary<string,FSMTransition>();
        }
		
        public void addTransition(FSMTransition transition,string eventName)
        {
            if (!transitionList.ContainsKey(eventName))
                transitionList.Add(eventName, transition);
        }
        public void removeTransition(string eventName)
        {
            if (transitionList.ContainsKey(eventName))
                transitionList.Remove(eventName);
        }
		
		public void update(FSMContext fsmc){
			updateAction.execute(fsmc);
		}
		
        //dispatch - triggers a state transition
        public void dispatch(FSMContext fsmc, string eventName)
        {
            if (transitionList.ContainsKey(eventName))
            {
				fsmc.CurrentState.exitAction.execute(fsmc);
                transitionList[eventName].execute(fsmc);
				fsmc.CurrentState.entryAction.execute(fsmc);
            }
        }

    }
}
