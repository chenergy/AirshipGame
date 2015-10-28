using System;

//FSMAction makes behavioral methods 1st class objects
//then they can be referenced when creating the state machine data structure

namespace FSM
{
    public abstract class FSMAction
    {
        public abstract void execute(FSMContext c);
    }
}
