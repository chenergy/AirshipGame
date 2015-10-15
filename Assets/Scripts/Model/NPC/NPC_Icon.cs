using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC_Icon : MonoBehaviour
{
	//public Transform iconTransform;
	public float rotationSpeed;
	private bool activated = false;


	void Update (){
		if (!this.activated) {
			this.Idle ();
		}
	}

	public void Enable (){
		this.gameObject.SetActive (true);
	}

	public void Disable (){
		this.gameObject.SetActive (false);
	}

	public void Activate (){
		if (!this.activated) {
			this.activated = true;
			StartCoroutine ("ActivationRoutine");
		}
	}

	public void Idle () {
		this.transform.Rotate (0.0f, this.rotationSpeed * Time.deltaTime, 0.0f);
	}

	IEnumerator ActivationRoutine (){
		this.rotationSpeed *= 2.0f;

		yield return new WaitForSeconds (1.0f);

		this.Disable ();
	}
}

