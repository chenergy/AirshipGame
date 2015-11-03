using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraRaycast : MonoBehaviour
{
	private int layerMask;
	private List <EnvironmentCollider> hitColliders = new List<EnvironmentCollider> ();

	// Use this for initialization
	void Start ()
	{
		layerMask = LayerMask.GetMask (new string[] {"EnvironmentCollider"});
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.instance.InGameController.Airship != null) {
			// Clear the hit colliders.
			this.hitColliders.Clear ();

			// Get all hit colliders.
			Ray r = Camera.main.ScreenPointToRay (new Vector3(Screen.width/2.0f, Screen.height/2.0f, 0.0f));
			RaycastHit[] hits;
			hits = Physics.RaycastAll(r, 100.0F, this.layerMask);

			for (int i = 0; i < hits.Length; i++) {
				RaycastHit hit = hits[i];
				//Renderer rend = hit.transform.GetComponent<Renderer>();
				EnvironmentCollider ec = hit.collider.GetComponent <EnvironmentCollider> ();
				if (ec != null) {
					this.hitColliders.Add (ec);
				}
			}

			foreach (EnvironmentCollider ec in FindObjectsOfType <EnvironmentCollider>()) {
				if (this.hitColliders.Contains (ec))
					ec.SetTransparent (true);
				else
					ec.SetTransparent (false);
			}
		}
	}
}

