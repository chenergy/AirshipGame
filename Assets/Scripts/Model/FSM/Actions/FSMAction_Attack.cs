using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_AttackEnter : FSMAction
{
    public override void execute(FSMContext c, object o)
    {

    }
}


public class FSMAction_AttackUpdate : FSMAction
{
    private Airship_Enemy self;
    private float targetCd;
    private float curCd;

    public FSMAction_AttackUpdate(Airship_Enemy self, float targetCd)
    {
        this.self = self;
        this.targetCd = targetCd;
    }

    public override void execute(FSMContext c, object o)
    {
        if (this.curCd > this.targetCd * 10)
        {
            this.curCd = 0;
            self.Ability.Use(Vector3.zero);
        }

        this.curCd += Time.deltaTime;
    }
}


public class FSMAction_AttackExit : FSMAction
{
    public override void execute(FSMContext c, object o)
    {

    }
}

