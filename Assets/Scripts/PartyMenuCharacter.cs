using UnityEngine;
using UnityEngine.UI;
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

	// Use this for initialization
	/*void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}*/
	public void SetPartyCharacter (Character character){
		this.nameText.text = character.Name;
		this.hpImage.fillAmount = 1.0f;
		this.mpImage.fillAmount = 1.0f;
		this.hpCurText.text = this.hpMaxText.text = character.MaxHp.ToString ();
		this.mpCurText.text = this.mpMaxText.text = character.MaxMp.ToString ();
	}
}

