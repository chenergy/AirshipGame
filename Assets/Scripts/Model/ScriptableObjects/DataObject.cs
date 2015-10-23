using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class DataObject
{
	/*[System.Serializable]
	public class SavedCharacterData
	{
		public int exp = 0;
		public int curHp = 0;
		public int curMp = 0;

		public SavedCharacterData (int baseHp, int baseMp){
			this.curHp = baseHp;
			this.curMp = baseMp;
		}
	}

	[System.Serializable]
	public class SavedAirshipData
	{
		public GameEnum.AirshipName airshipName;
		public SavedCharacterData[] savedCharacterData;

		public SavedAirshipData (GameEnum.AirshipName airshipName, SavedCharacterData[] savedCharacterData){
			this.airshipName = airshipName;
			this.savedCharacterData = savedCharacterData;
		}
	}*/

	public DateTime dateLastSaved;

	// List of characters that I have in inventory.
	// List of airships.
	// Current airship
	// Current crew on airships, positions on airship

	//public SavedAirshipData currentAirship;
	//public List<GameEnum.AirshipName> unlockedAirships;

	//public int[] savedPartyMembers;
	//public SavedCharacterData[] savedCharacterData;

	public AirshipSerialized[] airships;
	public GameEnum.AirshipName currentAirship;
	public List<CharacterSerialized> characterInventory;
	public int[] charactersInAirship;


	public DataObject (SO_Characters.CharacterScriptable[] characterScriptables, SO_Airships.AirshipScriptable[] airshipScriptables){
		this.dateLastSaved = DateTime.Now;

        // Populate character inventory with 2 characters.
		this.characterInventory = new List<CharacterSerialized> ();
        //CharacterSerializable bob = new CharacterSerializable(GameEnum.CharacterName.MAIN_BOB, "Bob", "Some guy.", 10, 10);
        this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.MAIN_BOB].characterData.Clone ());
		this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.MAIN_LILY].characterData.Clone ());

        // Set current airship at 0.
		this.currentAirship = GameEnum.AirshipName.KOALA;

        // Save all airship data to binary.
        this.airships = new AirshipSerialized[airshipScriptables.Length];
        for (int i = 0; i < this.airships.Length; i++)
        {
            this.airships[i] = airshipScriptables[i].airshipData.Clone();
        }
        // Unlock the first airship.
        this.airships [(int)GameEnum.AirshipName.KOALA].isLocked = false;

        // Save characters from 0 and 1 (mapped to the # in characterScriptables) into characterInventory.
		int airshipSlots = this.airships [(int)this.currentAirship].slots.Length;
		this.charactersInAirship = new int[airshipSlots];
		this.charactersInAirship [0] = 0;
		this.charactersInAirship [1] = 1;


		/*
		// Stored references to party members (in binary and serialized object data).
		this.savedPartyMembers = new int[] {1, 2, 3, 4};

		// Save each character as new char in properties.
		int numChars = characterProperties.characters.Length;
		this.savedCharacterData = new SavedCharacterData[numChars];
		for (int i = 0; i < numChars; i++) {
			this.savedCharacterData [i] = new SavedCharacterData (characterProperties.characters[i].baseHp, characterProperties.characters[i].baseMp);
		}
		*/

		/*
		this.savedCharacterData = new SavedCharacterData[5];
		this.savedCharacterData [0] = new SavedCharacterData (GameManager.instance.characterProperties.characters[0]);
		this.savedCharacterData [1] = new SavedCharacterData (GameManager.instance.characterProperties.characters[1]);
		this.savedCharacterData [2] = new SavedCharacterData (GameManager.instance.characterProperties.characters[2]);
		this.savedCharacterData [3] = new SavedCharacterData (GameManager.instance.characterProperties.characters[3]);
		this.savedCharacterData [4] = new SavedCharacterData (GameManager.instance.characterProperties.characters[4]);
		*/

	}
}

