using UnityEngine;
using System.Collections;

public class SkillTip_Sphere : A_SkillTip
{
	private int layerMask;

	void Start (){
		layerMask = LayerMask.GetMask (new string[] {"RaycastHitReceiver"});
	}

	public override void Enable (float range)
	{
		this.skillTipGobj.SetActive (true);
		this.skillTipGobj.transform.localScale = Vector3.one * range;
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
#if UNITY_STANDALONE
			RaycastHit hitInfo;
			Ray r = Camera.main.ScreenPointToRay (Input.mousePosition);
			Debug.DrawLine (r.origin, r.origin + r.direction * 100);
			if (Physics.Raycast (r, out hitInfo, 100.0f, layerMask)) {
				//Debug.Log ("hit");
				this.skillTipGobj.transform.position = hitInfo.point;
			}
#endif
		}
	}
}

