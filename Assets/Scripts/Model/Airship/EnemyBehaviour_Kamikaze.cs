﻿using UnityEngine;
using System.Collections;
using FSM;

public class EnemyBehaviour_Kamikaze : A_EnemyBehaviour
{
    public Transform[] patrolPoints;
    public float chaseDist = 10.0f;


    void Start()
    {
        StartCoroutine("LateStart");
    }


    IEnumerator LateStart()
    {
        yield return new WaitForEndOfFrame();

        FSMAction noAction = new FSMAction_None();

        // Setup actions.
        FSMAction moveToPlayerEnter = new FSMAction_MoveToPlayerEnter(this.owner);
        FSMAction moveToPlayerUpdate = new FSMAction_MoveToPlayerUpdate(this.owner, GameManager.instance.InGameController.Airship);
        FSMAction moveToPlayerExit = new FSMAction_MoveToPlayerExit(this.owner);
        FSMState moveToPlayer = new FSMState("moveToPlayer", moveToPlayerEnter, moveToPlayerUpdate, moveToPlayerExit);

        FSMAction patrolEnter = new FSMAction_PatrolEnter(this.owner);
        FSMAction patrolUpdate = new FSMAction_PatrolUpdate(this.owner, this.patrolPoints);
        FSMAction patrolExit = new FSMAction_PatrolExit(this.owner);
        FSMState patrol = new FSMState("patrol", patrolEnter, patrolUpdate, patrolExit);

        // Setup transitions.
        moveToPlayer.addTransition(new FSMTransition(patrol, noAction), "patrol");

        patrol.addTransition(new FSMTransition(moveToPlayer, noAction), "moveToPlayer");

        this.fsm = FSM.FSM.createFSMInstance(patrol, patrolEnter);
    }


    void Update()
    {
        if (this.fsm != null)
        {
            if (this.isPlayerDetected)
            {
                float playerDist = (this.transform.position - GameManager.instance.InGameController.Airship.transform.position).magnitude;

                if (fsm.CurrentState.Name != "moveToPlayer")
                    this.fsm.dispatch("moveToPlayer");

                if (playerDist > this.chaseDist)
                {
                    Debug.Log("no longer chasing");

                    this.isPlayerDetected = false;
                    this.fsm.dispatch("patrol");
                }
            }
            else
            {
                if (fsm.CurrentState.Name != "patrol")
                    this.fsm.dispatch("patrol");
            }

            this.fsm.Update();
        }
    }
}

