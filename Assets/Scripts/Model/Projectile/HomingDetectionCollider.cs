using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HomingDetectionCollider : MonoBehaviour
{
	public Projectile_Homing homing;

	private List<Hitbox> hitboxes = new List<Hitbox> ();
	private Hitbox targetHitbox = null;


	void LateUpdate (){
		if (this.targetHitbox == null) {
			float minDist = 1000000.0f;

			foreach (Hitbox hb in this.hitboxes) {
				float sqDist = (hb.transform.position - this.transform.position).sqrMagnitude;
				if (sqDist < minDist) {
					minDist = sqDist;
					this.targetHitbox = hb;
				}
			}

			if (this.targetHitbox != null) {
				this.homing.SetTarget (targetHitbox.owner);
				this.GetComponent<Collider> ().enabled = false;
			}
		}
	}

	void OnTriggerEnter (Collider other){
		Hitbox hb = other.GetComponent <Hitbox> ();
		if (hb != null){
			if (hb.owner != this.homing.Owner) {
				if (!this.hitboxes.Contains (hb)) {
					this.hitboxes.Add (hb);
				}
			}
		}
	}
}

