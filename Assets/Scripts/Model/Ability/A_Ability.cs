using UnityEngine;
using System.Collections;

public abstract class A_Ability
{
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


	protected A_Ability (int manaCost, float cooldown){
		this.manaCost = manaCost;
		this.cooldown = cooldown;
	}
		

	// Ability should be activated by party member touch.
	// Ingamecontroller contains reference to the partymenucharacter.
	// partymenucharacter contains character class, contains ability
	// choose which function based on touch of canvas or click on screen
	// Setup ability with scriptable object, pass string to get ability class back from the scriptable object.
	public abstract void Activate ();
	public abstract void Use (Vector3 target);
	public abstract A_Ability Clone ();
}

