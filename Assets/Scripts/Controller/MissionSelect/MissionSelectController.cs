using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MissionSelectController : MonoBehaviour
{
    public RectTransform missionSelectContent;
    public GameObject missionSelectPrefab;

    // Use this for initialization
    void Start()
    {
        Mission[] missions = GameManager.instance.Data.GetMissions();
        for (int i = 0; i < missions.Length; i++)
        {
            // Create new button for char in inventory.
            GameObject gobj = GameObject.Instantiate(this.missionSelectPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            gobj.transform.SetParent(this.missionSelectContent);

            // Setup position and scale of button.
            RectTransform rt = gobj.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(0.0f, rt.offsetMin.y);
            rt.offsetMax = new Vector2(0.0f, rt.offsetMax.y);
            rt.anchoredPosition = new Vector2(0.0f, i * -40.0f);
            rt.localScale = Vector3.one;

            // Populate the objective with info.
            MissionSelectButton ui = gobj.GetComponent<MissionSelectButton>();
            if (ui != null)
            {
                Mission m = missions[i];
                ui.missionName.text = m.name;
                ui.missionDesc.text = m.desc;
                ui.missionCompleted.SetActive(m.isComplete);

                int j = i;
                ui.button.onClick.AddListener(delegate
                {
                    GameManager.instance.Data.SetCurrentMission(j);
                    Application.LoadLevel("LoadoutMenu");
                });
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
