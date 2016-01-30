using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputHandler : MonoBehaviour
{
	public InGameController ingamecontroller;

	private int layerMask;
	private bool isRightMouseDown = false;


	void Start (){
		layerMask = LayerMask.GetMask (new string[] {"RaycastHitReceiver"});
	}
	
	// Update is called once per frame
	void Update ()
	{
#if UNITY_STANDALONE || UNITY_WEBGL
		if (Input.GetKeyDown (KeyCode.Alpha1)){
			this.ingamecontroller.ActivateAbility (0);
		} else if (Input.GetKeyDown (KeyCode.Alpha2)){
			this.ingamecontroller.ActivateAbility (1);
		} else if (Input.GetKeyDown (KeyCode.Alpha3)){
			this.ingamecontroller.ActivateAbility (2);
		} else if (Input.GetKeyDown (KeyCode.Alpha4)){
			this.ingamecontroller.ActivateAbility (3);
		}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.ToggleHeight();
        }

		// Right click on location.
		if (Input.GetMouseButton (1)) {
			RaycastHit hitInfo;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			Debug.DrawLine (r.origin, r.origin + r.direction * 100);
			if (Physics.Raycast (r, out hitInfo, 1000.0f, layerMask)) {
                this.ingamecontroller.SetAirshipTarget(hitInfo.point);
                this.StartRotateAirship ();
			}
		}
		if (Input.GetMouseButtonUp (1)){
            this.EndRotateAirship ();
		}
#endif
	}

	public void ActivateAbility (int charNum){
		this.ingamecontroller.ActivateAbility (charNum);
	}


	public void SetRotationAirship (float degrees){
		this.ingamecontroller.SetRotationAirship (degrees);
	}
	
	public void AddRotationAirship (float degrees){
		this.ingamecontroller.AddRotationAirship (degrees);
	}

    public void SetHeadingAirshipAdjusted(Vector3 direction)
    {
        this.ingamecontroller.SetHeadingAirshipAdjusted(direction);
    }

	public void StopAirshipMovingToTarget (){
		this.ingamecontroller.StopAirshipMovingToTarget ();
	}



	public void StartRotateAirship (){
        this.isRightMouseDown = true;
        this.ingamecontroller.StartRotateAirship ();
	}


	public void EndRotateAirship (){
        this.isRightMouseDown = false;
        this.ingamecontroller.EndRotateAirship ();
        this.StopAirshipMovingToTarget();
    }
	

	public void SetAirshipSpeed (float newSpeed){
		this.ingamecontroller.SetAirshipSpeed (newSpeed);
	}


	public void OnPointerDown (BaseEventData b){
		RaycastHit hitInfo;
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (r.origin, r.origin + r.direction * 100);
		if (Physics.Raycast (r, out hitInfo, 100.0f, layerMask)) {
			// Set the point to use an ability.
			this.UseAbility (hitInfo.point);
		}
	}


	public void OnPointerUp (BaseEventData b){
		if (this.isRightMouseDown) {
			this.isRightMouseDown = false;
			this.StopAirshipMovingToTarget();
		}
	}


    public void ToggleHeight()
    {
        if (this.ingamecontroller.Airship.HeightLevel == GameEnum.HeightLevel.LOWER)
            this.ingamecontroller.GoToUpperLevel();
        else
            this.ingamecontroller.GoToLowerLevel();
    }


	/*private void MoveToScreenPoint (Vector3 mousePosition){
		RaycastHit hitInfo;
		Ray r = Camera.main.ScreenPointToRay (mousePosition);
		Debug.DrawLine (r.origin, r.origin + r.direction * 100);
		if (Physics.Raycast (r, out hitInfo, 100.0f, layerMask)) {
			this.ingamecontroller.SetAirshipSpeed (1.0f);
			this.ingamecontroller.SetHeadingAirship ((hitInfo.point - this.ingamecontroller.airship.transform.position).normalized);
		}
	}*/

	/*private void SetAbilityPoint (BaseEventData b){
		RaycastHit hitInfo;
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (r.origin, r.origin + r.direction * 100);
		if (Physics.Raycast (r, out hitInfo, 100.0f, layerMask)) {
			this.UseAbility (hitInfo.point);
		}
	}*/


	private void UseAbility (Vector3 target){
		this.ingamecontroller.UseAbility (target);
	}
}

