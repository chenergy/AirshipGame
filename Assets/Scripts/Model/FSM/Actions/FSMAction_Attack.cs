using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_AttackEnter : FSMAction
{
    public override void execute(FSMContext c)
    {

    }
}


public class FSMAction_AttackUpdate : FSMAction
{
	private Airship_Enemy owner;
    private float targetCd;
    private float curCd;

    public FSMAction_AttackUpdate(Airship_Enemy owner, float targetCd)
    {
        this.owner = owner;
        this.targetCd = targetCd;
    }

    public override void execute(FSMContext c)
    {
        if (this.curCd > this.targetCd * 10)
        {
            this.curCd = 0;
            owner.Ability.Use(Vector3.zero);
        }

        this.curCd += Time.deltaTime;

		this.owner.SetHeading ((GameManager.instance.InGameController.Airship.transform.position - this.owner.transform.position).normalized);
    }
}


public class FSMAction_AttackExit : FSMAction
{
    public override void execute(FSMContext c)
    {

    }
}

