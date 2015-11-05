using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class DataManager
{
	// Assigned properties for character display.
	private SO_Characters characterScriptables;

	// Assigned properties for abilities.
	private SO_Abilities abilityScriptables;

	// Assigned properties for airships.
	private SO_Airships airshipScriptables;

	// Dictionary for accessing associated ability functionality.
	//private Dictionary <GameEnum.AbilityName, A_Ability> abilitiesDict = new Dictionary<GameEnum.AbilityName, A_Ability> ();
	//private A_Ability[] abilityClones;
	private Factory_Ability abilityFactory;

	// Loaded data object that is serialized and deserialized.
	private DataObject dataObject;

	public DataManager (SO_Characters characterScriptables, SO_Abilities abilityScriptables, SO_Airships airshipScriptables){
		// Forces a different code path in the BinaryFormatter that doesn't rely on run-time code generation (which would break on iOS).
		//http://answers.unity3d.com/questions/30930/why-did-my-binaryserialzer-stop-working.html
		Environment.SetEnvironmentVariable("MONO_REFLECTION_SERIALIZER", "yes");

        // Temp wipe data for iOS.
        //System.IO.File.Delete("/private" + Application.persistentDataPath + "/savedData.gd");
        // Temp wipe data for standalone.
        System.IO.File.Delete(Application.persistentDataPath + "/savedData.gd");

        //Debug.Log (Application.persistentDataPath);

        // Set scriptable object properties.
        this.characterScriptables = characterScriptables;
		this.abilityScriptables = abilityScriptables;
        this.airshipScriptables = airshipScriptables;

		this.abilityFactory = new Factory_Ability (abilityScriptables);

        this.dataObject = new DataObject (this.characterScriptables.characters, this.airshipScriptables.airships);

		// Deserialize data from binary.
		this.Load ();
	}


	public A_Ability CloneAbility (GameEnum.AbilityName abilityName, A_Airship owner){
		/*
		if (this.abilitiesDict.ContainsKey (abilityName))
			return this.abilitiesDict [abilityName].Clone (owner);
		return null;
		*/
		return this.abilityFactory.CloneAbility (abilityName, owner);
	}


	public string GetAbilityStringName (GameEnum.AbilityName abilityName){
		return this.abilityScriptables.abilities [(int)abilityName].name;
	}

	public string GetAbilityDesc (GameEnum.AbilityName abilityName){
		return this.abilityScriptables.abilities [(int)abilityName].desc;
	}

	public int GetAbilityStringManaCost (GameEnum.AbilityName abilityName){
		return this.abilityScriptables.abilities [(int)abilityName].manaCost;
	}

	public float GetAbilityStringCooldown (GameEnum.AbilityName abilityName){
		return this.abilityScriptables.abilities [(int)abilityName].cooldown;
	}

	public float GetAbilityStringMaxRange (GameEnum.AbilityName abilityName){
		return this.abilityScriptables.abilities [(int)abilityName].maxRange;
	}



    /*public void SetAbility (GameEnum.AbilityName abilityName, A_Ability ability){
		this.abilitiesDict.Add (abilityName, ability);
	}*/


    // Get character data from binary, find matching icon in scriptable.
    public Sprite GetInventoryCharacterSpriteIcon(int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            // Get character data from binary.
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];

            // Get int mapped from character name enum.
            int charNum = (int)cp.charName;

            // Find character in scriptable, get matching icon.
            if (charNum < this.characterScriptables.characters.Length)
                return this.characterScriptables.characters[charNum].icon;
        }

        Debug.Log("cannot find character icon");
        return null;
    }
	
    // Get string name of character from binary.
	public string GetInventoryCharacterStringName (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.name;
        }

        Debug.Log ("cannot find character string name");
		return "";
	}

	// Get string name of character from binary.
	public string GetInventoryCharacterDescription (int inventoryNum)
	{
		if (inventoryNum < this.dataObject.characterInventory.Count)
		{
			CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
			return cp.desc;
		}

		Debug.Log ("cannot find character description");
		return "";
	}
	
    // Get base hp of character in binary.
	public int GetInventoryCharacterBaseHp (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.baseHp;
        }

        Debug.Log ("cannot find character base hp");
		return 0;
	}
	
    // Get base mp of character in binary.
	public int GetInventoryCharacterBaseMp (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.baseMp;
        }

        Debug.Log ("cannot find character base mp");
		return 0;
	}
	
	public int GetInventoryCharacterExp (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.exp;
        }

        Debug.Log("cannot find character exp");
        return 0;
	}
	
	public int GetInventoryCharacterCurHp (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.curHp;
        }

        Debug.Log("cannot find character cur hp");
        return 0;
	}

    public int GetInventoryCharacterCurMp (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.curMp;
        }

        Debug.Log("cannot find character cur mp");
        return 0;
    }

    public GameEnum.AbilityName GetInventoryCharacterAbilityName (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.ability;
        }

        Debug.Log("cannot find character ability name");
        return GameEnum.AbilityName.NONE;
    }

    public GameEnum.CharacterName GetInventoryCharacterName (int inventoryNum)
    {
        if (inventoryNum < this.dataObject.characterInventory.Count)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[inventoryNum];
            return cp.charName;
        }

        Debug.Log("cannot find character name");
        return GameEnum.CharacterName.EMPTY;
    }

    public int GetInventoryCharacterCount()
    {
        return this.dataObject.characterInventory.Count;
    }




    public int[] GetCharactersInAirship()
    {
        return this.dataObject.charInAirshipSlotToInventory;
    }

    public void SetCharacterInAirship(int inventoryNum, int slotNum)
    {
        this.dataObject.charInAirshipSlotToInventory[slotNum] = inventoryNum;
    }

    /*public AirshipSerialized[] GetAirshipData()
    {
        return this.dataObject.airships;
    }*/
    public int GetAirshipsTotalNum()
    {
        return this.dataObject.airships.Length;
    }

	public bool IsInventoryCharacterInAirship (int inventoryNum){
		foreach (int character in this.dataObject.charInAirshipSlotToInventory) {
			if (character == inventoryNum)
				return true;
		}
		return false;
	}

    public bool IsAirshipLocked (GameEnum.AirshipName name)
    {
        return this.dataObject.airships[(int)name].isLocked;
    }

    public AirshipCharacterSlot GetAirshipSlotInfo (GameEnum.AirshipName name, int slotNum)
    {
        return this.airshipScriptables.airships[(int)name].slots[slotNum];
    }




    public GameEnum.AirshipName GetCurrentAirshipName()
    {
        return this.dataObject.currentAirship;
    }

    public int GetAirshipSlotsNum (GameEnum.AirshipName name)
    {
        return this.airshipScriptables.airships[(int)name].slots.Length;
    }

    public GameObject GetCurrentAirshipPrefab(GameEnum.AirshipName name)
    {
        return this.airshipScriptables.airships[(int)name].prefab;
    }

    public Sprite GetAirshipIcon (GameEnum.AirshipName name)
    {
        return this.airshipScriptables.airships[(int)name].icon;
    }

    public Sprite GetAirshipLayout(GameEnum.AirshipName name)
    {
        return this.airshipScriptables.airships[(int)name].layout;
    }

    public void SetCurrentAirship (GameEnum.AirshipName airshipName)
    {
        this.dataObject.currentAirship = airshipName;
    }

    



    public void SetAirshipCharacterCurHp(int airshipSlotNum, int hp)
    {
        if (airshipSlotNum < this.dataObject.charInAirshipSlotToInventory.Length)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[this.dataObject.charInAirshipSlotToInventory[airshipSlotNum]];
            cp.curHp = hp;
        }
    }

    public void SetAirshipCharacterCurMp(int airshipSlotNum, int mp)
    {
        if (airshipSlotNum < this.dataObject.charInAirshipSlotToInventory.Length)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[this.dataObject.charInAirshipSlotToInventory[airshipSlotNum]];
            cp.curMp = mp;
        }
    }

    public void SetAirshipCharacterExp (int airshipSlotNum, int exp)
    {
        if (airshipSlotNum < this.dataObject.charInAirshipSlotToInventory.Length)
        {
            CharacterSerialized cp = this.dataObject.characterInventory[this.dataObject.charInAirshipSlotToInventory[airshipSlotNum]];
            cp.exp = exp;
        }
    }

	/*public void SetNewSavedPartyMember (int savedSlotNum, int charInt){
		if ((savedSlotNum < 4) && (charInt < this.characterProperties.characters.Length)) {
			this.dataObject.charactersInAirship[savedSlotNum] = charInt;
		}
	}*/




	public Mission[] GetMissions (){
		return this.dataObject.missions;
	}


	public Mission GetCurrentMission (){
		return this.dataObject.missions [this.dataObject.curMission];
	}


	public void SetCurrentMission (int missionInt){
		if (missionInt < this.dataObject.missions.Length) {
			this.dataObject.curMission = missionInt;
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

