using UnityEngine;
using System.Collections;

public class Ability_TargetAOE : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_TargetAOE (GameObject projectilePrefab) : base (5, 2.0f, 5.0f) {
		this.projectilePrefab = projectilePrefab;
	}

	public override void Activate ()
	{
        //GameManager.instance.InGameController.EnableSkillTip(GameEnum.SkillTipType.SKILL_TARGET_POINTER_AOE, 5.0f);
		GameManager.instance.InGameController.EnableSkillTip( GameEnum.SkillTipType.SKILL_TARGET_AIRSHIP_AOE, 10.0f);
        Debug.Log ("activated targetAOE");
	}

	public override void Use (Vector3 target)
	{
		Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		GameObject newProjectile = GameObject.Instantiate (this.projectilePrefab, target, Quaternion.identity) as GameObject;
		//newProjectile.GetComponent <Projectile> ().SetDirection (Vector3.zero);
		Debug.Log ("used targetAOE");
	}

	public override A_Ability Clone ()
	{
		return new Ability_TargetAOE (this.projectilePrefab);
	}
}

