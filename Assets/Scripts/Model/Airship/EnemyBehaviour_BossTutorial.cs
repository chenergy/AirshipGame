using UnityEngine;
using System.Collections;

public class EnemyBehaviour_BossTutorial : A_EnemyBehaviour
{
	// Overall moveset
	// At first, boss is static, does not move to attack player, has some close range attacks.
	// Second half, boss can fly/move towards player.
	protected override IEnumerator LateStart (){
		yield return new WaitForEndOfFrame ();
		// State 1: 50 < hp < 100: Boss is on the ground.
			// Close range 1A: Targeted aoe arc the ground, short area. Hits lower then higher level.
			// Long range 1A: Non-targeted bullets in all directions. Lower level.
			// Long range 2A: Straight targeted "ray" attack, shows tooltip on the ground. Lower Level.
		// State 2: 0 < hp < 50: Boss starts to fly, will approach player sometimes.
			// Increase speed 0.25
			// Close range 1B: Will move toward player. Target wider aoe arc. Hits lower then higher level.
			// Long range 1B: Non-targeted bullets in all directions. Spherical, lower and higher level.
			// Long range 2B: Straight targeted "ray" attack, wider. Higher level.
			// Long range 3: Moves quickly to the player's current location. Higher level.
	}

	protected override void UpdateBehaviour ()
	{
		if (fsm != null) {
			// Check current state.
			switch (fsm.CurrentState.Name) {

			default:
				break;
			}

			fsm.Update ();
		}
	}
}

