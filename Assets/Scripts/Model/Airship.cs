using UnityEngine;
using System.Collections;

public class Airship : MonoBehaviour
{
	public float baseSpeed = 1.0f;

	private float speed = 0.0f;

	// Use this for initialization
	void Start ()
	{
		this.speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this.transform.position += this.transform.forward * speed * Time.deltaTime;
		//this.rigidbody.AddForce (this.transform.forward * speed * Time.deltaTime);
		//this.rigidbody.transform.forward = this.rigidbody.velocity;
		this.transform.position += this.transform.forward * Time.deltaTime * this.speed;
	}

	void OnDrawGizmosSelected (){
		Gizmos.DrawLine (this.transform.position, this.transform.position + this.transform.forward * 10);
	}


	public void Rotate (float degrees){
		this.transform.Rotate (0, -degrees * 0.1f, 0);
	}

	public void UpdateSpeed (float speedScale){
		this.speed = speedScale * this.baseSpeed;
	}
}

