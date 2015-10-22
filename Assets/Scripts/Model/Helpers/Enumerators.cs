using UnityEngine;
using System.Collections;

namespace GameEnum
{
	public enum CharacterName {
		EMPTY = 0,
		MAIN_BOB,
		MAIN_LILY,
		MAIN_SAM,
		MAIN_TIM,
		CLASS_WARRIOR,
		CLASS_GUNNER,
		CLASS_MAGE,
		CLASS_HEALER
	};

	public enum AirshipName {
		KOALA = 0,
		RACCOON,
		PLATYPUS
	};

	public enum AbilityName {
		NONE,
		ABILITY_STRAIGHTBULLET,
		ABILITY_TARGETAOE,
        ABILITY_AUTOBULLET,
        ABILITY_FRONTSWIPE
	};

	public enum SkillTipType {
		NONE,
		SKILL_STRAIGHT,
		SKILL_TARGET_POINTER_AOE,
		SKILL_TARGET_AIRSHIP_AOE
	};

	public enum DisplayType {
		BAR = 0, CIRCLE = 1
	};

	public enum SteeringType {
		REALISTIC,
		UNREALISTIC
	};
}

