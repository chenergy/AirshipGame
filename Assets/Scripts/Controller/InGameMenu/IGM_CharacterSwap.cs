using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class IGM_CharacterSwap : MonoBehaviour
{
	public Image onDragIcon;
	public Image[] onDeck;
	public Image[] onStandby;

	private int fromIndex;
	private bool fromStandby;
	private Image fromTouchImage;


	void Awake (){
		this.onDragIcon.gameObject.SetActive (false);
		foreach (Image i in this.onDeck) {
			i.transform.parent.gameObject.SetActive (false);
		}
		foreach (Image i in this.onStandby) {
			i.transform.parent.gameObject.SetActive (false);
		}
	}

	public void SetCharOnDeck (int index, Sprite icon){
		this.onDeck [index].transform.parent.gameObject.SetActive (true);
		this.onDeck [index].sprite = icon;
	}

	public void SetCharOnStandby (int index, Sprite icon){
		this.onStandby [index].transform.parent.gameObject.SetActive (true);
		this.onStandby [index].sprite = icon;
	}

	public void OnDrag (BaseEventData bed){
		if (fromTouchImage != null) {
			PointerEventData ped = (PointerEventData)bed;
			this.onDragIcon.transform.position = ped.position;
			this.onDragIcon.gameObject.SetActive (true);
		}
	}

	public void OnBeginDragOnDeck (int index){
		if (GameManager.instance.Data.GetCharactersInAirship ()[index] != 0) {
			this.fromTouchImage = onDeck [index];
			this.onDragIcon.sprite = this.fromTouchImage.sprite;
			this.fromTouchImage.gameObject.SetActive (false);

			this.fromIndex = index;
			this.fromStandby = false;
		}
	}

	public void OnBeginDragOnStandby (int index){
		if (GameManager.instance.Data.GetCharactersStandbyInAirship () [index] != 0) {
			this.fromTouchImage = onStandby [index];
			this.onDragIcon.sprite = this.fromTouchImage.sprite;
			this.fromTouchImage.gameObject.SetActive (false);

			this.fromIndex = index;
			this.fromStandby = true;
		} else {
			Debug.Log ("no char in standby");
		}
	}

	public void OnDropOnDeck (int index){
		if (fromTouchImage != null) {
			GameManager.instance.InGameController.SwapCharacters (fromIndex, fromStandby, index, false);

			this.fromTouchImage.sprite = this.onDeck [index].sprite;
			this.onDeck [index].sprite = this.onDragIcon.sprite;
		}

		Debug.Log ("swap onto deck: " + fromIndex.ToString () + " | " + index.ToString());
	}

	public void OnDropOnStandby (int index){
		if (fromTouchImage != null) {
			GameManager.instance.InGameController.SwapCharacters (fromIndex, fromStandby, index, true);

			this.fromTouchImage.sprite = this.onStandby [index].sprite;
			this.onStandby [index].sprite = this.onDragIcon.sprite;
		}

		Debug.Log ("swap onto standby: " + fromIndex.ToString () + " | " + index.ToString());
	}

	public void OnEndDrag (){
		this.onDragIcon.gameObject.SetActive (false);

		if (this.fromTouchImage != null) {
			this.fromTouchImage.gameObject.SetActive (true);
			this.fromTouchImage = null;
		}
	}
}

