using UnityEngine;
using System.Collections;

public class PartyMenuController : MonoBehaviour
{
	public PartyMenuCharacter[] partyCharacters;


	public void SetPartyCharacter (Character character, int partyIndex){
		this.partyCharacters [partyIndex].SetPartyCharacter (character);
	}
}

