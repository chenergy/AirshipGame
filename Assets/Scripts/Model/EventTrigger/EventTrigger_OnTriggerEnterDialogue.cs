using UnityEngine;
using System.Collections;


public class EventTrigger_OnTriggerEnterDialogue : MonoBehaviour
{
	public DialogueText[] dialogueText;

	void OnTriggerEnter (){
		GameManager.instance.InGameController.StartDialogueSequence (dialogueText);
		this.gameObject.SetActive (false);
	}
}

