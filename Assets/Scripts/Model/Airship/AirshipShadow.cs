using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The shadow underneath the airship.
/// </summary>
public class AirshipShadow : MonoBehaviour
{
	/// <summary>
	/// The airship target that the shadow is following.
	/// </summary>
	public A_Airship m_target;

	/// <summary>
	/// The sprite renderer.
	/// </summary>
	public SpriteRenderer m_spriteRenderer;

	/// <summary>
	/// The layer mask of the objects being detected.
	/// </summary>
	private int m_layerMask;

	/// <summary>
	/// The list of hit colliders between shadow and camera.
	/// </summary>
	private List<int> hitColliders = new List<int> ();

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake (){
		m_layerMask = LayerMask.GetMask (new string[] {"EnvironmentCollider"});
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update (){
		this.hitColliders.Clear ();

		// Raycast to determine y elevation.
		RaycastHit hit;
		if (m_target != null) {
			if (Physics.Raycast (m_target.transform.position, Vector3.down, out hit, 100.0f, m_layerMask)) {
				this.transform.position = hit.point;
			}
		}

		// Raycast to determine when to render the shadow.
		Ray r = Camera.main.ScreenPointToRay (new Vector3(Screen.width/2.0f, Screen.height/2.0f, 0.0f));
		RaycastHit cameraHit;
		if (Physics.Raycast (this.transform.position, -r.direction, out cameraHit, 100.0F, this.m_layerMask)) {
			EnvironmentCollider ec = hit.collider.GetComponent <EnvironmentCollider> ();
			if (ec != null) {
				m_spriteRenderer.sortingOrder = ec.m_linked2DLayer.m_sortingLayer - 2;
				Debug.Log (m_spriteRenderer.sortingOrder.ToString ());
			}
		} else {
			m_spriteRenderer.sortingOrder = 1;
		}

		/*foreach (RaycastHit h in hits) {
			EnvironmentCollider ec = hit.collider.GetComponent <EnvironmentCollider> ();
			if (ec != null) {
				if (ec.m_linked2DLayer != null) {
					hitColliders.Add (ec.m_linked2DLayer.m_sortingLayer);
				}
			}
		}*/
	}
}

