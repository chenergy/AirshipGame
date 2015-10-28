using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_MoveToPositionEnter : FSMAction
{
	private A_Airship owner;

    public FSMAction_MoveToPositionEnter(A_Airship owner)
    {
        this.owner = owner;
    }

    public override void execute(FSMContext c)
    {
        this.owner.SetSpeed(1.0f);
    }
}


public class FSMAction_MoveToPositionUpdate : FSMAction
{
	private A_Airship owner;
    private Vector3 target;

    public FSMAction_MoveToPositionUpdate(A_Airship owner, Vector3 target)
    {
        this.owner = owner;
        this.target = target;
    }

    public override void execute(FSMContext c)
    {
        this.owner.SetHeading((target - this.owner.transform.position).normalized);
    }
}


public class FSMAction_MoveToPositionExit : FSMAction
{
	private A_Airship owner;

    public FSMAction_MoveToPositionExit(A_Airship owner)
    {
        this.owner = owner;
    }

    public override void execute(FSMContext c)
    {
        this.owner.SetSpeed(0.0f);
    }
}

