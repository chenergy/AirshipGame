using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ErrorLog : MonoBehaviour
{
	public Text error;


	// Use this for initialization
	void Start ()
	{
		this.error.text = "";
		this.error.color = new Color (this.error.color.r, this.error.color.g, this.error.color.b, 0.0f);
	}


	public void LogErrorText (string text) {
		StopCoroutine ("SetTextRoutine");
		StartCoroutine ("SetTextRoutine", text);
	}

	IEnumerator SetTextRoutine (string text){
		float timer = 0.0f;
		float staticDuration = 2.0f;
		float fadeDuration = 1.0f;

		this.error.text = text;
		this.error.color = new Color (this.error.color.r, this.error.color.g, this.error.color.b, 1.0f);

		while (timer < staticDuration){
			yield return new WaitForEndOfFrame ();
			timer += Time.deltaTime;
		}

		timer = 0.0f;

		while (timer < fadeDuration){
			yield return new WaitForEndOfFrame ();
			this.error.color = new Color (this.error.color.r, this.error.color.g, this.error.color.b, Mathf.Lerp (1.0f, 0.0f, timer / fadeDuration));
			timer += Time.deltaTime;
		}

		this.error.color = new Color (this.error.color.r, this.error.color.g, this.error.color.b, 0.0f);
	}
}

