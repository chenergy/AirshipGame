using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenu : MonoBehaviour
{
	public IGM_CharacterSwap charSwap;


	void Start (){

	}

	public void SetCharOnDeck (int index, Sprite icon){
		charSwap.SetCharOnDeck (index, icon);
	}

	public void SetCharOnStandby (int index, Sprite icon){
		charSwap.SetCharOnStandby (index, icon);
	}
}
