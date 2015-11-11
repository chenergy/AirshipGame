using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_MoveToPlayerEnter : FSMAction
{
	private A_Airship owner;

    public FSMAction_MoveToPlayerEnter(A_Airship owner)
    {
        this.owner = owner;
    }

    public override void execute(FSMContext c)
    {
        this.owner.SetSpeed(1.0f);
    }
}


public class FSMAction_MoveToPlayerUpdate : FSMAction
{
    private A_Airship owner;
    private A_Airship player;

    public FSMAction_MoveToPlayerUpdate(A_Airship owner, A_Airship player)
    {
		this.owner = owner;
        this.player = player;
    }

    public override void execute(FSMContext c)
    {
		if (!this.owner.isGrounded)
			this.owner.SetHeightLevel (player.HeightLevel);
		
        this.owner.SetHeading ((player.transform.position - this.owner.transform.position).normalized);
    }
}


public class FSMAction_MoveToPlayerExit : FSMAction
{
	private A_Airship owner;

    public FSMAction_MoveToPlayerExit(A_Airship owner)
    {
        this.owner = owner;
    }

    public override void execute(FSMContext c)
    {
        this.owner.SetSpeed(0.0f);
    }
}

