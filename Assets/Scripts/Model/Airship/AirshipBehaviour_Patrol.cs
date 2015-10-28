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

		this.fsm = FSM.FSM.createFSMInstance (idle, noAction);
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

