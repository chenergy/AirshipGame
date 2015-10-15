using UnityEngine;
using System.Collections;

[System.Serializable]
public class SO_Characters : ScriptableObject {
	[System.Serializable]
	public class CharacterProperties {
		public Sprite icon;
		public string name;
		public int baseHp;
		public int baseMp;
	}

	public CharacterProperties[] characters;
}
