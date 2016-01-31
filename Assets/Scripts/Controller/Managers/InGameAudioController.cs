using UnityEngine;
using System.Collections;

/// <summary>
/// The audio controller that plays audio during the game.
/// </summary>
public class InGameAudioController : MonoBehaviour
{
	/// <summary>
	/// The audio source that plays.
	/// </summary>
	public AudioSource m_audioSource;

	public AudioClip m_bgm;

	void Start (){
		PlayMusic (m_bgm, 1.0f, true);
	}

	/// <summary>
	/// Plays the music with the given settings.
	/// </summary>
	/// <param name="clip">Clip.</param>
	/// <param name="volume">Volume.</param>
	/// <param name="loop">If set to <c>true</c> loop.</param>
	public void PlayMusic (AudioClip clip, float volume, bool loop){
		m_audioSource.clip = clip;
		m_audioSource.volume = volume;
		m_audioSource.loop = loop;
		m_audioSource.Play ();
	}

	/// <summary>
	/// Plays the audio at location.
	/// </summary>
	/// <param name="clip">Clip.</param>
	/// <param name="position">Position.</param>
	public void PlayClipAtPoint (AudioClip clip, Vector3 position){
		AudioSource.PlayClipAtPoint (clip, position);
	}
}

