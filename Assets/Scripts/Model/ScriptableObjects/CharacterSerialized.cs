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

    // Do not set.
    public int exp;
	public int curHp;
    public int curMp;


    public CharacterSerialized (GameEnum.CharacterName charName, string name, string desc, int baseHp, int baseMp, GameEnum.AbilityName ability){
		this.charName = charName;
		this.name = name;
		this.desc = desc;
		this.baseHp = baseHp;
		this.baseMp = baseMp;
        this.ability = ability;
        this.exp = 0;
        this.curHp = baseHp;
        this.curMp = baseMp;
	}


    public CharacterSerialized Clone (){
		return new CharacterSerialized (this.charName, this.name, this.desc, this.baseHp, this.baseMp, this.ability);
	}
}

