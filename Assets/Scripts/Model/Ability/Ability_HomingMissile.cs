using UnityEngine;
using System.Collections;

public class Ability_HomingMissile : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_HomingMissile (int manaCost, float cooldown, float maxRange, GameObject projectilePrefab, A_Airship owner) : base (manaCost, cooldown, maxRange, owner) {
		this.projectilePrefab = projectilePrefab;
	}

	public override void Activate()
	{
		GameManager.instance.InGameController.UseAbility(Vector3.zero);
		Debug.Log("activated HOMING_MISSILE");
	}

	public override void Use(Vector3 target)
	{
		//Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		//Vector3 airshipForward = GameManager.instance.InGameController.airship.transform.forward;
		Vector3 airshipPos = this.owner.transform.position;
		Vector3 airshipForward = this.owner.transform.forward;

		GameObject newProjectile = GameObject.Instantiate(this.projectilePrefab, airshipPos, Quaternion.identity) as GameObject;
		newProjectile.GetComponent<Projectile_Homing> ().SetOwner (this.owner);
		newProjectile.GetComponent<Projectile_Homing> ().SetDirection(airshipForward);
		Debug.Log("used HOMING_MISSILE");
	}

	/*public override A_Ability Clone(A_Airship owner)
	{
		return new Ability_HomingMissile(this.projectilePrefab, owner);
	}*/
}
