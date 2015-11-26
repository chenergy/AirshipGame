using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PartyMenuCharacter : MonoBehaviour
{
	[System.Serializable]
	public class DisplayProperties {
		// Main Display.
		public GameObject parent;
		public Image iconImage;
		public Text nameText;
		public Image hpImage;
		public Text hpText;
		public Image mpImage;
		public Text mpText;
		public Image cdImage;
	}

	[System.Serializable]
	public class TooltipProperties
	{
		// Show ability tooltip.
		public GameObject tooltipParent;
		public Text tooltipAbilityName;
		public Text tooltipAbilityDesc;
		public Text tooltipAbilityMana;
		public Text tooltipAbilityCooldown;
	}
	
	public DisplayProperties[] displayProperties;
	public TooltipProperties tooltipProperties;

	private PartyCharacter character;
	private GameEnum.DisplayType displayType;


	public void SetDisplayType (GameEnum.DisplayType type){
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

	public void SetPartyCharacter (PartyCharacter character){
		this.character = character;

		// Update the displays
		foreach (DisplayProperties dp in this.displayProperties) {
			dp.iconImage.sprite = character.Icon;
			dp.nameText.text = character.Name;
			dp.hpImage.fillAmount = 1.0f;
			dp.mpImage.fillAmount = 1.0f;

			if (this.displayType == GameEnum.DisplayType.CIRCLE)
				dp.cdImage.fillAmount = 0.0f;
			else
				dp.cdImage.fillAmount = 1.0f;

			dp.hpText.text = string.Format ("{0} / {1}", character.CurHp.ToString (), character.MaxHp.ToString ());
			dp.mpText.text = string.Format ("{0} / {1}", character.CurMp.ToString (), character.MaxMp.ToString ());
		}
			
		// Set tooltip info.
		if (character.Ability != null) {
			GameEnum.AbilityName abilityName = character.Ability.AbilityName;
			this.tooltipProperties.tooltipAbilityName.text = GameManager.instance.Data.GetAbilityStringName (abilityName);
			this.tooltipProperties.tooltipAbilityDesc.text = GameManager.instance.Data.GetAbilityDesc (abilityName);
			this.tooltipProperties.tooltipAbilityMana.text = GameManager.instance.Data.GetAbilityStringManaCost (abilityName).ToString ();
			this.tooltipProperties.tooltipAbilityCooldown.text = GameManager.instance.Data.GetAbilityStringCooldown (abilityName).ToString ();
			this.tooltipProperties.tooltipParent.SetActive (false);

			if (this.character.CurMp < this.character.MaxMp)
				this.RechargeMana ();
		} else {
			this.tooltipProperties.tooltipAbilityName.text = "";
			this.tooltipProperties.tooltipAbilityDesc.text = "";
			this.tooltipProperties.tooltipAbilityMana.text = "";
			this.tooltipProperties.tooltipAbilityCooldown.text = "";
			this.tooltipProperties.tooltipParent.SetActive (false);
		}
	}


	public void RechargeMana (){
		StopCoroutine ("RechargeManaRoutine");
		StartCoroutine ("RechargeManaRoutine");
	}


	public void RechargeCooldown (){
		StopCoroutine ("RechargeCooldownRoutine");
		StartCoroutine ("RechargeCooldownRoutine");
	}


	public void UpdateCurHp (){
		foreach (DisplayProperties dp in this.displayProperties) {
			dp.hpImage.fillAmount = this.character.CurHp * 1.0f / this.character.MaxHp;
		}
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
				if (this.displayType == GameEnum.DisplayType.CIRCLE)
					dp.cdImage.fillAmount = (1.0f - this.character.CurCooldown / this.character.MaxCooldown);
				else
					dp.cdImage.fillAmount = (1.0f * this.character.CurCooldown / this.character.MaxCooldown);
			}

			this.character.RechargeCooldown (Time.deltaTime);
		}

		foreach (DisplayProperties dt in this.displayProperties) {
			if (this.displayType == GameEnum.DisplayType.CIRCLE)
				dt.cdImage.fillAmount = 0.0f;
			else
				dt.cdImage.fillAmount = 1.0f;
		}

		this.character.RechargeCooldown (Time.deltaTime);
	}


	public void OnPointerEnter (BaseEventData b){
		if (this.character.Ability != null)
			this.tooltipProperties.tooltipParent.SetActive (true);
	}


	public void OnPointerExit (BaseEventData b){
		this.tooltipProperties.tooltipParent.SetActive (false);
	}
}

