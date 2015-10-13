﻿using UnityEngine;
using System.Collections;

public class Ability_AutoBullet : A_Ability
{
    private GameObject projectilePrefab;

    public Ability_AutoBullet(GameObject projectilePrefab) : base (1, 0.1f, 10.0f/*, GameEnum.SkillTipType.SKILL_STRAIGHT*/) {
        this.projectilePrefab = projectilePrefab;
    }

    public override void Activate()
    {
        GameManager.instance.InGameController.UseAbility(Vector3.zero);
        Debug.Log("activated AUTO_BULLET");
    }

    public override void Use(Vector3 target)
    {
        Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
        Vector3 airshipForward = GameManager.instance.InGameController.airship.transform.forward;

        GameObject newProjectile = GameObject.Instantiate(this.projectilePrefab, airshipPos, Quaternion.identity) as GameObject;
        newProjectile.GetComponent<Projectile>().SetDirection(airshipForward);
        Debug.Log("used AUTO_BULLET");
    }

    public override A_Ability Clone()
    {
        return new Ability_AutoBullet(this.projectilePrefab);
    }
}