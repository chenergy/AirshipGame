using UnityEngine;
using System.Collections;

public abstract class A_Projectile : MonoBehaviour
{
	protected A_Airship owner;
	public A_Airship Owner {
		get { return this.owner; }
	}

	public void SetOwner (A_Airship owner){
		this.owner = owner;
	}
}

