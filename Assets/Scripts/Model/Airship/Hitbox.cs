using UnityEngine;
using System.Collections;

public class Hitbox : MonoBehaviour
{
	public A_Airship owner;
	public int position;

	public void TakeDamage (int damage){
		this.owner.TakeDamage (this.position, damage);
	}
}

