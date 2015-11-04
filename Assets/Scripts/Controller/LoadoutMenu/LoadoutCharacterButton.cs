using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadoutCharacterButton : MonoBehaviour
{
    public Button selectButton;
	public Transform equipped;

	public Text charName;
	public Text desc;
    public Image image;
	public Text level;
	public Text hp;
	public Text mp;
	public Image exp;

	public void Init (bool isEquipped, string charName, string desc, Sprite image, int level, int hp, int mp, int curExp, int totalExp) {
		this.charName.text = charName;
		this.desc.text = desc;
		this.image.sprite = image;
		this.level.text = level.ToString ();
		this.hp.text = hp.ToString ();
		this.mp.text = mp.ToString ();
		this.exp.fillAmount = (1.0f * curExp / totalExp);

		if (isEquipped) {
			this.selectButton.interactable = false;
			this.equipped.gameObject.SetActive (true);
		} else {
			this.selectButton.interactable = true;
			this.equipped.gameObject.SetActive (false);
		}
	}


    // Use this for initialization
    /*void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }*/
}
