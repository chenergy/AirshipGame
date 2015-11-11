using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public float followSpeed = 1.0f;
    //public Vector3 targetLocalOffset;

    //private Vector3 cameraWorldPosition;
    private Transform target;


    // Use this for initialization
    void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
        //this.cameraWorldPosition = this.target.TransformPoint (this.targetLocalOffset);
        if (this.target != null)
        {
            Vector3 targetPos = new Vector3(this.target.position.x, this.target.position.y, this.target.position.z);
            this.transform.position = Vector3.Lerp(this.transform.position, targetPos, Time.deltaTime * this.followSpeed);
        }
	}

    public void SetTarget (Transform target)
    {
        this.target = target;
    }

	/*void OnDrawGizmos (){
		Gizmos.DrawSphere (this.cameraWorldPosition, 1.0f);
	}*/
}

