using UnityEngine;
using System.Collections;

/// <summary>
/// A collider in the environment. Destroys projectiles that enter it.
/// Linked to a 2D overlay screen on a canvas.
/// </summary>
public class EnvironmentCollider : MonoBehaviour
{
	/// <summary>
	/// The attached renderer.
	/// </summary>
	public Renderer renderer;

	/// <summary>
	/// The reference to an opaque material.
	/// </summary>
	public Material opaqueMat;

	/// <summary>
	/// The reference to a transparent material.
	/// </summary>
	public Material transparentMat;

	/// <summary>
	/// The linked layer that contains the sprite data
	/// </summary>
	public Environment2DLayer m_linked2DLayer;

	/// <summary>
	/// Destroy incoming projectiles when hit.
	/// </summary>
	/// <param name="other">Other collider.</param>
	void OnTriggerEnter (Collider other){
		A_Projectile p = other.GetComponent <A_Projectile> ();
		if (p != null) {
			Debug.Log ("destroy");
			p.DestroyProjectile ();
		}
	}

	/// <summary>
	/// When the camera raycast has hit this collider, set its material to transparent.
	/// </summary>
	/// <param name="transparent">If set to <c>true</c> transparent.</param>
	public void SetTransparent (bool transparent){
		if (transparent)
			this.renderer.material = this.transparentMat;
		else
			this.renderer.material = this.opaqueMat;
	}

	/// <summary>
	/// When the camera raycast has hit this collider, send messaged to the attached layer that it has been hit.
	/// </summary>
	/*public void OnCameraRaycastHit (Vector3 worldPosition){
		m_linked2DLayer.OnCameraRaycastHit (worldPosition);
	}*/
}

