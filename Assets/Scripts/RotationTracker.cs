using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;


public class RotationTracker : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
	public RectTransform rectTransform;
	public Transform target;

	private Vector2 lastLocation;

	private Vector3 v1;
	private Vector3 v2;


	// Use this for initialization
	/*void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}*/


	public void OnPointerDown (PointerEventData eventData){
		this.lastLocation = eventData.position;
	}


	public void OnPointerUp (PointerEventData eventData){
		this.lastLocation = Vector2.zero;
		this.v1 = Vector3.zero;
		this.v2 = Vector3.zero;
	}


	public void OnDrag (PointerEventData eventData){
		this.v1 = new Vector3 (this.lastLocation.x, this.lastLocation.y) - this.rectTransform.position;
		this.v2 = new Vector3 (eventData.position.x, eventData.position.y) - this.rectTransform.position;

		float angleBetween = Vector3.Angle (v1, v2) * Mathf.Sign(Vector3.Cross (v1, v2).z);

		this.rectTransform.Rotate (0, 0, angleBetween);

		this.lastLocation = eventData.position;

		this.target.Rotate (0, -angleBetween * 0.1f, 0);
	}

	void OnDrawGizmos (){
		if (this.v1 != Vector3.zero && this.v2 != Vector3.zero) {
			Gizmos.DrawLine (this.rectTransform.position, this.v1);
			Gizmos.DrawLine (this.rectTransform.position, this.v2);
		}
	}
}

