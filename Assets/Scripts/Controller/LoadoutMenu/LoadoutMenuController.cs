using UnityEngine;
using System.Collections;

public class LoadoutMenuController : MonoBehaviour
{
    public GameObject parent;
    public LoadoutCharacters charactersUI;
    public LoadoutAirshipSelect airshipSelectUI;
    public LoadoutAirshipLayout airshipLayoutUI;

    private int selectedAirshipNum;
    private int selectedAirshipSlotNum;

    // Use this for initialization
    void Start()
    {
        this.selectedAirshipNum = (int)GameManager.instance.Data.GetCurrentAirshipName();
        this.OpenAirshipSelect();
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/
    public void OpenAirshipSelect()
    {
        this.charactersUI.gameObject.SetActive(false);
        this.airshipLayoutUI.gameObject.SetActive(false);
        this.airshipSelectUI.gameObject.SetActive(true);

        this.airshipSelectUI.OpenMenu(this.selectedAirshipNum);
    }

    public void OpenAirshipLayoutForNum (int airshipNum)
    {
        this.selectedAirshipNum = airshipNum;

        this.charactersUI.gameObject.SetActive(false);
        this.airshipLayoutUI.gameObject.SetActive(true);
        this.airshipSelectUI.gameObject.SetActive(false);

        GameManager.instance.Data.SetCurrentAirship((GameEnum.AirshipName)airshipNum);
        this.airshipLayoutUI.OpenMenu(this, airshipNum);
    }

    public void OpenCharacterMenuForSlot(int slotNum)
    {
        this.selectedAirshipSlotNum = slotNum;

        this.charactersUI.gameObject.SetActive(true);
        this.airshipLayoutUI.gameObject.SetActive(true);
        this.airshipSelectUI.gameObject.SetActive(false);

        this.charactersUI.OpenMenu(this);
    }


    public void SelectCharacterInventoryIndex(int inventoryNum)
    {
        GameManager.instance.Data.SetCharacterInAirship(inventoryNum, this.selectedAirshipSlotNum);
        GameManager.instance.Data.Save();
        this.OpenAirshipLayoutForNum(this.selectedAirshipNum);
    }


	public void ButtonCloseCharacterInventory (){
		this.OpenAirshipLayoutForNum (this.selectedAirshipNum);
	}


    public void ButtonBeginMission()
    {
        Application.LoadLevel("LevelPrototype");
    }
}
