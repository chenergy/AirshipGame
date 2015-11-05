using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionController : MonoBehaviour
{
    public Transform missionParent;
    public Text missionName;
    public Text missionDesc;
    public GameObject missionComplete;
    public Transform objectivesParent;
    public GameObject objectiveUIPrefab;

	private Mission mission;
    private ObjectiveUI[] objectiveUIElements;


	public void SetMission (Mission mission){
        // Initialize mission info.
		this.mission = mission;
        this.missionName.text = mission.name;
        this.missionDesc.text = mission.desc;

        // Initialize objectives info.
        this.objectiveUIElements = new ObjectiveUI[mission.objectives.Length];
        for (int i = 0; i < mission.objectives.Length; i++)
        {
            // Create new button for char in inventory.
            GameObject gobj = GameObject.Instantiate(this.objectiveUIPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            gobj.transform.SetParent(this.objectivesParent);

            // Setup position and scale of button.
            RectTransform rt = gobj.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(0.0f, rt.offsetMin.y);
            rt.offsetMax = new Vector2(0.0f, rt.offsetMax.y);
            rt.anchoredPosition = new Vector2(0.0f, i * -40.0f);
            rt.localScale = Vector3.one;

            // Populate the objective with info.
            ObjectiveUI ui = gobj.GetComponent<ObjectiveUI>();
            if (ui != null)
            {
                A_Objective objective = mission.objectives[i];
                ui.objectiveName.text = objective.name;
                ui.objectiveDesc.text = objective.desc;
            }
            this.objectiveUIElements[i] = ui;
        }

        this.UpdateMissionObjectives();
	}


	public void TriggerObjectiveCondition (GameEnum.ObjectiveCondition condition, params string[] parameters){
        Debug.Log("mission triggered");
		this.mission.TriggerObjectiveCondition (condition, parameters);

        this.UpdateMissionObjectives();
	}


    private void UpdateMissionObjectives()
    {
        for (int i = 0; i < this.mission.objectives.Length; i++)
        {
            ObjectiveUI ui = this.objectiveUIElements[i];
            if (this.mission.objectives[i].isComplete)
                ui.objectiveComplete.SetActive(true);
            else
                ui.objectiveComplete.SetActive(false);
        }

        if (this.mission.isComplete)
        {
            this.missionComplete.SetActive(true);
            // Then update ingamecontroller with mission completion.
        }
        else { 
            this.missionComplete.SetActive(false);
        }
    }
}

