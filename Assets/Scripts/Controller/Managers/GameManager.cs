using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public SO_Characters characterProperties;
	public SO_Abilities abilityProperties;
    public SO_Airships airshipProperties;
	
	private DataManager data;
	public DataManager Data {
		get { return this.data; }
	}

	public InGameController InGameController { get; set; }

	public static GameManager instance = null;

	// Use this for initialization
	void Awake () {
		if (instance != null) {
			GameObject.Destroy (instance.gameObject);
		} else {
			this.data = new DataManager (this.characterProperties, this.abilityProperties, this.airshipProperties);

			DontDestroyOnLoad (this.gameObject);
			instance = this;
		}
	}
}
