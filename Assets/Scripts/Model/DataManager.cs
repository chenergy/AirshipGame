using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[System.Serializable]
public enum DisplayType {
	BAR = 0, CIRCLE = 1
};

public class DataManager
{
	// Assigned properties for character display.
	private SO_Characters characterProperties;

	// Assigne properties for abilities.
	private SO_Abilities abilityProperties;

	// Dictionary for accessing associated ability functionality.
	private Dictionary <GameEnum.AbilityName, A_Ability> abilitiesDict = new Dictionary<GameEnum.AbilityName, A_Ability> ();

	// Loaded data object that is serialized and deserialized.
	private DataObject dataObject;

	public DataManager (SO_Characters characterProperties, SO_Abilities abilityProperties){
		// Forces a different code path in the BinaryFormatter that doesn't rely on run-time code generation (which would break on iOS).
		//http://answers.unity3d.com/questions/30930/why-did-my-binaryserialzer-stop-working.html
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		
		#if UNITY_IOS
		// Temp wipe data.
		//System.IO.File.Delete("/private" + Application.persistentDataPath + "/savedData.gd");
		#endif

		//Debug.Log (Application.persistentDataPath);

		// Set scriptable object properties.
		this.characterProperties = characterProperties;
		this.abilityProperties = abilityProperties;

		this.abilitiesDict = new Dictionary<GameEnum.AbilityName, A_Ability> ();
		this.abilitiesDict.Add (GameEnum.AbilityName.ABILITY_STRAIGHTBULLET, new Ability_StraightShot (this.abilityProperties.straightShot.projectilePrefab));

		this.dataObject = new DataObject (this.characterProperties);

		// Deserialize data from binary.
		this.Load ();
	}


	public A_Ability GetAbility (GameEnum.AbilityName abilityName){
		if (this.abilitiesDict.ContainsKey (abilityName))
			return this.abilitiesDict [abilityName].Clone ();
		return null;
	}


	/*public void SetAbility (GameEnum.AbilityName abilityName, A_Ability ability){
		this.abilitiesDict.Add (abilityName, ability);
	}*/


	// Get data saved in serialized object.
	public Sprite GetCharacterSpriteIcon (int charSlot){
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].icon;
		}
		Debug.Log ("cannot find character icon");
		return null;
	}
	
	public string GetCharacterStringName (int charSlot){
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].name;
		}
		Debug.Log ("cannot find character icon");
		return "";
	}
	
	public int GetCharacterBaseHp (int charSlot){
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].baseHp;
		}
		Debug.Log ("cannot find character icon");
		return 0;
	}
	
	public int GetCharacterBaseMp (int charSlot){
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].baseMp;
		}
		Debug.Log ("cannot find character icon");
		return 0;
	}
	
	public int GetSavedPartyExp (int savedSlotNum){
		if (savedSlotNum < 4) {
			int charInt = this.dataObject.savedPartyMembers[savedSlotNum];
			return this.dataObject.savedCharacterData[charInt].exp;
		}
		return 0;
	}
	
	public int GetSavedPartyCurHp (int savedSlotNum){
		if (savedSlotNum < 4) {
			int charInt = this.dataObject.savedPartyMembers[savedSlotNum];
			return this.dataObject.savedCharacterData[charInt].curHp;
		}
		return 0;
	}

	public void SetSavedPartyCurHp (int savedSlotNum, int hp){
		if (savedSlotNum < 4) {
			int charInt = this.dataObject.savedPartyMembers[savedSlotNum];
			this.dataObject.savedCharacterData[charInt].curHp = hp;
		}
	}

	public int GetSavedPartyCurMp (int savedSlotNum){
		if (savedSlotNum < 4) {
			int charInt = this.dataObject.savedPartyMembers[savedSlotNum];
			return this.dataObject.savedCharacterData[charInt].curMp;
		}
		return 0;
	}

	public void SetSavedPartyCurMp (int savedSlotNum, int mp){
		if (savedSlotNum < 4) {
			int charInt = this.dataObject.savedPartyMembers[savedSlotNum];
			this.dataObject.savedCharacterData[charInt].curMp = mp;
		}
	}

	public void SetNewSavedPartyMember (int savedSlotNum, int charInt){
		if ((savedSlotNum < 4) && (charInt < this.characterProperties.characters.Length)) {
			this.dataObject.savedPartyMembers[savedSlotNum] = charInt;
		}
	}



	// General binary access to save and load data.
	public void Save () {
		this.dataObject.dateLastSaved = DateTime.Now;
		BinaryFormatter bf = new BinaryFormatter();
		//Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
		FileStream file = File.Create (Application.persistentDataPath + "/savedData.gd"); //you can call it anything you want
		bf.Serialize(file, this.dataObject);
		file.Close();
		Debug.Log ("Saved: " + Application.persistentDataPath);
	}   
	
	
	public void Load () {
		if (File.Exists (Application.persistentDataPath + "/savedData.gd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/savedData.gd", FileMode.Open);
			this.dataObject = (DataObject)bf.Deserialize (file);	
			file.Close ();
			Debug.Log ("Loaded: " + Application.persistentDataPath);
		} else {
			this.Save ();
			this.Load ();
		}
	}
}

