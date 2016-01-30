using UnityEngine;
using System.Collections;

[System.Serializable]
public class CharacterSerialized {
	public GameEnum.CharacterName charName;
	public string name;
	public string desc;
	public int baseHp;
	public int baseMp;
    public GameEnum.AbilityName ability;
    public GameEnum.RoleName curRole;

    // Do not set.
    public int curHp;
    public int curMp;
    public int[] roleExp;


    public CharacterSerialized (GameEnum.CharacterName charName, string name, string desc, int baseHp, int baseMp, GameEnum.AbilityName ability, GameEnum.RoleName role){
		this.charName = charName;
		this.name = name;
		this.desc = desc;
		this.baseHp = baseHp;
		this.baseMp = baseMp;
        this.ability = ability;
        this.curRole = role;
        
        this.curHp = baseHp;
        this.curMp = baseMp;

        // Initialize exp for each role to 0;
        this.roleExp = new int[2];
        for (int i = 0; i < 2; i++)
        {
            this.roleExp[i] = 0;
        }
	}


    public CharacterSerialized Clone (){
		return new CharacterSerialized (this.charName, this.name, this.desc, this.baseHp, this.baseMp, this.ability, this.curRole);
	}
}

