using UnityEngine;
using System.Collections;

public abstract class A_Airship : MonoBehaviour
{
	public GameObject model;

	public CharacterController cc;
	public float baseMoveSpeed = 1.0f;
	public float baseRotationSpeed = 1.0f;

	protected float targetSpeed = 0.0f;
	protected float curSpeed = 0.0f;
	protected float acceleration = 1.0f;
	protected float rotationSpeed = 0.0f;
	protected float curRotateRad = 0.0f;
	protected Vector3 headingDirection;

	private float startY = 0.0f;

	// Use this for initialization
	protected virtual void Start ()
	{
		this.rotationSpeed = this.baseRotationSpeed;
        this.headingDirection = this.transform.forward;
		this.startY = this.transform.position.y;
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		// Interpolate towards target speed.
		if (Mathf.Abs (this.targetSpeed - this.curSpeed) > 0.001f)
			this.curSpeed = Mathf.Lerp (this.curSpeed, this.targetSpeed, Time.deltaTime * this.acceleration);
		else
			this.curSpeed = this.targetSpeed;

        // Movement translation.
		this.cc.Move (this.transform.forward * Time.deltaTime * this.curSpeed);

        // Movement rotation.
        float sqrMag = (this.transform.forward - this.headingDirection).sqrMagnitude;

        if (sqrMag > 0.01f)
        {
            //this.transform.rotation = Quaternion.FromToRotation(this.transform.forward, this.headingDirection);
            this.transform.forward = Vector3.Lerp(this.transform.forward, this.headingDirection, Time.deltaTime * this.rotationSpeed);

            Vector3 cross = Vector3.Cross(this.transform.forward, this.headingDirection);
            if (cross.y > 0)
                this.model.transform.localRotation = Quaternion.Lerp(this.model.transform.localRotation, Quaternion.Euler(0, 0, -sqrMag * 10), Time.deltaTime * 10);
            else
                this.model.transform.localRotation = Quaternion.Lerp(this.model.transform.localRotation, Quaternion.Euler(0, 0, sqrMag * 10), Time.deltaTime * 10);
        }

		this.transform.position = new Vector3 (this.transform.position.x, this.startY, this.transform.position.z);

        // Local object rotations.
        //this.heading.transform.LookAt(this.transform.position + this.headingDirection);
	}


	public void SetRotation (float degrees){
		this.curRotateRad = degrees * (Mathf.PI / 180.0f) * 0.5f;
	}

	public void AddRotation (float degrees){
		this.curRotateRad += degrees * (Mathf.PI / 180.0f) * 0.5f;
	}

    public void SetHeading (Vector3 direction)
    {
        this.headingDirection = this.RotateVector (direction, -Mathf.PI / 4);
    }


	/*public void StartRotate (){
		this.heading.TurnOn ();
	}

	public void EndRotate (){
		this.heading.TurnOff ();
	}*/

	public void UpdateSpeed (float speedScale){
		this.targetSpeed = speedScale * this.baseMoveSpeed;
	}

	private Vector3 RotateVector (Vector3 baseVector, float radians){
		float x0 = baseVector.x;
		float z0 = baseVector.z;
		float x1 = x0 * TrigLookup.Cos (radians) - z0 * TrigLookup.Sin (radians);
		float z1 = x0 * TrigLookup.Sin (radians) + z0 * TrigLookup.Cos (radians);

		return new Vector3 (x1, baseVector.y, z1);
	}

	/*public void SetTargetSpeed (float speed){
		this.targetSpeed = speed;
	}*/
}

