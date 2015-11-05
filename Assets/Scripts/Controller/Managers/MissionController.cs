using UnityEngine;
using System.Collections;

public class MissionController : MonoBehaviour
{
	public Mission mission;
	/*
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	*/

	public void SetMission (Mission mission){
		this.mission = mission;
	}


	public void TriggerMissionObjective (){
		this.mission.TriggerMissionObjective ();
	}
}

