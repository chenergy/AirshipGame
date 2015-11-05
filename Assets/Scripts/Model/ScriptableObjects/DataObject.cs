using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class DataObject
{
	public DateTime dateLastSaved;

	// List of airships.
	public AirshipSerialized[] airships;

	// Current airship
	public GameEnum.AirshipName currentAirship;

	// List of characters that I have in inventory.
	public List<CharacterSerialized> characterInventory;

	// Current crew on airships, positions on airship
	public int[] charInAirshipSlotToInventory;

	// List of missions.
	public Mission[] missions;
	public int curMission = 0;


	public DataObject (SO_Characters.CharacterScriptable[] characterScriptables, SO_Airships.AirshipScriptable[] airshipScriptables){
		this.dateLastSaved = DateTime.Now;

        // Populate character inventory with 4 characters.
		this.characterInventory = new List<CharacterSerialized> ();
		this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.EMPTY].characterData.Clone ());
        this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.MAIN_BOB].characterData.Clone ());
		this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.MAIN_LILY].characterData.Clone ());
		this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.MAIN_SAM].characterData.Clone ());
		this.characterInventory.Add (characterScriptables [(int)GameEnum.CharacterName.MAIN_TIM].characterData.Clone ());

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

        // Save characters from 0 and 1 (inventory index) into characterInventory.
        int airshipSlots = airshipScriptables[(int)this.currentAirship].slots.Length;
		this.charInAirshipSlotToInventory = new int[airshipSlots];
		this.charInAirshipSlotToInventory [0] = 1;
		this.charInAirshipSlotToInventory [1] = 2;
		this.charInAirshipSlotToInventory [2] = 3;
		this.charInAirshipSlotToInventory [3] = 4;

        // Setup missions and objectives.
        A_Objective[] objectives = new A_Objective[1];
        Objective_KillEnemy kill_kamikaze = new Objective_KillEnemy("Kill the Kamikaze enemy.", "Kill the Kamikaze enemy.", GameEnum.EnemyName.ENEMY_KAMIKAZE);
        objectives[0] = kill_kamikaze;
        Mission m0 = new Mission("Tutorial", "This is the tutorial mission.", objectives);
        this.missions = new Mission[1];
        this.missions[0] = m0;
	}
}

