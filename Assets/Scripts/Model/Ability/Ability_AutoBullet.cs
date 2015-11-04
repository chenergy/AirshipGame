﻿using UnityEngine;
using System.Collections;

public class Ability_AutoBullet : A_Ability
{
    private GameObject projectilePrefab;

	public Ability_AutoBullet(int manaCost, float cooldown, float maxRange, GameObject projectilePrefab, A_Airship owner) : base (manaCost, cooldown, maxRange, owner) {
        this.projectilePrefab = projectilePrefab;
    }

    public override void Activate()
    {
        GameManager.instance.InGameController.UseAbility(Vector3.zero);
        Debug.Log("activated AUTO_BULLET");
    }

    public override void Use(Vector3 target)
    {
        //Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
        //Vector3 airshipForward = GameManager.instance.InGameController.airship.transform.forward;
		Vector3 airshipPos = this.owner.transform.position;
		Vector3 airshipForward = this.owner.transform.forward;

        GameObject newProjectile = GameObject.Instantiate(this.projectilePrefab, airshipPos, Quaternion.identity) as GameObject;
		newProjectile.GetComponent<Projectile_Basic> ().SetOwner (this.owner);
        newProjectile.GetComponent<Projectile_Basic>().SetDirection(airshipForward);
        Debug.Log("used AUTO_BULLET");
    }

	/*public override A_Ability Clone(A_Airship owner)
	{
        return new Ability_AutoBullet(this.projectilePrefab, owner);
    }*/
}
