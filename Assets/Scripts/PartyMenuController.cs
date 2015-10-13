using UnityEngine;
using System.Collections;

public class PartyMenuController : MonoBehaviour
{
	public GameEnum.DisplayType displayType;
	public PartyMenuCharacter[] partyCharacters;



	void Start (){
		foreach (PartyMenuCharacter partyChar in this.partyCharacters) {
			partyChar.SetDisplayType (this.displayType);
		}
	}

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

