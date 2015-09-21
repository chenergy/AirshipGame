using UnityEngine;
using System.Collections;

public class InGameController : MonoBehaviour
{
	public PartyMenuController pmc;

	// Use this for initialization
	void Start ()
	{
		//GameEnum.CharacterName c0Name = GameManager.instance.Data.GetSavedPartyCharacterName (0);
		Character c0 = new Character (GameManager.instance.Data.GetCharacterSpriteIcon (0),
		                              GameManager.instance.Data.GetCharacterStringName (0),
		                              GameManager.instance.Data.GetCharacterBaseHp (0),
		                              GameManager.instance.Data.GetCharacterBaseMp (0),
		                              GameManager.instance.Data.GetSavedPartyCurHp (0),
		                              GameManager.instance.Data.GetSavedPartyCurMp (0));
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
		pmc.SetPartyCharacter (c0, 2);
		pmc.SetPartyCharacter (c1, 3);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}

