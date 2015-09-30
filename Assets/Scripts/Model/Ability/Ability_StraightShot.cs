using UnityEngine;
using System.Collections;

public class Ability_StraightShot : A_Ability
{
	public Ability_StraightShot (int manaCost, float cooldown) : base (manaCost, cooldown) {
	}

	public override void Activate ()
	{
		Debug.Log ("activated straightshot");
	}

	public override void Use (Vector3 target)
	{
		Debug.Log ("used straightshot");
	}
}

