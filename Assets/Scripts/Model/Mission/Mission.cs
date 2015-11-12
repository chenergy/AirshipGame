using UnityEngine;
using System.Collections;

[System.Serializable]
public class Mission
{
	public string name;
	public string desc;
	public string levelToLoad;
	public A_Objective[] objectives;
	public int curObjective = 0;
	public bool isComplete = false;


	public Mission (string name, string desc, string levelToLoad, A_Objective[] objectives){
		this.name = name;
		this.desc = desc;
		this.levelToLoad = levelToLoad;
		this.objectives = objectives;
	}


	public void TriggerObjectiveCondition (GameEnum.ObjectiveCondition condition, params string[] parameters)
    {
		if (this.curObjective < this.objectives.Length) {
			this.objectives [this.curObjective].TriggerCondition (condition, parameters);

			if (this.objectives [this.curObjective].isComplete) {
				this.curObjective++;

                if (this.curObjective >= this.objectives.Length)
                {
                    this.isComplete = true;
                    GameManager.instance.Data.Save();
                }
			}
		}
	}
}

