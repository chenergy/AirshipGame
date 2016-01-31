using UnityEngine;
using System.Collections;

public class Ability_StraightShot : A_Ability
{
	private GameObject projectilePrefab;

	public Ability_StraightShot (GameEnum.AbilityName abilityname, int manaCost, float cooldown, float maxRange, GameObject projectilePrefab, AudioClip clip, A_Airship owner) : base (abilityname, manaCost, cooldown, maxRange, clip, owner) {
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
		newProjectile.GetComponent<Projectile_Basic> ().SetOwner (this.owner);
		newProjectile.GetComponent <Projectile_Basic> ().SetDirection ((target - airshipPos).normalized);
		Debug.Log ("used straightshot");

		if (this.clip != null)
			GameManager.instance.InGameController.audio.PlayClipAtPoint (this.clip, this.owner.transform.position);
	}

	/*public override A_Ability Clone (A_Airship owner)
	{
		new Ability_StraightShot (this.manaCost, this.cooldown, this.maxRange, this.projectilePrefab, owner);
	}*/
}

