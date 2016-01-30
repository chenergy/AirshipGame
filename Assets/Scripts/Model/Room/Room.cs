using UnityEngine;
using System.Collections;

/// <summary>
/// Contains data about how to populate the room generically.
/// </summary>
[System.Serializable]
public class Room
{
	/// <summary>
	/// Direction.
	/// </summary>
	public enum Direction {
		LEFT, RIGHT, UP, DOWN
	};

	/// <summary>
	/// Initializes a new instance of the <see cref="Room"/> class.
	/// </summary>
	/// <param name="left">Left.</param>
	/// <param name="right">Right.</param>
	/// <param name="up">Up.</param>
	/// <param name="down">Down.</param>
	/// <param name="floorPrefab">Floor prefab.</param>
	public Room (GameObject floorPrefab) {
		m_floorPrefab = floorPrefab;
	}

	/// <summary>
	/// The other rooms in the direction of left, right, up, and down.
	/// </summary>
	public Room m_left, m_right, m_up, m_down;

	/// <summary>
	/// The prefab of the room to generate.
	/// </summary>
	private GameObject m_floorPrefab;

	/// <summary>
	/// Create and return the created room.
	/// </summary>
	/// <returns>The room object.</returns>
	public GameObject GenerateRoomObject (){
		//return Object.Instantiate (roomPrefab);
		GameObject parent = new GameObject ();
		GameObject floor = GameObject.Instantiate (m_floorPrefab);
		floor.transform.SetParent (parent.transform);
		return parent;
	}
}

