using UnityEngine;
using System.Collections;
using FSM;

public abstract class A_EnemyBehaviour : MonoBehaviour
{
	public Airship_Enemy owner;
	public FSMContext fsm;

	protected bool isPlayerDetected = false;


	void Start (){
		StartCoroutine("LateStart");
	}


	void Update (){
		this.UpdateBehaviour ();
	}


	//protected abstract bool CheckAgro ();
	public void SetPlayerDetected (bool detected){
		Debug.Log ("chasing");
		this.isPlayerDetected = detected;
	}

	protected abstract IEnumerator LateStart();
	protected abstract void UpdateBehaviour ();
}

