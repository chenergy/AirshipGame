using UnityEngine;
using System.Collections;

public class LookAtMainCamera : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main != null)
			this.transform.rotation = Camera.main.transform.rotation;
	}
}
