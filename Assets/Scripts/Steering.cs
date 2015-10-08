using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class Steering : MonoBehaviour
{
	public InputHandler input;
	public RectTransform rectTransform;
	//public Transform target;
	public Vector2 minMaxRotation;

	private float curAngle = 0.0f;
	private Vector2 lastLocation;
	private Vector3 v1;
	private Vector3 v2;


	// Use this for initialization
	//void Start () {
	//}
	
	// Update is called once per frame
	//void Update () {
	//}


	public void OnPointerDown (BaseEventData eventData){
		PointerEventData ped = (PointerEventData)eventData;
		this.lastLocation = ped.position;
		StopCoroutine ("RotateToZero");

		this.input.StartRotateAirship ();
	}


	public void OnPointerUp (BaseEventData eventData){
		this.lastLocation = Vector2.zero;
		this.v1 = Vector3.zero;
		this.v2 = Vector3.zero;

		//this.rectTransform.rotation = Quaternion.identity;
		StartCoroutine ("RotateToZero");

		this.input.EndRotateAirship ();
	}


	public void OnDrag (BaseEventData eventData){
		PointerEventData ped = (PointerEventData)eventData;
		// Vector from center to last touch position.
		this.v1 = new Vector3 (this.lastLocation.x, this.lastLocation.y) - this.rectTransform.position;

		// Vector from center to cur touch position.
		this.v2 = new Vector3 (ped.position.x, ped.position.y) - this.rectTransform.position;

		// Get angle between the vectors, direction based on turn direction.
		float angleBetween = Vector3.Angle (v1, v2) * Mathf.Sign(Vector3.Cross (v1, v2).z);

		// Add angle to start angle.
		this.curAngle += angleBetween;

		// Clamp angle between the min and max angles possible.
		this.curAngle = Mathf.Clamp (this.curAngle, this.minMaxRotation.x, this.minMaxRotation.y);

		// Rotate this image.
		//this.rectTransform.Rotate (0, 0, angleBetween);
		this.rectTransform.rotation = Quaternion.Euler (0, 0, this.curAngle);

		// Rotate the airship.
		//this.input.RotateAirship (angleBetween);
		this.input.RotateAirship (curAngle);

		// Save this cur touch position as last.
		this.lastLocation = ped.position;
	}


	IEnumerator RotateToZero (){
		while (Mathf.Abs (this.curAngle) > 0.01f) {
			yield return new WaitForEndOfFrame ();
			//this.rectTransform.rotation = Quaternion.Lerp (this.rectTransform.rotation, Quaternion.identity, 
			//this.rectTransform.rotation = Quaternion.RotateTowards (this.rectTransform.rotation, Quaternion.identity, Time.deltaTime * 100);
			this.rectTransform.rotation = Quaternion.Euler (0, 0, this.curAngle);

			this.input.RotateAirship (this.curAngle);

			this.curAngle = Mathf.Lerp (this.curAngle, 0.0f, Time.deltaTime * 10);
		}

		this.rectTransform.rotation = Quaternion.identity;
	}


	/*void OnDrawGizmos (){
		if (this.v1 != Vector3.zero && this.v2 != Vector3.zero) {
			Gizmos.DrawLine (this.rectTransform.position, this.v1);
			Gizmos.DrawLine (this.rectTransform.position, this.v2);
		}
	}*/
}

