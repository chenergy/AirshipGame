using UnityEngine;
using System.Collections;

public class Projectile_Basic : A_Projectile
{
	public float speed = 1.0f;
	public int damage = 1;
	public float lifetime = 3.0f;

	private Vector3 direction;
	//private A_Airship owner;

	// Use this for initialization
	void Start ()
	{
		GameObject.Destroy (this.gameObject, this.lifetime);
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position += this.direction * this.speed * Time.deltaTime;
	}


	public void SetDirection (Vector3 dir){
		this.direction = dir;
	}


	void OnTriggerEnter (Collider other){
		Hitbox hb = other.GetComponent <Hitbox> ();
		if (hb != null){
			if (hb.owner != this.owner) {
				hb.TakeDamage (this.damage);
				GameObject.Destroy (this.gameObject);
			}
		}
	}


	public override void DestroyProjectile ()
	{
		GameObject.Destroy (this.gameObject);
	}
}

