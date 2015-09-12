using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public GameObject airshipPrefab;

	public static GameManager instance = null;

	// Use this for initialization
	void Awake () {
		if (instance != null)
			GameObject.Destroy (instance.gameObject);
		else
			instance = this;
	}
}
