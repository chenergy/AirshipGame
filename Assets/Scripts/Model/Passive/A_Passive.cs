using UnityEngine;
using System.Collections;

public abstract class A_Passive
{
    protected string name;
    protected int unlockExp;

    protected A_Passive (string name, int unlockExp)
    {
        this.name = name;
        this.unlockExp = unlockExp;
    }

    public abstract void AddPassiveEffect(PartyCharacter pchar);
}
