using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	//public GameObject airshipPrefab;
	public SO_Characters characterProperties;
	
	private DataManager data;
	public DataManager Data {
		get { return this.data; }
	}

	public static GameManager instance = null;

	// Use this for initialization
	void Awake () {
		if (instance != null) {
			GameObject.Destroy (instance.gameObject);
		} else {
			this.data = new DataManager(this.characterProperties);

			instance = this;
		}
	}
}
