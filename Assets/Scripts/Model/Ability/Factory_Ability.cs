using UnityEngine;
using System.Collections;

public class Factory_Ability
{
	private SO_Abilities abilityScriptables;


	public Factory_Ability (SO_Abilities abilityScriptables){
		this.abilityScriptables = abilityScriptables;
	}

	/*
	this.abilitiesDict.Add(GameEnum.AbilityName.ABILITY_STRAIGHTBULLET, new Ability_StraightShot(this.abilityScriptables.straightShot.projectilePrefab, null));
	this.abilitiesDict.Add(GameEnum.AbilityName.ABILITY_TARGETAOE, new Ability_TargetAOE(this.abilityScriptables.targetAOE.projectilePrefab, null));
	this.abilitiesDict.Add(GameEnum.AbilityName.ABILITY_AUTOBULLET, new Ability_AutoBullet(this.abilityScriptables.autoBullet.projectilePrefab, null));
	this.abilitiesDict.Add(GameEnum.AbilityName.ABILITY_FRONTSWIPE, new Ability_FrontSwipe(this.abilityScriptables.frontSwipe.swipePrefab, null));
	this.abilitiesDict.Add(GameEnum.AbilityName.ABILITY_HOMINGMISSILE, new Ability_HomingMissile(this.abilityScriptables.homingMissile.projectilePrefab, null));
	this.abilitiesDict.Add(GameEnum.AbilityName.ABILITY_BLINKFORWARD, new Ability_BlinkForward(null));
	*/

	public A_Ability CloneAbility (GameEnum.AbilityName abilityName, A_Airship owner) {
		int abilityInt = (int)abilityName;
		if (abilityInt < this.abilityScriptables.abilities.Length) {
			SO_Abilities.AbilityProperties ability = this.abilityScriptables.abilities [abilityInt];

			switch (abilityName) {
			case GameEnum.AbilityName.NONE:
				break;
			case GameEnum.AbilityName.ABILITY_STRAIGHTBULLET:
				return new Ability_StraightShot (ability.abilityName, ability.manaCost, ability.cooldown, ability.maxRange, ability.projectilePrefab, ability.clip, owner);
				break;
			case GameEnum.AbilityName.ABILITY_TARGETAOE:
				return new Ability_TargetAOE (ability.abilityName, ability.manaCost, ability.cooldown, ability.maxRange, ability.projectilePrefab, ability.clip, owner);
				break;
			case GameEnum.AbilityName.ABILITY_AUTOBULLET:
				return new Ability_AutoBullet (ability.abilityName, ability.manaCost, ability.cooldown, ability.maxRange, ability.projectilePrefab, ability.clip, owner);
				break;
			case GameEnum.AbilityName.ABILITY_FRONTSWIPE:
				return new Ability_FrontSwipe (ability.abilityName, ability.manaCost, ability.cooldown, ability.maxRange, ability.projectilePrefab, ability.clip, owner);
				break;
			case GameEnum.AbilityName.ABILITY_HOMINGMISSILE:
				return new Ability_HomingMissile (ability.abilityName, ability.manaCost, ability.cooldown, ability.maxRange, ability.projectilePrefab, ability.clip, owner);
				break;
			case GameEnum.AbilityName.ABILITY_BLINKFORWARD:
				return new Ability_BlinkForward (ability.abilityName, ability.manaCost, ability.cooldown, ability.maxRange, ability.projectilePrefab, ability.clip, owner);
				break;
			default:
				break;
			}
		}

		return null;
	}
}

