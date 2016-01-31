using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Organize and layout the sorting layers for 2D images.
/// Handles the masking when the player is occluded.
/// </summary>
public class Environment2DLayerManager : MonoBehaviour
{
	/// <summary>
	/// The list of each canvas mask that is associated with the int layer.
	/// </summary>
	public Environment2DLayer[] m_layers;

	/// <summary>
	/// The instance.
	/// </summary>
	private static Environment2DLayerManager instance;
	public static Environment2DLayerManager Instance {
		get { return instance; }
	}

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake (){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
	}

	/*void Update (){
		this.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 5;
	}*/

	public void ProcessLayers (List<int> layers){
		for (int i = 0; i < m_layers.Length; i++) {
			m_layers [i].m_mask.transform.position = GameManager.instance.InGameController.Airship.transform.position;

			if (layers.Contains (i)) {
				if (!m_layers [i].m_isMaskOn) {
					m_layers [i].m_isMaskOn = true;
					StopCoroutine ("_SetMaskActive");
					StopCoroutine ("_SetMaskInactive");
					StartCoroutine ("_SetMaskActive", m_layers [i].m_mask.transform);
				}
			} else {
				if (m_layers [i].m_isMaskOn) {
					m_layers [i].m_isMaskOn = false;
					StopCoroutine ("_SetMaskActive");
					StopCoroutine ("_SetMaskInactive");
					StartCoroutine ("_SetMaskInactive", m_layers [i].m_mask.transform);
				}
			}
		}

		/*foreach (int i in layers) {
			m_layers [i].m_mask.SetActive (true);
			Vector3 airshipPos = GameManager.instance.InGameController.Airship.transform.position;
			m_layers [i].m_mask.transform.position = airshipPos;//Camera.main.WorldToScreenPoint (airshipPos);
		}*/
	}

	/// <summary>
	/// Sets the mask active.
	/// </summary>
	/// <returns>The mask.</returns>
	/// <param name="active">If set to <c>true</c> active.</param>
	private IEnumerator _SetMaskActive (Transform mask){
		mask.transform.localScale = Vector3.zero;
		mask.gameObject.SetActive (true);

		float timer = 0.0f;
		float duration = 0.25f;
		Vector3 startSize = mask.localScale;
		Vector3 targetSize = Vector3.one * 2.5f;

		while (timer < duration) {
			yield return null;
			mask.localScale = Vector3.Lerp (mask.localScale, targetSize, timer / duration);
			timer += Time.deltaTime;
		}

		mask.localScale = targetSize;
	}

	/// <summary>
	/// Sets the mask inactive.
	/// </summary>
	/// <returns>The mask.</returns>
	/// <param name="mask">Mask.</param>
	private IEnumerator _SetMaskInactive (Transform mask){
		float timer = 0.0f;
		float duration = 0.25f;
		Vector3 startSize = mask.localScale;
		Vector3 targetSize = Vector3.zero;

		while (timer < duration) {
			yield return null;
			mask.localScale = Vector3.Lerp (mask.localScale, targetSize, timer / duration);
			timer += Time.deltaTime;
		}

		mask.localScale = targetSize;
	}
}

