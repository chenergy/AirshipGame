using UnityEngine;
using System.Collections;

public class Ability_StraightShot : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_StraightShot (GameObject projectilePrefab, A_Airship owner) : base (5, 1.0f, 10.0f, owner) {
		this.projectilePrefab = projectilePrefab;
	}

	public override void Activate ()
	{
        //GameManager.instance.InGameController.EnableSkillTip(GameEnum.SkillTipType.SKILL_STRAIGHT, 10.0f);
		GameManager.instance.InGameController.EnableSkillTip( GameEnum.SkillTipType.SKILL_TARGET_AIRSHIP_AOE, 10.0f);
		Debug.Log ("activated straightshot");
	}

	public override void Use (Vector3 target)
	{
		//Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		Vector3 airshipPos = this.owner.transform.position;

		GameObject newProjectile = GameObject.Instantiate (this.projectilePrefab, airshipPos, Quaternion.identity) as GameObject;
		newProjectile.GetComponent<Projectile> ().SetOwner (this.owner);
		newProjectile.GetComponent <Projectile> ().SetDirection ((target - airshipPos).normalized);
		Debug.Log ("used straightshot");
	}

	public override A_Ability Clone (A_Airship owner)
	{
		return new Ability_StraightShot (this.projectilePrefab, owner);
	}
}

