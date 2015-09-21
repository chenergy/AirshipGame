using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PartyMenuCharacter : MonoBehaviour
{
	public Image iconImage;
	public Text nameText;

	public Image hpImage;
	public Text hpText;

	public Image mpImage;
	public Text mpText;

	public Image cdImage;

	private Character menuCharacter;
	

	public void SetPartyCharacter (Character character){
		this.menuCharacter = character;
		this.iconImage.sprite = character.Icon;
		this.nameText.text = character.Name;
		this.hpImage.fillAmount = 1.0f;
		this.mpImage.fillAmount = 1.0f;
		this.cdImage.fillAmount = 1.0f;
		this.hpText.text = string.Format ("{0} / {1}", character.curHp.ToString(), character.maxHp.ToString ());
		this.mpText.text = string.Format ("{0} / {1}", character.curMp.ToString(), character.maxMp.ToString ());
	}
}

