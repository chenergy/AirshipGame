using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Character
{
	private Sprite icon;
	public Sprite Icon {
		get { return this.icon; }
	}

	private string name;
	public string Name {
		get { return this.name; }
	}

	public int maxHp = 0;
	public int maxMp = 0;
	public int curHp = 0;
	public int curMp = 0;

	private A_Ability ability = null;


	public Character (Sprite icon, string name, int maxHp, int maxMp, int curHp, int curMp) {
		this.name = name;
		this.icon = icon;
		this.maxHp = maxHp;
		this.maxMp = maxMp;
		this.curHp = curHp;
		this.curMp = curMp;
	}


	public void SetAbility (A_Ability ability){
		this.ability = ability;
	}


	public void ActivateAbility () {
		if (this.ability != null)
			this.ability.Activate ();
	}


	public void UseAbility (){
		if (this.ability != null)
			this.ability.Use ();
	}
}

