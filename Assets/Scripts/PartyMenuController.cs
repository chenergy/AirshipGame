using UnityEngine;
using System.Collections;

public class PartyMenuController : MonoBehaviour
{
	public PartyMenuCharacter[] partyCharacters;


	public void SetPartyCharacter (Character character, int partyIndex){
		this.partyCharacters [partyIndex].SetPartyCharacter (character);
	}
	/*
	public void ActivateAbility (int charNum){
		if (charNum < this.partyCharacters.Length) {
			this.partyCharacters[charNum].ActivateAbility ();
		}
	}

	public void UseAbility (int charNum){
		if (charNum < this.partyCharacters.Length) {
			this.partyCharacters[charNum].UseAbility ();
		}
	}

	public bool CanUseAbility (int charNum){
		if (charNum < this.partyCharacters.Length) {
			return this.partyCharacters [charNum].
		}
	}*/
}

