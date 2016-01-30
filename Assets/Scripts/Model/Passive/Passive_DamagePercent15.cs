using UnityEngine;
using System.Collections;
using System;

public class Passive_DamagePercent15 : A_Passive
{
    public Passive_DamagePercent15 (int unlockExp) : base ("Damage +15%", unlockExp)
    {

    }

    public override void AddPassiveEffect(PartyCharacter pchar)
    {
        pchar.Bonus.damagePercentBonus += 15;
    }
}
