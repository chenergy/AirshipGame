using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float speed = 1.0f;
	public int damage = 1;
	public float lifetime = 3.0f;

	private Vector3 direction;

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
		Airship_Enemy e = other.GetComponent <Airship_Enemy> ();
		if (e != null) {
			e.TakeDamage (this.damage);
			GameObject.Destroy (this.gameObject);
		}
	}
}

