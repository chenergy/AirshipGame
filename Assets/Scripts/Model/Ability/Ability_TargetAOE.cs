using UnityEngine;
using System.Collections;

public class Ability_TargetAOE : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_TargetAOE (GameEnum.AbilityName abilityname, int manaCost, float cooldown, float maxRange, GameObject projectilePrefab, AudioClip clip, A_Airship owner) : base (abilityname, manaCost, cooldown, maxRange, clip, owner) {
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
		//Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		Vector3 airshipPos = this.owner.transform.position;

		GameObject newProjectile = GameObject.Instantiate (this.projectilePrefab, target, Quaternion.identity) as GameObject;
		newProjectile.GetComponent<Projectile_Basic> ().SetOwner (this.owner);
		//newProjectile.GetComponent <Projectile> ().SetDirection (Vector3.zero);
		Debug.Log ("used targetAOE");

		if (this.clip != null)
			GameManager.instance.InGameController.audio.PlayClipAtPoint (this.clip, this.owner.transform.position);
	}

	/*public override A_Ability Clone (A_Airship owner)
	{
		return new Ability_TargetAOE (this.projectilePrefab, owner);
	}*/
}

