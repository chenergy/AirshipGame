using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Based on the assigned rooms, 
/// </summary>
public class RoomController : MonoBehaviour
{
	/// <summary>
	/// Basic floor 0.
	/// </summary>
	public GameObject m_basicFloor0;

	/// <summary>
	/// Basic floor 1.
	/// </summary>
	public GameObject m_basicFloor1;

	/// <summary>
	/// The image that covers the screen while the room is being loaded.
	/// </summary>
	public Image m_blackoutImage;

	/// <summary>
	/// The duration of the blackout screen.
	/// </summary>
	public float m_blackoutDuration = 1.0f;

	/// <summary>
	/// The current room that that has been loaded.
	/// </summary>
	private Room m_curRoom;

	/// <summary>
	/// The GameObject parent of the current room object.
	/// </summary>
	private GameObject m_curRoomObject;

	/// <summary>
	/// The next location from which to load the player.
	/// </summary>
	private Vector3 m_playerLoadPosition;

	/// <summary>
	/// The static instance of RoomController.
	/// </summary>
	private static RoomController instance = null;
	public static RoomController Instance {
		get { return instance; }
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake (){
		if (instance == null) {
			DontDestroyOnLoad (gameObject);
			instance = this;
		} else {
			Destroy (gameObject);
		}
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start (){
		Room down = new Room (m_basicFloor1);
		Room root = new Room (m_basicFloor0);

		root.m_down = down;
		down.m_up = root;

		InitRootRoom (root);
	}

	/// <summary>
	/// Assign the first room, which will act as the root room for the room tree.
	/// </summary>
	/// <param name="initRoom">Init room.</param>
	public void InitRootRoom (Room rootRoom){
		_LoadRoom (rootRoom);
	}

	/// <summary>
	/// Raises the hit room trigger event. Start the coroutine to load the next room.
	/// </summary>
	/// <param name="direction">The direction that the player has moved.</param>
	public void OnHitRoomTrigger (Room.Direction direction){
		switch (direction) {
		case Room.Direction.DOWN:
			StartCoroutine ("_LoadNextRoomRoutine", m_curRoom.m_down);
			m_playerLoadPosition = new Vector3 (0.0f, 10.0f, 45.0f);
			break;
		case Room.Direction.LEFT:
			StartCoroutine ("_LoadNextRoomRoutine", m_curRoom.m_left);
			m_playerLoadPosition = new Vector3 (45.0f, 10.0f, 0.0f);
			break;
		case Room.Direction.RIGHT:
			StartCoroutine ("_LoadNextRoomRoutine", m_curRoom.m_right);
			m_playerLoadPosition = new Vector3 (-45.0f, 10.0f, 0.0f);
			break;
		case Room.Direction.UP:
			StartCoroutine ("_LoadNextRoomRoutine", m_curRoom.m_up);
			m_playerLoadPosition = new Vector3 (0.0f, 10.0f, -45.0f);
			break;
		default:
			break;
		}
	}

	/// <summary>
	/// Loads the room.
	/// </summary>
	/// <param name="room">Room.</param>
	private void _LoadRoom (Room room){
		m_curRoom = room;
		Destroy (m_curRoomObject);
		m_curRoomObject = m_curRoom.GenerateRoomObject ();
	}

	/// <summary>
	/// Loads the next room routine.
	/// </summary>
	/// <returns>The coroutine.</returns>
	/// <param name="room">The room to load.</param>
	private IEnumerator _LoadNextRoomRoutine (Room room){
		float timer = 0.0f;
		float alpha = 0.0f;
		m_blackoutImage.color = new Color (m_blackoutImage.color.r, m_blackoutImage.color.g, m_blackoutImage.color.b, 0.0f);

		// Enabling the blackout image also stops input because it blocks raycasts.
		m_blackoutImage.gameObject.SetActive (true);

		// Increase opacity of blackout image to 1.0
		while (timer < m_blackoutDuration) {
			yield return null;

			alpha = Mathf.Lerp (0.0f, 1.0f, timer / m_blackoutDuration);
			m_blackoutImage.color = new Color (m_blackoutImage.color.r, m_blackoutImage.color.g, m_blackoutImage.color.b, alpha);

			timer += Time.deltaTime;
		}
		m_blackoutImage.color = new Color (m_blackoutImage.color.r, m_blackoutImage.color.g, m_blackoutImage.color.b, 1.0f);

		// Load the next room.
		_LoadRoom (room);
		GameManager.instance.InGameController.Airship.transform.position = m_playerLoadPosition;

		// Increase opacity of blackout image to 0.0
		timer = 0.0f;
		while (timer < m_blackoutDuration) {
			yield return null;

			alpha = Mathf.Lerp (1.0f, 0.0f, timer / m_blackoutDuration);
			m_blackoutImage.color = new Color (m_blackoutImage.color.r, m_blackoutImage.color.g, m_blackoutImage.color.b, alpha);

			timer += Time.deltaTime;
		}
		m_blackoutImage.color = new Color (m_blackoutImage.color.r, m_blackoutImage.color.g, m_blackoutImage.color.b, 0.0f);
		m_blackoutImage.gameObject.SetActive (false);
	}
}

