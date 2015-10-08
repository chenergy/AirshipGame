using UnityEngine;
using System.Collections;

public class Airship : MonoBehaviour
{
	public GameObject model;
	public Heading heading;
	public float baseSpeed = 1.0f;
	//public float minRotate = -60.0f;
	//public float maxRotate = 60.0f;

	private float speed = 0.0f;
	private float curRotateRad = 0.0f;
	private Vector3 curForward;
	//private Vector3 targetForward;
	//private Vector3 baseForward;

	private Rigidbody rb;


	// Use this for initialization
	void Start ()
	{
		this.rb = this.GetComponent <Rigidbody> ();
		//this.curForward = this.targetForward = this.baseForward = this.transform.forward;
		this.curForward = this.transform.forward;
		this.speed = baseSpeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//this.curForward = this.transform.forward;

		this.transform.position += this.transform.forward * Time.deltaTime * this.speed;

		//this.transform.position += this.curForward * Time.deltaTime * this.speed;
		//this.rb.AddForce (this.curForward * Time.deltaTime * this.speed);
		//Vector3.RotateTowards (this.curForward, this.targetForward, Time.deltaTime * 10, Time.deltaTime * 10);
		//this.rb.AddTorque (0, -this.curRotateRad, 0);
		this.transform.Rotate (0, -this.curRotateRad, 0);

		// Local object rotations.
		this.model.transform.localRotation = Quaternion.Euler (0, 0, this.curRotateRad * 10);
		this.heading.transform.LookAt (this.transform.position + this.RotateVector (this.transform.forward * 10, this.curRotateRad));
	}

	void OnDrawGizmosSelected (){
		//Gizmos.DrawLine (this.transform.position, this.transform.position + this.transform.forward * 10);
		Gizmos.DrawLine (this.transform.position, this.transform.position + this.transform.forward * 10);
		Gizmos.DrawLine (this.transform.position, this.transform.position + this.RotateVector (this.transform.forward * 10, this.curRotateRad));
	}


	public void SetRotate (float degrees){
		//this.transform.Rotate (0, -degrees * 0.1f, 0);
		//this.transform.Rotate (0, -degrees, 0);
		//this.transform.rotation = Quaternion.Euler (0, -degrees * 0.5f, 0);

		//this.curRotate = degrees;
		//this.rb.AddTorque (0, this.curRotate, 0);

		//this.curRotate = Mathf.Clamp (this.curRotate + degrees, this.minRotate, this.maxRotate);
		this.curRotateRad = degrees * (Mathf.PI / 180.0f) * 0.5f;

		/*float x0 = this.baseForward.x;
		float z0 = this.baseForward.z;
		float x1 = x0 * TrigLookup.Cos (this.curRotateRad) - z0 * TrigLookup.Sin (this.curRotateRad);
		float z1 = x0 * TrigLookup.Sin (this.curRotateRad) + z0 * TrigLookup.Cos (this.curRotateRad);

		this.targetForward = new Vector3 (x1, this.baseForward.y, z1);*/
		//this.targetForward = this.RotateVector (this.baseForward, this.curRotateRad);

		//this.rb.AddTorque (0, -this.curRotateRad, 0);
		//this.heading.TurnOn ();
	}

	public void StartRotate (){
		this.heading.TurnOn ();
	}

	public void EndRotate (){
		this.heading.TurnOff ();
	}


	public void UpdateSpeed (float speedScale){
		this.speed = speedScale * this.baseSpeed;
	}


	private Vector3 RotateVector (Vector3 baseVector, float radians){
		float x0 = baseVector.x;
		float z0 = baseVector.z;
		float x1 = x0 * TrigLookup.Cos (radians) - z0 * TrigLookup.Sin (radians);
		float z1 = x0 * TrigLookup.Sin (radians) + z0 * TrigLookup.Cos (radians);

		return new Vector3 (x1, baseVector.y, z1);
	}
}

