using UnityEngine;
using System.Collections;
using FSM;

public class FSMAction_MoveToPlayerEnter : FSMAction
{
    private A_Airship self;

    public FSMAction_MoveToPlayerEnter(A_Airship self)
    {
        this.self = self;
    }

    public override void execute(FSMContext c, object o)
    {
        this.self.SetSpeed(1.0f);
    }
}


public class FSMAction_MoveToPlayerUpdate : FSMAction
{
    private A_Airship self;
    private A_Airship player;

    public FSMAction_MoveToPlayerUpdate(A_Airship self, A_Airship player)
    {
        this.self = self;
        this.player = player;
    }

    public override void execute(FSMContext c, object o)
    {
        this.self.SetHeading ((player.transform.position - this.self.transform.position).normalized);
    }
}


public class FSMAction_MoveToPlayerExit : FSMAction
{
    private A_Airship self;

    public FSMAction_MoveToPlayerExit(A_Airship self)
    {
        this.self = self;
    }

    public override void execute(FSMContext c, object o)
    {
        this.self.SetSpeed(0.0f);
    }
}

