using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager
{
	private SO_Characters characterProperties;

	// Loaded data object that is serialized and deserialized.
	private DataObject dataObject = new DataObject ();

	public DataManager (SO_Characters characterProperties){
		// Forces a different code path in the BinaryFormatter that doesn't rely on run-time code generation (which would break on iOS).
		//http://answers.unity3d.com/questions/30930/why-did-my-binaryserialzer-stop-working.html
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");
		
		#if UNITY_IOS
		// Temp wipe data.
		//System.IO.File.Delete("/private" + Application.persistentDataPath + "/savedData.gd");
		#endif

		Debug.Log (Application.persistentDataPath);

		this.characterProperties = characterProperties;

		// Deserialize data from binary.
		this.Load ();
	}


	// Get data saved in serialized object.
	//public Sprite GetCharacterSpriteIcon (GameEnum.CharacterName charName){
	public Sprite GetCharacterSpriteIcon (int charSlot){
		//int charInt = (int)charName;
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].icon;
		}
		Debug.Log ("cannot find character icon");
		return null;
	}

	//public string GetCharacterStringName (GameEnum.CharacterName charName){
	public string GetCharacterStringName (int charSlot){
		//int charInt = (int)charName;
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].name;
		}
		Debug.Log ("cannot find character icon");
		return "";
	}

	//public int GetCharacterBaseHp (GameEnum.CharacterName charName){
	public int GetCharacterBaseHp (int charSlot){
		//int charInt = (int)charName;
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].baseHp;
		}
		Debug.Log ("cannot find character icon");
		return 0;
	}

	//public int GetCharacterBaseMp (GameEnum.CharacterName charName){
	public int GetCharacterBaseMp (int charSlot){
		//int charInt = (int)charName;
		int charInt = this.dataObject.savedPartyMembers [charSlot];
		if (charInt < this.characterProperties.characters.Length) {
			return this.characterProperties.characters [charInt].baseMp;
		}
		Debug.Log ("cannot find character icon");
		return 0;
	}


	// Get data saved in binary.
	/*public GameEnum.CharacterName GetSavedPartyCharacterName (int savedSlotNum){
		int charNum = 0;
		if (savedSlotNum < 4) {
			charNum = this.dataObject.savedPartyMembers[savedSlotNum].charInt;
		}
		return (GameEnum.CharacterName) charNum;
	}*/
	
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

	public int GetSavedPartyCurMp (int savedSlotNum){
		if (savedSlotNum < 4) {
			int charInt = this.dataObject.savedPartyMembers[savedSlotNum];
			return this.dataObject.savedCharacterData[charInt].curMp;
		}
		return 0;
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
		Debug.Log (Application.persistentDataPath);
	}   
	
	
	public void Load () {
		if (File.Exists (Application.persistentDataPath + "/savedData.gd")) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + "/savedData.gd", FileMode.Open);
			this.dataObject = (DataObject)bf.Deserialize (file);	
			file.Close ();
		} else {
			this.Save ();
			this.Load ();
		}
	}
}

