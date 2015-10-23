using UnityEngine;
using System.Collections;

public class StartMenuController : MonoBehaviour
{
    public GameObject charactersUI;
    public GameObject airshipSelectUI;
    public GameObject airshipLayoutUI;

    // Use this for initialization
    void Start()
    {
        this.OpenAirshipSelect();
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/
    public void OpenAirshipSelect()
    {
        this.charactersUI.SetActive(false);
        this.airshipLayoutUI.SetActive(false);
        this.airshipSelectUI.SetActive(true);
    }

    public void OpenAirshipLayoutForNum (int airshipNum)
    {
        this.charactersUI.SetActive(false);
        this.airshipLayoutUI.SetActive(true);
        this.airshipSelectUI.SetActive(false);
    }

    public void OpenCharacterMenuForSlot (int slotNum)
    {
        this.charactersUI.SetActive(true);
        this.airshipLayoutUI.SetActive(true);
        this.airshipSelectUI.SetActive(false);
    }
}
