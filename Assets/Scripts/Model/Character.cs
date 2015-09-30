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

	private int maxHp = 0;
	public int MaxHp {
		get { return this.maxHp; }
	}

	private int maxMp = 0;
	public int MaxMp {
		get { return this.maxMp; }
	}

	private int curHp = 0;
	public int CurHp {
		get { return this.curHp; }
	}

	private int curMp = 0;
	public int CurMp {
		get { return this.curMp; }
	}
	
	private float curCooldown = 1.0f;
	public float CurCooldown {
		get { return this.curCooldown; }
	}

	private float maxCooldown = 1.0f;
	public float MaxCooldown {
		get { return this.maxCooldown; }
	}

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
		if (this.ability != null) {
			if (this.CanUseAbility()){
				this.ability.Activate ();
			}
		}
	}


	public void UseAbility (Vector3 target){
		if (this.ability != null) {
			if (this.CanUseAbility()){
				this.curMp -= this.ability.ManaCost;
				this.ability.Use (target);
			}
		}
	}


	public bool CanUseAbility (){
		if ((this.curCooldown >= this.maxCooldown) && (this.curMp >= this.ability.ManaCost))
			return true;
		return false;
	}


	/*public int GetAbilityManaCost (){
		if (this.ability != null)
			return this.ability.ManaCost;
		return 0;
	}


	public float GetAbilityCooldown (){
		if (this.ability != null)
			return this.ability.Cooldown;
		return 0;
	}*/
}

