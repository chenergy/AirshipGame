﻿using UnityEngine;
using System.Collections;

public class Ability_BlinkForward : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_BlinkForward (GameEnum.AbilityName abilityname, int manaCost, float cooldown, float maxRange, GameObject projectilePrefab, AudioClip clip, A_Airship owner) : base (abilityname, manaCost, cooldown, maxRange, clip, owner) {
		this.projectilePrefab = projectilePrefab;
	}

	public override void Activate()
	{
		GameManager.instance.InGameController.UseAbility(Vector3.zero);
		Debug.Log("activated BLINK_FORWARD");
	}

	public override void Use(Vector3 target)
	{
		//Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		//Vector3 airshipForward = GameManager.instance.InGameController.airship.transform.forward;
		Vector3 airshipPos = this.owner.transform.position;
		Vector3 airshipForward = this.owner.transform.forward;

		//this.owner.transform.position += this.owner.transform.forward.normalized * 5.0f;
		this.owner.cc.Move (this.owner.transform.forward.normalized * this.maxRange);
		Debug.Log("used BLINK_FORWARD");

		if (this.clip != null)
			GameManager.instance.InGameController.audio.PlayClipAtPoint (this.clip, this.owner.transform.position);
		/*GameObject newProjectile = GameObject.Instantiate(this.projectilePrefab, airshipPos, Quaternion.identity) as GameObject;
		newProjectile.GetComponent<Projectile_Homing> ().SetOwner (this.owner);
		newProjectile.GetComponent<Projectile_Homing> ().SetDirection(airshipForward);
		Debug.Log("used HOMING_MISSILE");*/
	}

	/*public override A_Ability Clone(A_Airship owner)
	{
		return new Ability_BlinkForward(owner);
	}*/
}
