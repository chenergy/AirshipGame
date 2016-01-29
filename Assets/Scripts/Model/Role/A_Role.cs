using UnityEngine;
using System.Collections;

public abstract class A_Role
{
    protected string name;
    protected int exp;
    protected A_Passive[] passives;


    protected A_Role(string name)
    {
        this.name = name;
    }


    public void AddPassiveEffects (PartyCharacter pchar)
    {
        foreach (A_Passive passive in this.passives)
        {
            passive.AddPassiveEffect(pchar);
        }
    }
}
