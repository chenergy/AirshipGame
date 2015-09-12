using UnityEngine;
using System.Collections;

public class PartyMenuController : MonoBehaviour
{
	public PartyMenuCharacter[] partyCharacters;

	void Awake (){
	}

	public void SetPartyCharacter (Character character, int partyIndex){
		this.partyCharacters [partyIndex].SetPartyCharacter (character);
	}
}

