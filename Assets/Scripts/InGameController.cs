using UnityEngine;
using System.Collections;

public class InGameController : MonoBehaviour
{
	public PartyMenuController pmc;
	public Airship airship;
	public ErrorLog errorLog;
	public SkillTip_TargetAOE skillTipTargetAOE;
	public SkillTip_Straight skillTipStraight;

	private Character[] partyCharacters;
	private int activatedCharNum = -1;

	
	// Use this for initialization
	void Start ()
	{
		GameManager.instance.InGameController = this;

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

	void OnApplicationPause (bool pauseStatus){
		if (pauseStatus) {
			for (int i = 0; i < this.partyCharacters.Length; i++) {
				GameManager.instance.Data.SetSavedPartyCurHp (i, this.partyCharacters[i].CurHp);
				GameManager.instance.Data.SetSavedPartyCurMp (i, this.partyCharacters[i].CurMp);
			}

			GameManager.instance.Data.Save ();
		}
	}

	void OnApplicationQuit (){
		for (int i = 0; i < this.partyCharacters.Length; i++) {
			GameManager.instance.Data.SetSavedPartyCurHp (i, this.partyCharacters[i].CurHp);
			GameManager.instance.Data.SetSavedPartyCurMp (i, this.partyCharacters[i].CurMp);
		}

		GameManager.instance.Data.Save ();
	}


	public void ActivateAbility (int charNum) {
		if (charNum < this.partyCharacters.Length) {
			if (this.partyCharacters[charNum].CanUseAbility()) {
				// Stop showing the skilltip.
				//this.skillTipTargetAOE.Enable (10.0f);
				this.skillTipStraight.Enable (10.0f);

				// Activate the character's ability to be used.
				this.partyCharacters[charNum].ActivateAbility();

				// Set the activated character number.
				this.activatedCharNum = charNum;
			}
		}
	}


	public void UseAbility (Vector3 target) {
		if ((this.activatedCharNum != -1) && (this.activatedCharNum < this.partyCharacters.Length)) {
			if (this.partyCharacters[this.activatedCharNum].CanUseAbility()) {
				// Stop showing the skilltip.
				//this.skillTipTargetAOE.Disable ();
				this.skillTipStraight.Disable ();

				// Use the character's ability.
				this.partyCharacters[this.activatedCharNum].UseAbility (target);

				// Recharge the cooldown timer for target character.
				//this.StartCoroutine ("StartCooldownTimer", this.activatedCharNum);
				this.pmc.partyCharacters [this.activatedCharNum].RechargeCooldown ();
				this.pmc.partyCharacters [this.activatedCharNum].RechargeMana ();

				// Reset the activated character number.
				this.activatedCharNum = -1;
			}
		}
	}


	public void RotateAirship (float degrees){
		this.airship.Rotate (degrees);
	}


	public void UpdateAirshipSpeed (float newSpeed){
		this.airship.UpdateSpeed (newSpeed);
	}


	public void DeleteSave (){
		System.IO.File.Delete (Application.persistentDataPath + "/savedData.gd");
	}
}

