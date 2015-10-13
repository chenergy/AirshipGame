using UnityEngine;
using System.Collections;

public class Ability_FrontSwipe : A_Ability
{
    private GameObject swipePrefab;

    public Ability_FrontSwipe(GameObject projectilePrefab) : base(5, 1.0f, 10.0f)
    {
        this.swipePrefab = projectilePrefab;
    }

    public override void Activate()
    {
        GameManager.instance.InGameController.UseAbility(Vector3.zero);
        Debug.Log("activated front Swipe");
    }

    public override void Use(Vector3 target)
    {
        Vector3 airshipPos = GameManager.instance.InGameController.airship.transform.position;
        //Vector3 airshipForward = GameManager.instance.InGameController.airship.transform.forward;

        GameObject newSwipe = GameObject.Instantiate(this.swipePrefab, airshipPos, Quaternion.identity) as GameObject;
        newSwipe.transform.parent = GameManager.instance.InGameController.airship.transform;
        newSwipe.transform.localRotation = Quaternion.identity;
        newSwipe.transform.localPosition += new Vector3(0, 0, 2);
        newSwipe.GetComponent<SwipeProjectile>().SetAngle(90.0f);
        //newSwipe.GetComponent<Projectile>().SetDirection(airshipForward);
        Debug.Log("used front swipe");
    }

    public override A_Ability Clone()
    {
        return new Ability_FrontSwipe(this.swipePrefab);
    }
}
