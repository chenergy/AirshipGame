using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
	public float speed = 1.0f;

	private Vector3 direction;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		this.transform.position += this.direction * this.speed;
	}


	public void SetDirection (Vector3 dir){
		this.direction = dir;
	}
}

