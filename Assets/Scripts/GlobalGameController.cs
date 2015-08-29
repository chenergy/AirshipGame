using UnityEngine;
using System.Collections;

public class GlobalGameController : MonoBehaviour {
	public GameObject airshipPrefab;

	public static GlobalGameController instance = null;

	// Use this for initialization
	void Awake () {
		if (instance != null)
			GameObject.Destroy (instance.gameObject);
		else
			instance = this;
	}
}
