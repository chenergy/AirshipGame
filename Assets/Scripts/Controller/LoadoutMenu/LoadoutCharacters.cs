using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LoadoutCharacters : MonoBehaviour
{
    public GameObject loadoutCharacterButtonPrefab;
    public Transform contentParent;

    private List<LoadoutCharacterButton> charButtons;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    /*void Update()
    {

    }*/


    public void OpenMenu(LoadoutMenuController controller)
    {
        //float startPosY = 0.0f;
        this.charButtons = new List<LoadoutCharacterButton>();

        for (int i = 0; i < GameManager.instance.Data.GetInventoryCharacterCount (); i++)
        {
            int j = i;

            int charNum = (int)GameManager.instance.Data.GetInventoryCharacterName(i);
            GameObject gobj = GameObject.Instantiate(this.loadoutCharacterButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
            gobj.transform.SetParent(this.contentParent);

            RectTransform rt = gobj.GetComponent<RectTransform>();
            rt.offsetMin = new Vector2(0.0f, rt.offsetMin.y);
            rt.offsetMax = new Vector2(0.0f, rt.offsetMax.y);
            rt.anchoredPosition = new Vector2(0.0f, i * -64.0f);
            rt.localScale = Vector3.one;

            LoadoutCharacterButton lcb = gobj.GetComponent<LoadoutCharacterButton>();
            lcb.image.sprite = GameManager.instance.Data.GetInventoryCharacterSpriteIcon(i);
            lcb.selectButton.onClick.AddListener(delegate {
                foreach (LoadoutCharacterButton b in this.charButtons)
                {
                    GameObject.Destroy(b.gameObject);
                }
                
                this.charButtons.Clear();
                controller.SelectCharacterInventoryIndex(j);
            });
            this.charButtons.Add(lcb);
        }
    }
}
