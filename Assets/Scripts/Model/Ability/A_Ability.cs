using UnityEngine;
using System.Collections;

public abstract class A_Ability
{
	protected GameEnum.AbilityName abilityName;
	public GameEnum.AbilityName AbilityName {
		get { return this.abilityName; }
	}

	protected int manaCost;
	public int ManaCost {
		get { return this.manaCost; }
	}

	protected float cooldown;
	public float Cooldown {
		get { return this.cooldown; }
	}

	protected float maxRange;
	public float MaxRange {
		get { return this.maxRange; }
	}

	protected A_Airship owner; 
	public A_Airship SkillType {
		get { return this.owner; }
	}


	protected A_Ability (GameEnum.AbilityName abilityName, int manaCost, float cooldown, float maxRange, A_Airship owner){
		this.abilityName = abilityName;
		this.manaCost = manaCost;
		this.cooldown = cooldown;
		this.maxRange = maxRange;
		this.owner = owner;
	}
		

	// Ability should be activated by party member touch.
	// Ingamecontroller contains reference to the partymenucharacter.
	// choose which function based on touch of canvas or click on screen
	// Setup ability with scriptable object, pass string to get ability class back from the scriptable object.
	public abstract void Activate ();
	public abstract void Use (Vector3 target);
	//public abstract A_Ability Clone (A_Airship owner);
}

