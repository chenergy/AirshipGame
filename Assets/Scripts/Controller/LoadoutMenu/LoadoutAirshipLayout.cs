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
	public AirshipSlot[] standbySlots;


    public void OpenMenu (LoadoutMenuController controller, int airshipNum)
    {
        GameEnum.AirshipName airshipName = (GameEnum.AirshipName)airshipNum;
        this.layout.sprite = GameManager.instance.Data.GetAirshipLayout(airshipName);
        int airshipSlotsNum = GameManager.instance.Data.GetAirshipSlotsNum(airshipName);
		int airshipStandbySlotsNum = GameManager.instance.Data.GetAirshipStandbySlotsNum(airshipName);

        for (int i = 0; i < this.slots.Length; i++)
        {
            if (i < airshipSlotsNum)
            {
                this.slots[i].parentRt.gameObject.SetActive(true);
                int inventoryNum = GameManager.instance.Data.GetCharactersInAirship()[i];
                this.slots[i].image.sprite = GameManager.instance.Data.GetInventoryCharacterSpriteIcon(inventoryNum);

                AirshipCharacterSlot slotInfo = GameManager.instance.Data.GetAirshipSlotInfo(airshipName, i);
                this.slots[i].parentRt.anchoredPosition = new Vector2(slotInfo.centerX, slotInfo.centerY);
                this.slots[i].parentRt.sizeDelta = new Vector2(slotInfo.width, slotInfo.height);
            } else
            {
                this.slots[i].parentRt.gameObject.SetActive(false);
            }
        }

		for (int i = 0; i < this.standbySlots.Length; i++) {
			if (i < airshipStandbySlotsNum)
			{
				this.standbySlots[i].parentRt.gameObject.SetActive(true);
				int inventoryNum = GameManager.instance.Data.GetCharactersStandbyInAirship()[i];
				this.standbySlots[i].image.sprite = GameManager.instance.Data.GetInventoryCharacterSpriteIcon(inventoryNum);

				AirshipCharacterSlot slotInfo = GameManager.instance.Data.GetAirshipStandbySlotInfo(airshipName, i);
				this.standbySlots[i].parentRt.anchoredPosition = new Vector2(slotInfo.centerX, slotInfo.centerY);
				this.standbySlots[i].parentRt.sizeDelta = new Vector2(slotInfo.width, slotInfo.height);
			} else
			{
				this.standbySlots[i].parentRt.gameObject.SetActive(false);
			}
		}
    }
}
