using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadoutAirshipLayout : MonoBehaviour
{
    [System.Serializable]
    public class AirshipSlot
    {
        public RectTransform parentRt;
        public Button button;
        public Image image;
    }

    public Image layout;
    public AirshipSlot[] slots;

    // Use this for initialization
    /*void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }*/
    public void OpenMenu (LoadoutMenuController controller, int airshipNum)
    {
        GameEnum.AirshipName airshipName = (GameEnum.AirshipName)airshipNum;
        this.layout.sprite = GameManager.instance.Data.GetAirshipLayout(airshipName);
        int airshipSlotsNum = GameManager.instance.Data.GetAirshipSlotsNum(airshipName);

        for (int i = 0; i < this.slots.Length; i++)
        {
            if (i < airshipSlotsNum)
            {
                this.slots[i].parentRt.gameObject.SetActive(true);

                int inventoryNum = GameManager.instance.Data.GetCharactersInAirship()[i];
                //GameEnum.CharacterName charName = GameManager.instance.Data.GetInventoryCharacterName(inventoryNum);
                //Debug.Log(inventoryNum);
                this.slots[i].image.sprite = GameManager.instance.Data.GetInventoryCharacterSpriteIcon(inventoryNum);
                /*this.slots[i].button.onClick.AddListener(delegate {
                    controller.OpenCharacterMenuForSlot(i);
                });*/

                AirshipCharacterSlot slotInfo = GameManager.instance.Data.GetAirshipSlotInfo(airshipName, i);
                //Debug.Log(slotInfo.centerX.ToString() + ":" + slotInfo.centerY.ToString());
                this.slots[i].parentRt.anchoredPosition = new Vector2(slotInfo.centerX, slotInfo.centerY);
                this.slots[i].parentRt.sizeDelta = new Vector2(slotInfo.width, slotInfo.height);
            } else
            {
                this.slots[i].parentRt.gameObject.SetActive(false);
            }
        }
    }
}
