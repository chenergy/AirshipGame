using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PartyMenuCharacter : MonoBehaviour
{
	[System.Serializable]
	public class DisplayProperties {
		public GameObject parent;

		public Image iconImage;
		public Text nameText;

		public Image hpImage;
		public Text hpText;

		public Image mpImage;
		public Text mpText;

		public Image cdImage;
	}
	
	public DisplayProperties[] displayProperties;

	private Character character;
	private DisplayType displayType;


	public void SetDisplayType (DisplayType type){
		this.displayType = type;
		int num = (int)type;

		// disable everything except for num
		for (int i = 0; i < this.displayProperties.Length; i++) {
			if (i == num)
				this.displayProperties [i].parent.SetActive (true);
			else 
				this.displayProperties [i].parent.SetActive (false);
		}
	}

	public void SetPartyCharacter (Character character){
		this.character = character;

		// Update the displays
		foreach (DisplayProperties dt in this.displayProperties) {
			dt.iconImage.sprite = character.Icon;
			dt.nameText.text = character.Name;
			dt.hpImage.fillAmount = 1.0f;
			dt.mpImage.fillAmount = 1.0f;

			if (this.displayType == DisplayType.CIRCLE)
				dt.cdImage.fillAmount = 0.0f;
			else
				dt.cdImage.fillAmount = 1.0f;

			dt.hpText.text = string.Format ("{0} / {1}", character.CurHp.ToString (), character.MaxHp.ToString ());
			dt.mpText.text = string.Format ("{0} / {1}", character.CurMp.ToString (), character.MaxMp.ToString ());
		}

		if (this.character.CurMp < this.character.MaxMp)
			this.RechargeMana ();
	}


	public void RechargeMana (){
		StopCoroutine ("RechargeManaRoutine");
		StartCoroutine ("RechargeManaRoutine");
	}


	public void RechargeCooldown (){
		StopCoroutine ("RechargeCooldownRoutine");
		StartCoroutine ("RechargeCooldownRoutine");
	}


	IEnumerator RechargeManaRoutine (){
		float tick = 0.0f;

		while (this.character.CurMp < this.character.MaxMp) {
			yield return new WaitForEndOfFrame();

			// Display updated mana amount.
			foreach (DisplayProperties dt in this.displayProperties) {
				dt.mpImage.fillAmount = (1.0f * this.character.CurMp / this.character.MaxMp);
				dt.mpText.text = string.Format ("{0} / {1}", character.CurMp.ToString (), character.MaxMp.ToString ());
			}

			if (tick > 1.0f) {
				this.character.RechargeMp (1);
				tick = 0.0f;
			}

			tick += Time.deltaTime;
		}

		foreach (DisplayProperties dt in this.displayProperties) {
			dt.mpText.text = string.Format ("{0} / {1}", character.CurMp.ToString (), character.MaxMp.ToString ());
			dt.mpImage.fillAmount = 1.0f;
		}
	}


	IEnumerator RechargeCooldownRoutine (){
		while (this.character.CurCooldown < this.character.MaxCooldown) {
			yield return new WaitForEndOfFrame();

			// Display updated cooldown amount.
			foreach (DisplayProperties dp in this.displayProperties) {
				if (this.displayType == DisplayType.CIRCLE)
					dp.cdImage.fillAmount = (1.0f - this.character.CurCooldown / this.character.MaxCooldown);
				else
					dp.cdImage.fillAmount = (1.0f * this.character.CurCooldown / this.character.MaxCooldown);
			}

			this.character.RechargeCooldown (Time.deltaTime);
		}

		foreach (DisplayProperties dt in this.displayProperties) {
			if (this.displayType == DisplayType.CIRCLE)
				dt.cdImage.fillAmount = 0.0f;
			else
				dt.cdImage.fillAmount = 1.0f;
		}

		this.character.RechargeCooldown (Time.deltaTime);
	}

	// Recharge cooldown timer after using a skill.
	/*IEnumerator StartCooldownTimer (int charNum){
		this.partyCharacters[charNum].CurCooldown = 0.0f;
		
		while (this.partyCharacters[charNum].CurCooldown < this.partyCharacters[charNum].MaxCooldown) {
			this.partyCharacters[charNum].CurCooldown += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		
		this.partyCharacters[charNum].CurCooldown = this.partyCharacters[charNum].MaxCooldown;
	}*/
}

