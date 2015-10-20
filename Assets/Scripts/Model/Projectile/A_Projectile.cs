using UnityEngine;
using System.Collections;

public abstract class A_Projectile : MonoBehaviour
{
	protected A_Airship owner;

	public void SetOwner (A_Airship owner){
		this.owner = owner;
	}
}

