using UnityEngine;
using System.Collections;

public class SkillTip_Straight : A_SkillTip
{
	public override void Enable (float range)
	{
		this.skillTipGobj.SetActive (true);
		this.skillTipGobj.transform.localScale = new Vector3 (1.0f, 1.0f, range);
		StopCoroutine ("FollowPointer");
		StartCoroutine ("FollowPointer");
	}
	
	
	public override void Disable (){
		this.skillTipGobj.SetActive (false);
		StopCoroutine ("FollowPointer");
	}
	
	
	protected override IEnumerator FollowPointer (){
		while (true) {
			yield return new WaitForEndOfFrame ();
			#if UNITY_STANDALONE || UNITY_WEBGL
			RaycastHit hitInfo;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			Debug.DrawLine (r.origin, r.origin + r.direction * 100);
			if (Physics.Raycast (r, out hitInfo, 100.0f, layerMask)) {
				this.skillTipGobj.transform.LookAt (hitInfo.point);
				this.skillTipGobj.transform.rotation = Quaternion.Euler (0, this.skillTipGobj.transform.eulerAngles.y, 0);
				this.skillTipGobj.transform.position = GameManager.instance.InGameController.Airship.transform.position;
			}
			#endif
		}
	}
}

