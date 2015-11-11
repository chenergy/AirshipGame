using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_PatrolEnter : FSMAction
{
	private A_Airship owner;

	public FSMAction_PatrolEnter(A_Airship owner)
	{
		this.owner = owner;
	}

	public override void execute(FSMContext c)
	{
		this.owner.SetSpeed(1.0f);
	}
}


public class FSMAction_PatrolUpdate : FSMAction
{
	private A_Airship owner;
	private Transform[] patrolPoints;
	private int curPatrolPoint = 0;

	public FSMAction_PatrolUpdate(A_Airship owner, Transform[] patrolPoints)
	{
		this.owner = owner;
		this.patrolPoints = patrolPoints;
	}

	public override void execute(FSMContext c)
	{
		if (this.curPatrolPoint >= this.patrolPoints.Length)
			this.curPatrolPoint = 0;

		Transform targetPatrolPoint = this.patrolPoints [this.curPatrolPoint];

		if ((targetPatrolPoint.position - this.owner.transform.position).magnitude > 1.0f) {
			this.owner.SetHeightLevel (GameEnum.HeightLevel.LOWER);
			this.owner.SetHeading((targetPatrolPoint.position - this.owner.transform.position).normalized);
		} else {
			this.curPatrolPoint++;
		}
	}
}


public class FSMAction_PatrolExit : FSMAction
{
	private A_Airship owner;

	public FSMAction_PatrolExit(A_Airship owner)
	{
		this.owner = owner;
	}

	public override void execute(FSMContext c)
	{
		this.owner.SetSpeed(0.0f);
	}
}

