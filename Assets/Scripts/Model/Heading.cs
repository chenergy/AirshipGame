using UnityEngine;
using System.Collections;

public class Heading : MonoBehaviour
{
	public SpriteRenderer icon;
	public float turnOffTime = 1.0f;

	void Start (){
		this.icon.color = new Color (this.icon.color.r, this.icon.color.g, this.icon.color.b, 0.0f);
	}

	public void TurnOn (){
		Debug.Log ("turn on");
		StopCoroutine ("TurnOffRoutine");
		this.icon.color = new Color (this.icon.color.r, this.icon.color.g, this.icon.color.b, 1.0f);
	}

	public void TurnOff (){
		Debug.Log ("turn off");
		StartCoroutine ("TurnOffRoutine");
	}

	IEnumerator TurnOffRoutine (){
		float timer = 0.0f;
		float alpha = 1.0f;

		while (timer < this.turnOffTime) {
			Debug.Log (timer);
			yield return new WaitForEndOfFrame ();
			alpha = Mathf.Lerp (1.0f, 0.0f, timer / this.turnOffTime);
			this.icon.color = new Color (this.icon.color.r, this.icon.color.g, this.icon.color.b, alpha);
			timer += Time.deltaTime;
		}

		this.icon.color = new Color (this.icon.color.r, this.icon.color.g, this.icon.color.b, 0.0f);
	}
}

