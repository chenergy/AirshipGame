using UnityEngine;
using System.Collections;

public class Projectile_Homing : A_Projectile
{
	public float speed = 1.0f;
	public float turnSpeed = 1.0f;
	public int damage = 1;
	public float lifetime = 3.0f;

	private Vector3 direction;
	private A_Airship target;

	// Use this for initialization
	void Start ()
	{
		GameObject.Destroy (this.gameObject, this.lifetime);
	}

	// Update is called once per frame
	void Update ()
	{
		if (this.target != null) {
			this.direction = (this.target.transform.position - this.transform.position).normalized;
		}

		this.transform.forward = Vector3.Slerp (this.transform.forward, this.direction, Time.deltaTime * this.turnSpeed);

		this.transform.position += this.transform.forward * this.speed * Time.deltaTime;
	}


	public void SetDirection (Vector3 dir){
		this.direction = dir;
		this.transform.forward = dir;
	}


	public void SetTarget (A_Airship target){
		this.target = target;
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

