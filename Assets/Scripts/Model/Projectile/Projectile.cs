using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float speed = 1.0f;
	public int damage = 1;
	public float lifetime = 3.0f;

	private Vector3 direction;
	private A_Airship owner;

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

	public void SetOwner (A_Airship owner){
		this.owner = owner;
	}


	void OnTriggerEnter (Collider other){
		A_Airship a = other.GetComponent <A_Airship> ();
		if (a != null && a != this.owner) {
			//a.TakeDamage (this.damage);
			GameObject.Destroy (this.gameObject);
		}
	}
}

