using UnityEngine;
using System.Collections;

public class PartyMenuController : MonoBehaviour
{
	public GameEnum.DisplayType displayType;
	public PartyMenuCharacter[] partyCharacters;


	void Awake (){
		foreach (PartyMenuCharacter partyChar in this.partyCharacters) {
			partyChar.SetDisplayType (this.displayType);
		}
	}


	public void SetPartyCharacter (Character character, GameEnum.AbilityName abilityName, int partyIndex){
		this.partyCharacters [partyIndex].SetPartyCharacter (character, abilityName);
	}
}

