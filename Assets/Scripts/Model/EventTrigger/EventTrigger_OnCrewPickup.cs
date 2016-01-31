using UnityEngine;
using System.Collections;

/// <summary>
/// Trigger when the player enters 
/// </summary>
public class EventTrigger_OnCrewPickup : A_EventTrigger
{
	/// <summary>
	/// The name of the character to add.
	/// </summary>
	public GameEnum.CharacterName m_character;

	/// <summary>
	/// The particle that spawns when the crew member is picked up.
	/// </summary>
	public GameObject m_onDestroyParticle;

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter (Collider other){
		if (other.GetComponent <Airship_Player> () != null) {
			//GameManager.instance.InGameController.PickupCrew (m_character);

			GameManager.instance.Data.AddNewCharacterToInventory (m_character);
			GameManager.instance.Data.Save ();

			//if (
			//GameManager.instance.InGameController.errorLog.LogErrorText (string.Format ("{0} added to standby.", m_character.ToString ()));

			/*
			if (m_onDestroyParticle != null) {
				GameObject newParticle = GameObject.Instantiate (m_onDestroyParticle, this.transform.position, Quaternion.identity) as GameObject;
				GameObject.Destroy (newParticle, 1.0f);
			}
			*/

			GameObject.Destroy (this.gameObject);
		}
	}
}

