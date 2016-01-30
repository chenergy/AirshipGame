using UnityEngine;
using System.Collections;

public class Role_Swordsman : A_Role
{
    public Role_Swordsman () : base("Swordsman")
    {
        this.passives = new A_Passive[]
        {
            new Passive_DamagePercent15 (10)
        };
    } 
}
