using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SpeedLever : MonoBehaviour
{
	public InputHandler input;
	public Slider lever;

	public void OnValueChange (){
		this.input.SetAirshipSpeed (this.lever.value);
	}
}

