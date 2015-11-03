using UnityEngine;
using System.Collections;

public class EnvironmentCollider : MonoBehaviour
{
	public Renderer renderer;
	public Material opaqueMat;
	public Material transparentMat;


	void OnTriggerEnter (Collider other){
		A_Projectile p = other.GetComponent <A_Projectile> ();
		if (p != null) {
			Debug.Log ("destroy");
			p.DestroyProjectile ();
		}
	}


	public void SetTransparent (bool transparent){
		if (transparent)
			this.renderer.material = this.transparentMat;
		else
			this.renderer.material = this.opaqueMat;
	}
}

