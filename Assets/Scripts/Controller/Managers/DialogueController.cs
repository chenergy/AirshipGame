using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]
public class DialogueText
{
    public string text;
    public Sprite sprite;

    public DialogueText(string text, Sprite sprite)
    {
        this.text = text;
        this.sprite = sprite;
    }
}


/*[System.Serializable]
public class FighterIcons
{
    public Sprite FIGHTER_BEET;
    public Sprite FIGHTER_DFRUIT;
    public Sprite FIGHTER_LEEK;
    public Sprite FIGHTER_MUSHROOM;
    public Sprite FIGHTER_PEAPOD;
    public Sprite FIGHTER_PEPPER;
    public Sprite FIGHTER_POTATO;
    public Sprite FIGHTER_RADDISH;
}*/


public class DialogueController : MonoBehaviour
{
    public GameObject canvasParent;
    //public FighterIcons fighterIcons;
    public float speed = 1.0f;
    public GameObject nextButton;
    public Image backgroundBox;
    //public Image backgroundBoxP2;
    public Image speakerImage;
    //public Image speakerImageP2;
    public Text targetDialogueText;

    private DialogueText[] dialogueText;
    private int textIndex = 0;
    private string currentText;

    public delegate void DialogueEvent();
    public event DialogueEvent OnDialogueSequenceEnd;

    //public static DialogueController instance;


    /*void Awake()
    {
        if (instance == null)
        {
            this.currentText = "";
            this.nextButton.SetActive(false);
            this.canvasParent.SetActive(false);

            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
    }*/

    void Start()
    {
        this.currentText = "";
        this.nextButton.SetActive(false);
        this.canvasParent.SetActive(false);
    }


    // Called by ingamecontroller to start.
    public void StartSequence(DialogueText[] cDialogue)
    {
        this.dialogueText = cDialogue;

        //this.gameObject.SetActive (true);
        this.canvasParent.SetActive(true);

        this.textIndex = 0;
        this.currentText = "";

        //StartCoroutine ("SetCharacterSprites");
        StartCoroutine("PlayTextSequence", this.dialogueText[this.textIndex]);
    }


    // Button callback funtions
    public void ButtonTouchNext()
    {
        this.GoToNextText();
        this.nextButton.SetActive(false);
    }


    public void ButtonTouchFastEnd()
    {
        this.currentText = this.dialogueText[this.textIndex].text;
        this.targetDialogueText.text = this.currentText;
        this.nextButton.SetActive(true);
        StopCoroutine("PlayTextSequence");
    }


    private void EndSequence()
    {
        //StopCoroutine ("SetCharacterSprites");
        StopCoroutine("PlayTextSequence");

        //this.gameObject.SetActive (false);
        this.canvasParent.SetActive(false);
    }


    // Play next text sequence or quit
    private void GoToNextText()
    {
        this.textIndex++;
        this.currentText = "";

        // Exit if end of dialogue
        if (this.textIndex >= this.dialogueText.Length)
        {
            this.speakerImage.gameObject.SetActive(false);
            //this.speakerImageP2.gameObject.SetActive(false);
            this.EndSequence();
            //GameManager.InGameController.PassFromDialogue ();
            if (this.OnDialogueSequenceEnd != null)
                this.OnDialogueSequenceEnd();
        }
        else
        {
            StartCoroutine("PlayTextSequence", this.dialogueText[this.textIndex]);
        }
    }


    // Play a given sequence
    IEnumerator PlayTextSequence(DialogueText dialogue)
    {
        int nextCharInput = 0;

        // Activate the triangle depending on the speaker
        //this.speakerImageP1.sprite = this.fighterIconDict[dialogue.iconName];
        this.speakerImage.sprite = dialogue.sprite;
        StartCoroutine("MoveInCharacter");
        this.backgroundBox.gameObject.SetActive(true);
        //this.backgroundBoxP2.gameObject.SetActive(false);

        while (this.currentText != dialogue.text)
        {
            yield return new WaitForEndOfFrame();

            // Add chars to finalText based on ceil(speed)
            for (int i = 0; i < this.speed; i++)
            {
                if (nextCharInput < dialogue.text.Length)
                {
                    this.currentText += dialogue.text[nextCharInput];
                    nextCharInput++;
                }
            }

            this.targetDialogueText.text = this.currentText;
        }

        // Activate next text segment
        //this.nextButton.SetActive(true);
        float timeDelay = 1.0f;
        float timer = 0.0f;

        while (timer < timeDelay)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

        this.GoToNextText();
    }


    IEnumerator MoveInCharacter()
    {
        float timer = 0.0f;
        float duration = 1.0f;

        // Change both sprite transparencies over time
        while (timer < duration)
        {
            timer += Time.deltaTime;

            this.speakerImage.color = new Color(this.speakerImage.color.r, this.speakerImage.color.g, this.speakerImage.color.b, (timer / duration));

            yield return new WaitForEndOfFrame();
        }
    }
}

