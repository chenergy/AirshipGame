using UnityEngine;
using System.Collections;
using FSM;

public class AirshipBehaviour_Patrol : A_AirshipBehaviour
{
	void Start (){
		FSMAction noAction = new FSMAction_None ();
		FSMAction idleEnter = new FSMAction_IdleEnter ();
		FSMAction idleUpdate = new FSMAction_IdleUpdate ();
		FSMAction idleExit = new FSMAction_IdleExit ();
		FSMState idle = new FSMState ("idle", idleEnter, idleUpdate, idleExit);

        FSMAction moveToPlayerEnter = new FSMAction_MoveToPlayerEnter(this.airship);
        FSMAction moveToPlayerUpdate = new FSMAction_MoveToPlayerEnter(this.airship);
        FSMAction moveToPlayerExit = new FSMAction_MoveToPlayerEnter(this.airship);
        FSMState moveToPlayer = new FSMState("moveToPlayer", moveToPlayerEnter, moveToPlayerUpdate, moveToPlayerExit);

        FSMAction moveToOriginEnter = new FSMAction_MoveToPositionEnter(this.airship);
        FSMAction moveToOriginUpdate = new FSMAction_MoveToPositionUpdate(this.airship, this.airship.StartPosition);
        FSMAction moveToOriginExit = new FSMAction_MoveToPositionExit(this.airship);
        FSMState moveToOrigin = new FSMState("moveToOrigin", moveToOriginEnter, moveToOriginUpdate, moveToOriginExit);



        this.fsm = FSM.FSM.createFSMInstance (idle, noAction);
	}


    void Update()
    {

    }


	protected override bool CheckAgro (){
		/*float playerDist = (this.transform.position - GameManager.instance.InGameController.Airship.transform.position).magnitude;

		if (playerDist < this.agroDist) {
			this.SetSpeed (1.0f);

			if (this.curCd > this.targetCd * 10)
			{
				this.curCd = 0;
				this.ability.Use(Vector3.zero);
			}

			this.headingDirection = (GameManager.instance.InGameController.Airship.transform.position - this.transform.position).normalized;
		} else {
			if ((this.startPos - this.transform.position).magnitude > 1.0f) {
				this.headingDirection = (this.startPos - this.transform.position).normalized;
				this.SetSpeed (1.0f);
			} else {
				this.SetSpeed (0.0f);
			}
		}*/
		return false;
	}
}

