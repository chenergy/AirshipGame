using UnityEngine;
using System.Collections;

public abstract class A_Ability
{
	protected int manaCost;
	protected float cooldown;

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
	public abstract void Use ();


	protected void TurnOnRangeIndicator (){
	}
}

