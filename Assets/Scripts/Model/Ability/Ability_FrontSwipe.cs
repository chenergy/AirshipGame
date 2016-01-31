using UnityEngine;
using System.Collections;

public class Ability_FrontSwipe : A_Ability
{
    private GameObject swipePrefab;

	public Ability_FrontSwipe(GameEnum.AbilityName abilityname, int manaCost, float cooldown, float maxRange, GameObject projectilePrefab, AudioClip clip, A_Airship owner) : base (abilityname, manaCost, cooldown, maxRange, clip, owner) {
        this.swipePrefab = projectilePrefab;
    }

    public override void Activate()
    {
        GameManager.instance.InGameController.UseAbility(Vector3.zero);
        Debug.Log("activated front Swipe");
    }

    public override void Use(Vector3 target)
    {
        //Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
		Vector3 airshipPos = this.owner.transform.position;
        //Vector3 airshipForward = GameManager.instance.InGameController.airship.transform.forward;

        GameObject newSwipe = GameObject.Instantiate(this.swipePrefab, airshipPos, Quaternion.identity) as GameObject;
        newSwipe.transform.parent = GameManager.instance.InGameController.Airship.transform;
        newSwipe.transform.localRotation = Quaternion.identity;
        //newSwipe.transform.localPosition += new Vector3(0, 0, 0);
		newSwipe.GetComponent<Projectile_Swipe> ().SetOwner (this.owner);
        newSwipe.GetComponent<Projectile_Swipe>().SetAngle(360.0f);
        //newSwipe.GetComponent<Projectile>().SetDirection(airshipForward);
        Debug.Log("used front swipe");

		if (this.clip != null)
			GameManager.instance.InGameController.audio.PlayClipAtPoint (this.clip, this.owner.transform.position);
    }

	/*public override A_Ability Clone(A_Airship owner)
    {
        return new Ability_FrontSwipe(this.swipePrefab, owner);
    }*/
}
