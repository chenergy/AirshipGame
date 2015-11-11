using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayFPS: MonoBehaviour
{
	public Text text;

	// Update is called once per frame
	void Update ()
	{
		this.text.text = (1 / Time.smoothDeltaTime).ToString ();
	}
}
