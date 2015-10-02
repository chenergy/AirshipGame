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

		public SavedCharacterData (int startHp, int startMp){
			this.curHp = startHp;
			this.curMp = startMp;
		}
	}

	public DateTime dateLastSaved;
	public int[] savedPartyMembers;
	public SavedCharacterData[] savedCharacterData;


	public DataObject (){
		// Stored references to party members (in binary and serialized object data).
		this.savedPartyMembers = new int[] {1, 2, 3, 4};

		// 
		this.savedCharacterData = new SavedCharacterData[5];
		this.savedCharacterData [0] = new SavedCharacterData (10, 10);
		this.savedCharacterData [1] = new SavedCharacterData (10, 10);
		this.savedCharacterData [2] = new SavedCharacterData (10, 10);
		this.savedCharacterData [3] = new SavedCharacterData (10, 10);
		this.savedCharacterData [4] = new SavedCharacterData (10, 10);
	}

	/*public int savedPartyMember0 = 0;
	public int savedPartyMember1 = 0;
	public int savedPartyMember2 = 0;
	public int savedPartyMember3 = 0;*/
}

