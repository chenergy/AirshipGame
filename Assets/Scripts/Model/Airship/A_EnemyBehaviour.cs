using UnityEngine;
using System.Collections;
using FSM;

public abstract class A_EnemyBehaviour : MonoBehaviour
{
	public Airship_Enemy owner;
	public FSMContext fsm;

	protected bool isPlayerDetected = false;

	//protected abstract bool CheckAgro ();
	public void SetPlayerDetected (bool detected){
		Debug.Log ("chasing");
		this.isPlayerDetected = detected;
	}
}

