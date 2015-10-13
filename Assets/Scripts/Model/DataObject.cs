using UnityEngine;
using System;
using System.Collections;

[System.Serializable]
public class DataObject
{
	[System.Serializable]
	public class SavedCharacterData
	{
		public int exp = 0;
		public int curHp = 0;
		public int curMp = 0;

		public SavedCharacterData (SO_Characters.CharacterProperties property){
			this.curHp = property.baseHp;
			this.curMp = property.baseMp;
		}
	}

	public DateTime dateLastSaved;
	public int[] savedPartyMembers;
	public SavedCharacterData[] savedCharacterData;


	public DataObject (SO_Characters characterProperties){
		this.dateLastSaved = DateTime.Now;

		// Stored references to party members (in binary and serialized object data).
		this.savedPartyMembers = new int[] {1, 2, 3, 4};

		/*
		this.savedCharacterData = new SavedCharacterData[5];
		this.savedCharacterData [0] = new SavedCharacterData (GameManager.instance.characterProperties.characters[0]);
		this.savedCharacterData [1] = new SavedCharacterData (GameManager.instance.characterProperties.characters[1]);
		this.savedCharacterData [2] = new SavedCharacterData (GameManager.instance.characterProperties.characters[2]);
		this.savedCharacterData [3] = new SavedCharacterData (GameManager.instance.characterProperties.characters[3]);
		this.savedCharacterData [4] = new SavedCharacterData (GameManager.instance.characterProperties.characters[4]);
		*/
		// Save each character as new char in properties.
		int numChars = characterProperties.characters.Length;
		this.savedCharacterData = new SavedCharacterData[numChars];
		for (int i = 0; i < numChars; i++) {
			this.savedCharacterData [i] = new SavedCharacterData (characterProperties.characters[i]);
		}
	}

	/*public int savedPartyMember0 = 0;
	public int savedPartyMember1 = 0;
	public int savedPartyMember2 = 0;
	public int savedPartyMember3 = 0;*/
}

