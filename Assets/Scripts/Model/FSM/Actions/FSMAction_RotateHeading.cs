using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_RotateHeadingEnter : FSMAction
{
	/*public FSMAction_RotateHeadingEnter()
	{
	}*/

	public override void execute(FSMContext c)
	{
	}
}


public class FSMAction_RotateHeadingUpdate : FSMAction
{
	private A_Airship owner;
	private Transform[] directions;
	private int curHeading = 0;
	private float staticDuration = 3.0f;
	private float timer = 0.0f;

	public FSMAction_RotateHeadingUpdate(A_Airship owner, Transform[] directions)
	{
		this.owner = owner;
		this.directions = directions;
	}

	public override void execute(FSMContext c)
	{
		if (this.curHeading >= this.directions.Length)
			this.curHeading = 0;

		Transform targetHeading = this.directions [this.curHeading];

		if (this.timer < this.staticDuration) {
			this.owner.SetHeading((targetHeading.position - this.owner.transform.position).normalized);
			this.timer += Time.deltaTime;
		} else {
			this.curHeading++;
			this.timer = 0.0f;
		}
	}
}


public class FSMAction_RotateHeadingExit : FSMAction
{
	/*public FSMAction_RotateHeadingExit(A_Airship owner)
	{
	}*/

	public override void execute(FSMContext c)
	{
	}
}

