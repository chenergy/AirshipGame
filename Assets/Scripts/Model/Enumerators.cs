using UnityEngine;
using System.Collections;

namespace GameEnum
{
	public enum CharacterName {
		EMPTY,
		CHARACTER_TEST
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
		SKILL_TARGETAOE
	};

	public enum DisplayType {
		BAR = 0, CIRCLE = 1
	};

	public enum SteeringType {
		REALISTIC,
		UNREALISTIC
	};
}
