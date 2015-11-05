using UnityEngine;
using System.Collections;

[System.Serializable]
public class Mission
{
	public string name;
	public string desc;
	public A_Objective[] objectives;
	public int curObjective = 0;
	public bool isComplete = false;


	public Mission (string name, string desc, A_Objective[] objectives){
		this.name = name;
		this.desc = desc;
		this.objectives = objectives;
	}


	public void TriggerMissionObjective (){
		if (this.curObjective < this.objectives.Length) {
			this.objectives [this.curObjective].TriggerObjective ();

			if (this.objectives [this.curObjective].isComplete) {
				this.curObjective++;

				if (this.curObjective >= this.objectives.Length)
					this.isComplete = true;
			}
		}
	}
}

