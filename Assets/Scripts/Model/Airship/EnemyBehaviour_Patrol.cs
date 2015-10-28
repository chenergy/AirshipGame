using UnityEngine;
using System.Collections;
using FSM;

public class EnemyBehaviour_Patrol : A_EnemyBehaviour
{
	public Transform[] patrolPoints;
	public float chaseDist = 10.0f;
	public float attackDist = 5.0f;


	void Start (){
		StartCoroutine ("LateStart");
	}


	IEnumerator LateStart (){
		yield return new WaitForEndOfFrame ();

		FSMAction noAction = new FSMAction_None ();

		// Setup actions.
		/*
		FSMAction idleEnter = new FSMAction_IdleEnter ();
		FSMAction idleUpdate = new FSMAction_IdleUpdate ();
		FSMAction idleExit = new FSMAction_IdleExit ();
		FSMState idle = new FSMState ("idle", idleEnter, idleUpdate, idleExit);
		*/

		FSMAction moveToPlayerEnter = new FSMAction_MoveToPlayerEnter(this.owner);
		FSMAction moveToPlayerUpdate = new FSMAction_MoveToPlayerUpdate(this.owner, GameManager.instance.InGameController.Airship);
		FSMAction moveToPlayerExit = new FSMAction_MoveToPlayerExit(this.owner);
		FSMState moveToPlayer = new FSMState("moveToPlayer", moveToPlayerEnter, moveToPlayerUpdate, moveToPlayerExit);

		FSMAction patrolEnter = new FSMAction_PatrolEnter(this.owner);
		FSMAction patrolUpdate = new FSMAction_PatrolUpdate(this.owner, this.patrolPoints);
		FSMAction patrolExit = new FSMAction_PatrolExit(this.owner);
		FSMState patrol = new FSMState("patrol", patrolEnter, patrolUpdate, patrolExit);

		FSMAction attackEnter = new FSMAction_AttackEnter();
		FSMAction attackUpdate = new FSMAction_AttackUpdate(this.owner, this.owner.Ability.Cooldown);
		FSMAction attackExit = new FSMAction_AttackExit();
		FSMState attack = new FSMState("attack", attackEnter, attackUpdate, attackExit);

		// Setup transitions.
		/*idle.addTransition (new FSMTransition (moveToPlayer, noAction), "moveToPlayer");
		idle.addTransition (new FSMTransition (patrol, noAction), "patrol");
		idle.addTransition (new FSMTransition (attack, noAction), "attack");*/

		//moveToPlayer.addTransition (new FSMTransition (idle, noAction), "idle");
		moveToPlayer.addTransition (new FSMTransition (patrol, noAction), "patrol");
		moveToPlayer.addTransition (new FSMTransition (attack, noAction), "attack");

		//patrol.addTransition (new FSMTransition (idle, noAction), "idle");
		patrol.addTransition (new FSMTransition (moveToPlayer, noAction), "moveToPlayer");
		patrol.addTransition (new FSMTransition (attack, noAction), "attack");

		//attack.addTransition (new FSMTransition (idle, noAction), "idle");
		attack.addTransition (new FSMTransition (moveToPlayer, noAction), "moveToPlayer");
		attack.addTransition (new FSMTransition (patrol, noAction), "patrol");

		this.fsm = FSM.FSM.createFSMInstance (patrol, patrolEnter);
	}


    void Update()
    {
		if (this.fsm != null) {
			float playerDist = (this.transform.position - GameManager.instance.InGameController.Airship.transform.position).magnitude;

			if (this.isPlayerDetected) {
				if (playerDist > this.attackDist) {
					if (fsm.CurrentState.Name != "moveToPlayer")
						this.fsm.dispatch ("moveToPlayer");
				} else {
					if (fsm.CurrentState.Name != "attack")
						this.fsm.dispatch ("attack");
				}

				if (playerDist > this.chaseDist) {
					Debug.Log ("no longer chasing");

					this.isPlayerDetected = false;
					this.fsm.dispatch ("patrol");
				}
				
				/*this.SetSpeed (1.0f);

			if (this.curCd > this.targetCd * 10)
			{
				this.curCd = 0;
				this.ability.Use(Vector3.zero);
			}

			this.headingDirection = (GameManager.instance.InGameController.Airship.transform.position - this.transform.position).normalized;*/
			} else {
				if (fsm.CurrentState.Name != "patrol")
					this.fsm.dispatch ("patrol");
			}

			this.fsm.Update ();

			Debug.Log (this.fsm.CurrentState.Name);
		}
    }


	//protected override bool CheckAgro (){
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
		//return false;
	//}



}

