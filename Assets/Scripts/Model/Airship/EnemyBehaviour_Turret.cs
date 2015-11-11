using UnityEngine;
using System.Collections;
using FSM;

public class EnemyBehaviour_Turret : A_EnemyBehaviour
{
	public Transform[] directions;
    public float turnDuration = 3.0f;
	public float trackDist = 10.0f;


	protected override IEnumerator LateStart (){
		yield return new WaitForEndOfFrame ();

		FSMAction noAction = new FSMAction_None ();

		// Setup actions.
		FSMAction rotateEnter = new FSMAction_RotateHeadingEnter ();
		FSMAction rotateUpdate = new FSMAction_RotateHeadingUpdate (this.owner, this.directions, this.turnDuration);
		FSMAction rotateExit = new FSMAction_RotateHeadingExit ();
		FSMState rotate = new FSMState ("rotate", rotateEnter, rotateUpdate, rotateExit);

		FSMAction attackEnter = new FSMAction_AttackEnter();
		FSMAction attackUpdate = new FSMAction_AttackUpdate(this.owner, this.owner.Ability.Cooldown);
		FSMAction attackExit = new FSMAction_AttackExit();
		FSMState attack = new FSMState("attack", attackEnter, attackUpdate, attackExit);

		// Setup transitions.
		rotate.addTransition (new FSMTransition (attack, noAction), "attack");

		attack.addTransition (new FSMTransition (rotate, noAction), "rotate");

		this.fsm = FSM.FSM.createFSMInstance (rotate, rotateEnter);
	}


	protected override void UpdateBehaviour()
	{
		if (this.fsm != null) {
			if (this.isPlayerDetected) {
				float playerDist = (this.transform.position - GameManager.instance.InGameController.Airship.transform.position).magnitude;

				if (fsm.CurrentState.Name != "attack")
					this.fsm.dispatch ("attack");

				if (playerDist > this.trackDist) {
					Debug.Log ("no longer chasing");

					this.isPlayerDetected = false;
					this.fsm.dispatch ("rotate");
				}
			} else {
				if (fsm.CurrentState.Name != "rotate")
					this.fsm.dispatch ("rotate");
			}

			this.fsm.Update ();
		}
	}
}

