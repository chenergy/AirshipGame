using UnityEngine;
using System.Collections;

/// <summary>
/// The shadow underneath the airship.
/// </summary>
public class AirshipShadow : MonoBehaviour
{
	/// <summary>
	/// The airship target that the shadow is following.
	/// </summary>
	public A_Airship m_target;

	/// <summary>
	/// The layer mask of the objects being detected.
	/// </summary>
	private int m_layerMask;

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake (){
		m_layerMask = LayerMask.GetMask (new string[] {"EnvironmentCollider"});
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update (){
		RaycastHit hit;
		if (m_target != null) {
			if (Physics.Raycast (m_target.transform.position, Vector3.down, out hit, 100.0f, m_layerMask)) {
				//this.transform.position = new Vector3 (m_target.transform.position.x, hit.point.y, m_target.transform.position.z);
				this.transform.position = hit.point;
			}

			//Vector3 euler = m_target.transform.rotation.eulerAngles;
			//this.transform.rotation = Quaternion.Euler (new Vector3 (0.0f, euler.y, 0.0f));
		}
	}
}

