using UnityEngine;
using System.Collections;

public class PartyCharacterBonus
{
    public int damageScalarBonus;
    public int damagePercentBonus;
    public int speedBonus;

    public void ClearBonuses()
    {
        this.damageScalarBonus = 0;
        this.damagePercentBonus = 0;
        this.speedBonus = 0;
    }
}
