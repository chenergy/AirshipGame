using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_MoveToPositionEnter : FSMAction
{
    private A_Airship self;

    public FSMAction_MoveToPositionEnter(A_Airship self)
    {
        this.self = self;
    }

    public override void execute(FSMContext c, object o)
    {
        this.self.SetSpeed(1.0f);
    }
}


public class FSMAction_MoveToPositionUpdate : FSMAction
{
    private A_Airship self;
    private Vector3 target;

    public FSMAction_MoveToPositionUpdate(A_Airship self, Vector3 target)
    {
        this.self = self;
        this.target = target;
    }

    public override void execute(FSMContext c, object o)
    {
        this.self.SetHeading((target - this.self.transform.position).normalized);
    }
}


public class FSMAction_MoveToPositionExit : FSMAction
{
    private A_Airship self;

    public FSMAction_MoveToPositionExit(A_Airship self)
    {
        this.self = self;
    }

    public override void execute(FSMContext c, object o)
    {
        this.self.SetSpeed(0.0f);
    }
}

