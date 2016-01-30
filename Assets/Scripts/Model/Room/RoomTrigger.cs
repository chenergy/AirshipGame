using UnityEngine;
using System.Collections;

/// <summary>
/// Trigger object to go in the specified direction.
/// </summary>
[RequireComponent (typeof (Collider))]
public class RoomTrigger : MonoBehaviour
{
	/// <summary>
	/// The direction that the player will go in the room tree.
	/// </summary>
	public Room.Direction m_direction;

	/// <summary>
	/// Raises the trigger enter event.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter (Collider other){
		Airship_Player player = other.GetComponent <Airship_Player> ();
		if (player != null) {
			RoomController.Instance.OnHitRoomTrigger (m_direction);
			GetComponent <Collider> ().enabled = false;
		}
	}
}

