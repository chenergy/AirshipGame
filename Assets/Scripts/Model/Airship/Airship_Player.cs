using UnityEngine;
using System.Collections;
using System;

public class Airship_Player : A_Airship
{
	public Heading heading;

	protected override void Update ()
	{
		base.Update ();

		this.heading.transform.LookAt(this.transform.position + this.headingDirection);
	}

	public override void TakeDamage (int position, int damage)
	{
		//throw new System.NotImplementedException ();
		GameManager.instance.InGameController.CharacterTakeDamage (position, damage);
		//Debug.Log ("took damage: " + damage.ToString ());
	}

    public void StartRotate (){
		this.heading.TurnOn ();
	}
	
	public void EndRotate (){
		this.heading.TurnOff ();
	}
}

