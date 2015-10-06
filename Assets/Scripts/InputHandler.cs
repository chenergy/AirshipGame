using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class InputHandler : MonoBehaviour
{
	public InGameController ingamecontroller;

	private int layerMask;


	void Start (){
		layerMask = LayerMask.GetMask (new string[] {"RaycastHitReceiver"});
	}
	
	// Update is called once per frame
	void Update ()
	{
#if UNITY_STANDALONE
		if (Input.GetKeyDown (KeyCode.Q)){
			this.ingamecontroller.ActivateAbility (0);
		} else if (Input.GetKeyDown (KeyCode.W)){
			this.ingamecontroller.ActivateAbility (1);
		} else if (Input.GetKeyDown (KeyCode.E)){
			this.ingamecontroller.ActivateAbility (2);
		} else if (Input.GetKeyDown (KeyCode.R)){
			this.ingamecontroller.ActivateAbility (3);
		}
#endif
	}

	public void ActivateAbility (int charNum){
		this.ingamecontroller.ActivateAbility (charNum);
	}


	public void RotateAirship (float degrees){
		this.ingamecontroller.RotateAirship (degrees);
	}


	public void UpdateAirshipSpeed (float newSpeed){
		this.ingamecontroller.UpdateAirshipSpeed (newSpeed);
	}


	public void SetAbilityPoint (BaseEventData b){
		RaycastHit hitInfo;
		Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
		Debug.DrawLine (r.origin, r.origin + r.direction * 100);
		if (Physics.Raycast (r, out hitInfo, 100.0f, layerMask)) {
			this.UseAbility (hitInfo.point);
		}
	}


	private void UseAbility (Vector3 target){
		this.ingamecontroller.UseAbility (target);
	}
}
