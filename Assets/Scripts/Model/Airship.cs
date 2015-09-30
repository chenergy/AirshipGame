using UnityEngine;
using System.Collections;

public class Airship : MonoBehaviour
{
	public float speed = 1.0f;
	//public Rigidbody rigidbody;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this.transform.position += this.transform.forward * speed * Time.deltaTime;
		//this.rigidbody.AddForce (this.transform.forward * speed * Time.deltaTime);
		//this.rigidbody.transform.forward = this.rigidbody.velocity;
		this.transform.position += this.transform.forward * Time.deltaTime * this.speed;
	}

	void OnDrawGizmos (){
		Gizmos.DrawLine (this.transform.position, this.transform.position + this.transform.forward * 10);
	}


	public void Rotate (float degrees){
		this.transform.Rotate (0, -degrees * 0.1f, 0);
	}

	public void UpdateSpeed (float newSpeed){
		this.speed = newSpeed;
	}
}

