using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class PartyMenuCharacter : MonoBehaviour
{
	public Text nameText;

	public Image hpImage;
	public Text hpCurText;
	public Text hpMaxText;

	public Image mpImage;
	public Text mpCurText;
	public Text mpMaxText;

	

	public void SetPartyCharacter (Character character){
		this.nameText.text = character.Name;
		this.hpImage.fillAmount = 1.0f;
		this.mpImage.fillAmount = 1.0f;
		this.hpCurText.text = this.hpMaxText.text = character.MaxHp.ToString ();
		this.mpCurText.text = this.mpMaxText.text = character.MaxMp.ToString ();
	}
}

