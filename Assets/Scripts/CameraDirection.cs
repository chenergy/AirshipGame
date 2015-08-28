using UnityEngine;
using System.Collections;

public class CameraDirection : MonoBehaviour
{
	public Transform target;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		this.transform.LookAt (target.position);
	}
}

