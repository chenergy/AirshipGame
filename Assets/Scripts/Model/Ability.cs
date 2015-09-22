using UnityEngine;
using System.Collections;

public abstract class Ability
{
	protected Ability (){
	}

	// Ability should be activated by party member touch.
	// Ingamecontroller contains reference to the partymenucharacter.
	// partymenucharacter contains character class, contains ability
	// choose which function based on touch of canvas or click on screen
	// Setup ability with scriptable object, pass string to get ability class back from the scriptable object.
	public abstract void ActivateAbility ();
	public abstract void UseAbility ();
}

