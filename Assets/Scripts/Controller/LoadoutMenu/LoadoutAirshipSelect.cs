using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadoutAirshipSelect : MonoBehaviour
{
    [System.Serializable]
    public class AirshipSelectButton
    {
        public RectTransform parentRt;
        public Button button;
        public Image image;
    }

    public ScrollRect scrollRect;
    public AirshipSelectButton[] airships;

    // Use this for initialization
    /*void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }*/


    public void OpenMenu(int curAirshipNum)
    {
        // Find center point of content.
        //AirshipSerialized[] airshipData = GameManager.instance.Data.GetAirshipData();
        //for (int i = 0; i < airshipData.Length; i++)
        for (int i = 0; i < GameManager.instance.Data.GetAirshipsTotalNum(); i++)
        {
            this.airships[i].image.sprite = GameManager.instance.Data.GetAirshipIcon((GameEnum.AirshipName)i);
            if (GameManager.instance.Data.IsAirshipLocked((GameEnum.AirshipName)i))
                this.airships[i].button.interactable = false;
        }
        
        float contentWidth = this.scrollRect.content.sizeDelta.x;
        float windowWidth = this.scrollRect.GetComponent<RectTransform>().sizeDelta.x;
        float airshipPosition = this.airships[curAirshipNum].parentRt.anchoredPosition.x;
        float targetPosition = (this.scrollRect.GetComponent<RectTransform>().sizeDelta.x - this.airships[0].parentRt.sizeDelta.x) / 2.0f;

        this.scrollRect.horizontalNormalizedPosition = (airshipPosition - targetPosition) / (contentWidth - windowWidth);
        Debug.Log(this.scrollRect.horizontalNormalizedPosition);
    }
}
