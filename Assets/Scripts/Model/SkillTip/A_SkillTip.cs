using UnityEngine;
using System.Collections;

public abstract class A_SkillTip : MonoBehaviour
{
	public GameObject skillTipGobj;

	protected int layerMask;
	
	void Start (){
		layerMask = LayerMask.GetMask (new string[] {"RaycastHitReceiver"});
	}

	public abstract void Enable (float range);
	public abstract void Disable ();
	protected abstract IEnumerator FollowPointer ();
}

