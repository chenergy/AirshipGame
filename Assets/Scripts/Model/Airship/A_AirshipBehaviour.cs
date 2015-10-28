using UnityEngine;
using System.Collections;
using FSM;

public abstract class A_AirshipBehaviour : MonoBehaviour
{
	public A_Airship airship;
	public FSMContext fsm;

	protected abstract bool CheckAgro ();
}

