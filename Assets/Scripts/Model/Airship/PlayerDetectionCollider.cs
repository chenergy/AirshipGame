using UnityEngine;
using System.Collections;

public class PlayerDetectionCollider : MonoBehaviour
{
	public A_EnemyBehaviour behaviour;

	void OnTriggerEnter (Collider other){
		if (other.GetComponent <Airship_Player> () != null)
			this.behaviour.SetPlayerDetected (true);
	}
}

