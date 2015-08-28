using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour
{
	public Transform target;
	public float followSpeed = 1.0f;
	public Vector3 targetLocalOffset;

	private Vector3 cameraWorldPosition;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		this.cameraWorldPosition = this.target.TransformPoint (this.targetLocalOffset);
		this.transform.position = Vector3.Lerp (this.transform.position, this.cameraWorldPosition, Time.deltaTime * this.followSpeed);
	}

	void OnDrawGizmos (){
		Gizmos.DrawSphere (this.cameraWorldPosition, 1.0f);
	}
}

