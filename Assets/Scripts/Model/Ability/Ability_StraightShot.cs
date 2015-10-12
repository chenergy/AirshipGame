using UnityEngine;
using System.Collections;

public class Ability_StraightShot : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_StraightShot (GameObject projectilePrefab) : base (5, 1.0f, 10.0f/*, GameEnum.SkillTipType.SKILL_STRAIGHT*/) {
		this.projectilePrefab = projectilePrefab;
	}

	public override void Activate ()
	{
        GameManager.instance.InGameController.EnableSkillTip(GameEnum.SkillTipType.SKILL_STRAIGHT, 10.0f);
		Debug.Log ("activated straightshot");
	}

	public override void Use (Vector3 target)
	{
		Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		GameObject newProjectile = GameObject.Instantiate (this.projectilePrefab, airshipPos, Quaternion.identity) as GameObject;
		newProjectile.GetComponent <Projectile> ().SetDirection ((target - airshipPos).normalized);
		Debug.Log ("used straightshot");
	}

	public override A_Ability Clone ()
	{
		return new Ability_StraightShot (this.projectilePrefab);
	}
}

