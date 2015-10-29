using UnityEngine;
using System.Collections;

public class Projectile_Kamikaze : A_Projectile
{
    public A_Airship parent;
    public int damage;

    void OnTriggerEnter(Collider other)
    {
        Hitbox hb = other.GetComponent<Hitbox>();
        if (hb != null)
        {
            if (hb.owner != this.parent)
            {
                hb.TakeDamage(this.damage);
                GameObject.Destroy(this.parent.gameObject);
            }
        }
    }
}
