using UnityEngine;
using System.Collections;

/// <summary>
/// A canvas layer that acts as a 
/// </summary>
public class Environment2DLayer : MonoBehaviour
{
	/// <summary>
	/// The assigned sorting layer for this layer.
	/// </summary>
	public int m_sortingLayer;

	/// <summary>
	/// The mask object that lies on this layer.
	/// </summary>
	public GameObject m_mask;

	public bool m_isMaskOn = false;

	/// <summary>
	/// Raises the camera raycast hit event to move the mask to the screen position.
	/// </summary>
	/// <param name="worldPosition">World position.</param>
	/*public void OnCameraRaycastHit (Vector3 worldPosition){
		m_mask.transform.position = Camera.main.WorldToScreenPoint (worldPosition);
	}*/


}

