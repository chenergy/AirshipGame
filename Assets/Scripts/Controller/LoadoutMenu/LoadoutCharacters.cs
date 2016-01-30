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
        this.charButtons = new List<LoadoutCharacterButton>();

		for (int i = 0; i < GameManager.instance.Data.GetInventoryCharacterCount (); i++) {
			// Create new button for char in inventory.
			int charNum = (int)GameManager.instance.Data.GetInventoryCharacterName (i);
			GameObject gobj = GameObject.Instantiate (this.loadoutCharacterButtonPrefab, Vector3.zero, Quaternion.identity) as GameObject;
			gobj.transform.SetParent (this.contentParent);

			// Setup position and scale of button.
			RectTransform rt = gobj.GetComponent<RectTransform> ();
			rt.offsetMin = new Vector2 (0.0f, rt.offsetMin.y);
			rt.offsetMax = new Vector2 (0.0f, rt.offsetMax.y);
			rt.anchoredPosition = new Vector2 (0.0f, i * -64.0f);
			rt.localScale = Vector3.one;

			// Populate character button with info from inventory.
			LoadoutCharacterButton lcb = gobj.GetComponent<LoadoutCharacterButton> ();
            if (lcb != null)
            {
                bool isEquipped = GameManager.instance.Data.IsInventoryCharacterInAirship(i);
                string charName = GameManager.instance.Data.GetInventoryCharacterStringName(i);
                string desc = GameManager.instance.Data.GetInventoryCharacterDescription(i);
                Sprite imageSprite = GameManager.instance.Data.GetInventoryCharacterSpriteIcon(i);
                int hp = GameManager.instance.Data.GetInventoryCharacterBaseHp(i);
                int mp = GameManager.instance.Data.GetInventoryCharacterBaseMp(i);
                int exp = GameManager.instance.Data.GetInventoryCharacterCurRoleExp(i);

                // Allow infinite equipping of empty.
                if (i == 0)
                    isEquipped = false;

                // Initialize button info.
                lcb.Init(isEquipped, charName, desc, imageSprite, 1, hp, mp, exp, 100);

                // Set button behaviour.
                int j = i;
                lcb.selectButton.onClick.AddListener(delegate
                {
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
}
