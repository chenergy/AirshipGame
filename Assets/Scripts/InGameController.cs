using UnityEngine;
using System.Collections;

public class InGameController : MonoBehaviour
{
	public PartyMenuController pmc;
	public Airship airship;
	public A_SkillTip sphereSkillTip;
	
	private Character[] partyCharacters;
	private int activatedCharNum = -1;

	// Use this for initialization
	void Start ()
	{
		this.partyCharacters = new Character[4];

		Character c0 = new Character (GameManager.instance.Data.GetCharacterSpriteIcon (0),
		                              GameManager.instance.Data.GetCharacterStringName (0),
		                              GameManager.instance.Data.GetCharacterBaseHp (0),
		                              GameManager.instance.Data.GetCharacterBaseMp (0),
		                              GameManager.instance.Data.GetSavedPartyCurHp (0),
		                              GameManager.instance.Data.GetSavedPartyCurMp (0));
		c0.SetAbility (GameManager.instance.Data.GetAbility (GameEnum.AbilityName.ABILITY_STRAIGHTBULLET));

		Character c1 = new Character (GameManager.instance.Data.GetCharacterSpriteIcon (1),
		                              GameManager.instance.Data.GetCharacterStringName (1),
		                              GameManager.instance.Data.GetCharacterBaseHp (1),
		                              GameManager.instance.Data.GetCharacterBaseMp (1),
		                              GameManager.instance.Data.GetSavedPartyCurHp (1),
		                              GameManager.instance.Data.GetSavedPartyCurMp (1));
		Character c2 = new Character (GameManager.instance.Data.GetCharacterSpriteIcon (2),
		                              GameManager.instance.Data.GetCharacterStringName (2),
		                              GameManager.instance.Data.GetCharacterBaseHp (2),
		                              GameManager.instance.Data.GetCharacterBaseMp (2),
		                              GameManager.instance.Data.GetSavedPartyCurHp (2),
		                              GameManager.instance.Data.GetSavedPartyCurMp (2));
		Character c3 = new Character (GameManager.instance.Data.GetCharacterSpriteIcon (3),
		                              GameManager.instance.Data.GetCharacterStringName (3),
		                              GameManager.instance.Data.GetCharacterBaseHp (3),
		                              GameManager.instance.Data.GetCharacterBaseMp (3),
		                              GameManager.instance.Data.GetSavedPartyCurHp (3),
		                              GameManager.instance.Data.GetSavedPartyCurMp (3));

		pmc.SetPartyCharacter (c0, 0);
		pmc.SetPartyCharacter (c1, 1);
		pmc.SetPartyCharacter (c2, 2);
		pmc.SetPartyCharacter (c3, 3);

		this.partyCharacters [0] = c0;
		this.partyCharacters [1] = c1;
		this.partyCharacters [2] = c2;
		this.partyCharacters [3] = c3;
	}
	
	// Update is called once per frame
	/*void Update ()
	{
	
	}*/

	public void ActivateAbility (int charNum) {
		//if (charNum < this.pmc.partyCharacters.Length) {

		if (charNum < this.partyCharacters.Length) {
			this.activatedCharNum = charNum;

			if (this.partyCharacters[charNum].CanUseAbility()) {
				this.sphereSkillTip.Enable (10.0f);
				this.partyCharacters[charNum].ActivateAbility();
			}
			//this.pmc.partyCharacters [charNum].ActivateAbility ();
		}
	}


	public void UseAbility (Vector3 target) {
		if ((this.activatedCharNum != -1) && (this.activatedCharNum < this.partyCharacters.Length)) {
			//this.pmc.UseAbility (charNum);
			if (this.partyCharacters[this.activatedCharNum].CanUseAbility()) {
				this.partyCharacters[this.activatedCharNum].UseAbility (target);
			}
			//this.pmc.partyCharacters [charNum].UseAbility ();
			this.activatedCharNum = -1;
		}
	}


	public void RotateAirship (float degrees){
		this.airship.Rotate (degrees);
	}


	public void UpdateAirshipSpeed (float newSpeed){
		this.airship.UpdateSpeed (newSpeed);
	}
}

