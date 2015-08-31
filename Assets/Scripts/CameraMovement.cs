using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public Transform target;
	public float followSpeed = 1.0f;
	//public Vector3 targetLocalOffset;

	//private Vector3 cameraWorldPosition;

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		//this.cameraWorldPosition = this.target.TransformPoint (this.targetLocalOffset);
		Vector3 targetPos = new Vector3 (this.target.position.x, this.transform.position.y, this.target.position.z);
		this.transform.position = Vector3.Lerp (this.transform.position, targetPos, Time.deltaTime * this.followSpeed);
	}

	/*void OnDrawGizmos (){
		Gizmos.DrawSphere (this.cameraWorldPosition, 1.0f);
	}*/
}

