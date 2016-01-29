using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PartyCharacter
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

    private int exp = 0;
    public int Exp
    {
        get { return this.exp; }
    }

    private GameEnum.RoleName role;
    public GameEnum.RoleName Role
    {
        get { return this.role; }
    }

    private float curCooldown = 1.0f;
	public float CurCooldown {
		get { return this.curCooldown; }
		//set { this.curCooldown = value; }
	}

	private float maxCooldown = 1.0f;
	public float MaxCooldown {
		get { return this.maxCooldown; }
	}

	private A_Ability ability = null;
	public A_Ability Ability {
		get { return this.ability; }
	}

    private PartyCharacterBonus bonus;
    public PartyCharacterBonus Bonus
    {
        get { return this.bonus; }
    }


	public PartyCharacter (int inventoryNum) {
        this.icon = GameManager.instance.Data.GetInventoryCharacterSpriteIcon(inventoryNum);
        this.name = GameManager.instance.Data.GetInventoryCharacterStringName(inventoryNum);
        this.maxHp = GameManager.instance.Data.GetInventoryCharacterBaseHp(inventoryNum);
        this.maxMp = GameManager.instance.Data.GetInventoryCharacterBaseMp(inventoryNum);
        this.curHp = GameManager.instance.Data.GetInventoryCharacterCurHp(inventoryNum);
        this.curMp = GameManager.instance.Data.GetInventoryCharacterCurMp(inventoryNum);
        this.role = GameManager.instance.Data.GetInventoryCharacterCurRole(inventoryNum);
        this.exp = GameManager.instance.Data.GetInventoryCharacterCurRoleExp(inventoryNum);
    }


	public void SetAbility (A_Ability ability){
		this.ability = ability;
	}


	public void ActivateAbility () {
		if (this.ability != null) {
			this.ability.Activate ();
		}
	}


	public void UseAbility (Vector3 target){
		if (this.ability != null) {
			this.curMp -= this.ability.ManaCost;
			this.ability.Use (target);
			this.curCooldown = 0.0f;
			this.maxCooldown = this.ability.Cooldown;
		}
	}

	// Check multiple conditions to see if ability is allowed to be used.
	public bool CanUseAbility (){
		if (this.ability != null) {
			if ((this.curCooldown >= this.maxCooldown) && 
				(this.curMp >= this.ability.ManaCost) && 
				(this.curHp > 0))
				return true;

			if (this.curCooldown < this.maxCooldown)
				GameManager.instance.InGameController.errorLog.LogErrorText ("Still on cooldown.");
			
			if (this.curMp < this.ability.ManaCost)
				GameManager.instance.InGameController.errorLog.LogErrorText ("Not enough mana.");

			if (this.curHp <= 0)
				GameManager.instance.InGameController.errorLog.LogErrorText (string.Format("{0} is dead", this.Name));
		}

		return false;
	}


	public void TakeDamage (int damage){
		this.curHp -= damage;

		if (this.curHp < 0)
			this.curHp = 0;
	}


	public void RechargeHp (int hp){
		this.curHp += hp;

		if (this.curHp > this.maxHp)
			this.curHp = this.maxHp;
	}


	public void RechargeMp (int mp) {
		this.curMp += mp;

		if (this.curMp > this.maxMp)
			this.curMp = this.maxMp;
	}


	public void RechargeCooldown (float cooldown){
		this.curCooldown += cooldown;

		if (this.curCooldown > this.maxCooldown)
			this.curCooldown = this.maxCooldown;
	}
}

