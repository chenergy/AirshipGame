using UnityEngine;
using System.Collections;

public abstract class A_Airship : MonoBehaviour
{
	public GameObject model;

	public CharacterController cc;
	public float baseMoveSpeed = 1.0f;
	public float baseRotationSpeed = 1.0f;
    public bool tiltWhileRotating = true;

	private float targetSpeed = 0.0f;
	private float curSpeed = 0.0f;
	private float acceleration = 1.0f;
	private float rotationSpeed = 0.0f;
	private float curRotateRad = 0.0f;
	private GameEnum.HeightLevel heightLevel = GameEnum.HeightLevel.LOWER;
	protected Vector3 headingDirection;

    private Vector3 startPos;
    public Vector3 StartPosition
    {
        get { return this.startPos; }
    }

    private bool isMovingToTarget = false;
	private Vector3 moveTarget;

	// Use this for initialization
	protected virtual void Start ()
	{
		this.rotationSpeed = this.baseRotationSpeed;
        this.headingDirection = this.transform.forward;
		this.startPos = this.transform.position;
	}
	
	// Update is called once per frame
	protected virtual void Update ()
	{
		if (this.isMovingToTarget) {
			this.headingDirection = (this.moveTarget - this.transform.position).normalized;
		}

		// Interpolate towards target speed.
		if (Mathf.Abs (this.targetSpeed - this.curSpeed) > 0.001f)
			this.curSpeed = Mathf.Lerp (this.curSpeed, this.targetSpeed, Time.deltaTime * this.acceleration);
		else
			this.curSpeed = this.targetSpeed;

		// Movement translation.
		this.cc.Move (this.transform.forward * Time.deltaTime * this.curSpeed);

		// Movement rotation.
		float sqrMag = (this.transform.forward - this.headingDirection).sqrMagnitude;

		if (sqrMag > 0.001f) {
			//this.transform.forward = Vector3.Lerp (this.transform.forward, this.headingDirection, Time.deltaTime * this.rotationSpeed);
			//this.transform.forward = Vector3.RotateTowards (this.transform.forward, this.headingDirection, Time.deltaTime * this.rotationSpeed, 0.0f);
			this.transform.forward = Vector3.Slerp (this.transform.forward, this.headingDirection, Time.deltaTime * this.rotationSpeed);

            // Tilt the local model in the direction of the rotation.
            if (this.tiltWhileRotating)
            {
                Vector3 cross = Vector3.Cross(this.transform.forward, this.headingDirection);

                if (cross.y > 0)
                    this.model.transform.localRotation = Quaternion.Lerp(this.model.transform.localRotation, Quaternion.Euler(0, 0, -sqrMag * 20), Time.deltaTime);
                else
                    this.model.transform.localRotation = Quaternion.Lerp(this.model.transform.localRotation, Quaternion.Euler(0, 0, sqrMag * 20), Time.deltaTime);
            }
		}

		if (this.heightLevel == GameEnum.HeightLevel.LOWER)
			this.transform.position = new Vector3 (this.transform.position.x, Mathf.Lerp (this.transform.position.y, this.startPos.y, Time.deltaTime * 5), this.transform.position.z);
		else if (this.heightLevel == GameEnum.HeightLevel.UPPER)
			this.transform.position = new Vector3 (this.transform.position.x, Mathf.Lerp (this.transform.position.y, this.startPos.y + 10, Time.deltaTime * 5), this.transform.position.z);
	}


    // Steering and rotation.
    public void SetRotation (float degrees){
		this.curRotateRad = degrees * (Mathf.PI / 180.0f) * 0.5f;
	}

	public void AddRotation (float degrees){
		this.curRotateRad += degrees * (Mathf.PI / 180.0f) * 0.5f;
	}

    public void SetHeadingAdjusted (Vector3 direction)
    {
        this.headingDirection = this.RotateVector (direction, -Mathf.PI / 4);
    }

    public void SetHeading (Vector3 direction)
    {
        this.headingDirection = direction;
    }

	public void SetMoveTarget (Vector3 moveTarget){
		this.moveTarget = new Vector3 (moveTarget.x, this.transform.position.y, moveTarget.z);
		this.SetSpeed (1.0f);
		this.isMovingToTarget = true;
	}

	public void StopMovingToTarget (){
		this.SetSpeed (0.0f);
		this.isMovingToTarget = false;
	}


	/*public void StartRotate (){
		this.heading.TurnOn ();
	}

	public void EndRotate (){
		this.heading.TurnOff ();
	}*/


	public void SetSpeed (float speedScale){
		this.targetSpeed = Mathf.Clamp (speedScale, 0.0f, 1.0f) * this.baseMoveSpeed;
	}


	public void MoveToHeightLevel (GameEnum.HeightLevel heightLevel){
		if (this.heightLevel != heightLevel) {
			/*if (heightLevel == GameEnum.HeightLevel.LOWER) {
				
			} else if (heightLevel == GameEnum.HeightLevel.UPPER) {
				
			}*/
			this.heightLevel = heightLevel;
		}
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


	public abstract void TakeDamage(int position, int damage);
}

