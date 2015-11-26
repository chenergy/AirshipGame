using UnityEngine;
using System.Collections;

public class InGameController : MonoBehaviour
{
	public PartyMenuController pmc;
    public CameraMovement cm;
	public MissionController mc;
    public DialogueController dc;

	public ErrorLog errorLog;
    public Transform playerStartPoint;

	public GameObject moveTargetGobj;
	public SkillTip_Straight skillTipStraight;
	public SkillTip_TargetPointerAOE skillTipTargetAOE;
	public SkillTip_TargetAirshipAOE skillTipAirshipAOE;

	private PartyCharacter[] charactersInAirship;
    private PartyCharacter[] charactersStandbyInAirship;
	private int activatedCharNum = -1;
	private Bounds bounds;

    private Airship_Player airship;
    public Airship_Player Airship
    {
        get { return this.airship; }
    }


    // Use this for initialization
    void Start ()
	{
		GameManager.instance.InGameController = this;

        // Get the airship prefab from scriptable.
        GameObject gobj = GameManager.instance.Data.GetCurrentAirshipPrefab(GameManager.instance.Data.GetCurrentAirshipName());
        if (gobj != null)
            this.airship = (GameObject.Instantiate (gobj, this.playerStartPoint.position, Quaternion.identity) as GameObject).GetComponent<Airship_Player>();

        if (this.airship == null)
            Debug.Log("airship not found");
        else
            this.cm.SetTarget(this.airship.transform);

        // Disable move target gobj.
        this.moveTargetGobj.SetActive (false);

        // Initialize boundaries.
		this.bounds = new Bounds (Vector3.zero, new Vector3 (95f, 0, 95f));

        // Get characters that are currently in airship.
        this.charactersInAirship = new PartyCharacter[GameManager.instance.Data.GetCharactersInAirship().Length];
        for (int i = 0; i < this.charactersInAirship.Length; i++)
        {
            int inventoryNum = GameManager.instance.Data.GetCharactersInAirship()[i];
            
            // Create character.
            PartyCharacter c = this.CreateNewPartyCharacter(inventoryNum);

            // Assign character and ability to visual component.
            this.pmc.SetPartyCharacter(c, i);
            this.charactersInAirship[i] = c;
        }

        // Get characters on standby in the airship.
        this.charactersStandbyInAirship = new PartyCharacter[GameManager.instance.Data.GetCharactersStandbyInAirship().Length];
        for (int i = 0; i < this.charactersStandbyInAirship.Length; i++)
        {
            int inventoryNum = GameManager.instance.Data.GetCharactersStandbyInAirship()[i];

            // Create character.
            PartyCharacter c = this.CreateNewPartyCharacter(inventoryNum);

            // Store in standby array.
            this.charactersStandbyInAirship[i] = c;
        }
			
        this.mc.SetMission (GameManager.instance.Data.GetCurrentMission ());

		//this.SwapCharacters (0, false, 0, true);
		//this.SwapCharacters (0, false, 0, true);
	}


    private PartyCharacter CreateNewPartyCharacter (int inventoryNum)
    {
        PartyCharacter c = new PartyCharacter(GameManager.instance.Data.GetInventoryCharacterSpriteIcon(inventoryNum),
            GameManager.instance.Data.GetInventoryCharacterStringName(inventoryNum),
            GameManager.instance.Data.GetInventoryCharacterBaseHp(inventoryNum),
            GameManager.instance.Data.GetInventoryCharacterBaseMp(inventoryNum),
            GameManager.instance.Data.GetInventoryCharacterCurHp(inventoryNum),
            GameManager.instance.Data.GetInventoryCharacterCurMp(inventoryNum));

		// Create the ability and assign to the character.
		GameEnum.AbilityName abilityName = GameManager.instance.Data.GetInventoryCharacterAbilityName(inventoryNum);
		c.SetAbility(GameManager.instance.Data.CloneAbility(abilityName, airship));

        return c;
    }
	

	// Update is called once per frame
	//void Update ()
	//{
		//this.KeepAirshipInBounds ();
	//}


	private void KeepAirshipInBounds (){
		if (this.airship != null) {
			if (this.airship.transform.position.x > this.bounds.max.x)
				this.airship.transform.position = new Vector3 (this.bounds.max.x, this.airship.transform.position.y, this.airship.transform.position.z);
			if (this.airship.transform.position.x < this.bounds.min.x)
				this.airship.transform.position = new Vector3 (this.bounds.min.x, this.airship.transform.position.y, this.airship.transform.position.z);
			if (this.airship.transform.position.z > this.bounds.max.z)
				this.airship.transform.position = new Vector3 (this.airship.transform.position.x, this.airship.transform.position.y, this.bounds.max.z);
			if (this.airship.transform.position.z < this.bounds.min.z)
				this.airship.transform.position = new Vector3 (this.airship.transform.position.x, this.airship.transform.position.y, this.bounds.min.z);
		}
	}


	public void ActivateAbility (int charNum) {
		if (charNum < this.charactersInAirship.Length) {
			PartyCharacter c = this.charactersInAirship [charNum];

			if (c.CanUseAbility()) {
				// Set the activated character number.
				this.activatedCharNum = charNum;

                // Activate the character's ability to be used.
                this.charactersInAirship[charNum].ActivateAbility();
            }
		}
	}


	public void UseAbility (Vector3 target) {
		if ((this.activatedCharNum != -1) && (this.activatedCharNum < this.charactersInAirship.Length)) {
			if (this.charactersInAirship[this.activatedCharNum].CanUseAbility()) {
				// Stop showing the skilltip.
				this.skillTipTargetAOE.Disable ();
				this.skillTipStraight.Disable ();
				this.skillTipAirshipAOE.Disable ();

				// Use the character's ability.
				this.charactersInAirship[this.activatedCharNum].UseAbility (target);

				// Recharge the cooldown timer for target character.
				//this.StartCoroutine ("StartCooldownTimer", this.activatedCharNum);
				this.pmc.partyCharacters [this.activatedCharNum].RechargeCooldown ();
				this.pmc.partyCharacters [this.activatedCharNum].RechargeMana ();

				// Reset the activated character number.
				this.activatedCharNum = -1;
			}
		}
	}


	public void CharacterTakeDamage (int position, int damage){
		if (position < this.charactersInAirship.Length) {
			Debug.Log (string.Format ("{0} took {1} damage in location {2}",
				this.charactersInAirship [position].Name,
				damage.ToString (),
				position.ToString ()));

			this.charactersInAirship [position].TakeDamage (damage);

			if (this.charactersInAirship [position].CurHp <= 0) {
				Debug.Log (this.charactersInAirship [position].Name + " is dead.");
			}

			this.pmc.partyCharacters [position].UpdateCurHp ();
		}
	}


    public void EnableSkillTip (GameEnum.SkillTipType skillTip, float range)
    {
        // Showing the skilltip.
		if (skillTip == GameEnum.SkillTipType.SKILL_STRAIGHT) {
			//this.skillTipTargetAOE.Enable (10.0f);
			this.skillTipStraight.Enable (range);
			this.skillTipTargetAOE.Disable ();
			this.skillTipAirshipAOE.Disable ();
		} else if (skillTip == GameEnum.SkillTipType.SKILL_TARGET_POINTER_AOE) {
			this.skillTipStraight.Disable ();
			this.skillTipTargetAOE.Enable (range);
			this.skillTipAirshipAOE.Disable ();
		} else if (skillTip == GameEnum.SkillTipType.SKILL_TARGET_AIRSHIP_AOE) {
			this.skillTipStraight.Disable ();
			this.skillTipTargetAOE.Disable ();
			this.skillTipAirshipAOE.Enable (range);
		}
    }

	// Input for steering and rotation.
	public void SetRotationAirship (float degrees){
		this.airship.SetRotation (degrees);
	}

	public void AddRotationAirship (float degrees){
		this.airship.AddRotation (degrees);
	}

    public void SetHeadingAirshipAdjusted(Vector3 direction)
    {
        this.airship.SetHeadingAdjusted(direction);
    }

	public void SetAirshipTarget (Vector3 target){
		this.moveTargetGobj.SetActive (true);
		this.moveTargetGobj.transform.position = target;
		this.airship.SetMoveTarget (target);
	}

	public void StopAirshipMovingToTarget (){
		this.moveTargetGobj.SetActive (false);
		this.airship.StopMovingToTarget ();
	}


	// Start and End routines for airship rotation.
	public void StartRotateAirship (){
		this.airship.StartRotate ();
	}

	public void EndRotateAirship (){
        this.airship.EndRotate ();
	}


	// Dialogue System trigger.
	public void StartDialogueSequence (DialogueText[] dialogue){
		if (dialogue != null)
			this.dc.StartSequence (dialogue);
	}


    // In game menu options.
    public void SwapCharacters(int partyIndex0, bool onStandby0, int partyIndex1, bool onStandby1)
    {
        PartyCharacter temp;

        if (onStandby0)
        {
            if (onStandby1)
            {
				Debug.Log (string.Format ("beforeswap 0: {0} | 1:{1}", 
					this.charactersStandbyInAirship [partyIndex0].Name,
					this.charactersStandbyInAirship [partyIndex1].Name));
				
                temp = this.charactersStandbyInAirship[partyIndex0];
                this.charactersStandbyInAirship[partyIndex0] = this.charactersStandbyInAirship[partyIndex1];
                this.charactersStandbyInAirship[partyIndex1] = temp;

				Debug.Log (string.Format ("afterswap 0: {0} | 1:{1}", 
					this.charactersStandbyInAirship [partyIndex0].Name,
					this.charactersStandbyInAirship [partyIndex1].Name));
            }
            else
            {
				Debug.Log (string.Format ("beforeswap 0: {0} | 1:{1}", 
					this.charactersStandbyInAirship [partyIndex0].Name,
					this.charactersInAirship [partyIndex1].Name));

                temp = this.charactersStandbyInAirship[partyIndex0];
                this.charactersStandbyInAirship[partyIndex0] = this.charactersInAirship[partyIndex1];
                this.charactersInAirship[partyIndex1] = temp;
				this.pmc.SetPartyCharacter (this.charactersInAirship [partyIndex1], partyIndex1);

				Debug.Log (string.Format ("afterswap 0: {0} | 1:{1}", 
					this.charactersStandbyInAirship [partyIndex0].Name,
					this.charactersInAirship [partyIndex1].Name));
            }
        } else
        {
            if (onStandby1)
            {
				Debug.Log (string.Format ("beforeswap 0: {0} | 1:{1}", 
					this.charactersInAirship [partyIndex0].Name,
					this.charactersStandbyInAirship [partyIndex1].Name));
				
                temp = this.charactersInAirship[partyIndex0];
                this.charactersInAirship[partyIndex0] = this.charactersStandbyInAirship[partyIndex1];
                this.charactersStandbyInAirship[partyIndex1] = temp;
				this.pmc.SetPartyCharacter (this.charactersInAirship [partyIndex0], partyIndex0);

				Debug.Log (string.Format ("afterswap 0: {0} | 1:{1}", 
					this.charactersInAirship [partyIndex0].Name,
					this.charactersStandbyInAirship [partyIndex1].Name));
            }
            else
            {
				Debug.Log (string.Format ("beforeswap 0: {0} | 1:{1}", 
					this.charactersInAirship [partyIndex0].Name,
					this.charactersInAirship [partyIndex1].Name));

                temp = this.charactersInAirship[partyIndex0];
                this.charactersInAirship[partyIndex0] = this.charactersInAirship[partyIndex1];
                this.charactersInAirship[partyIndex1] = temp;
				this.pmc.SetPartyCharacter (this.charactersInAirship [partyIndex0], partyIndex0);
				this.pmc.SetPartyCharacter (this.charactersInAirship [partyIndex1], partyIndex1);

				Debug.Log (string.Format ("afterswap 0: {0} | 1:{1}", 
					this.charactersInAirship [partyIndex0].Name,
					this.charactersInAirship [partyIndex1].Name));
            }
        }

        // Create the ability and assign to the character.
        /*GameEnum.AbilityName abilityName = GameManager.instance.Data.GetInventoryCharacterAbilityName(inventoryNum);
        c.SetAbility(GameManager.instance.Data.CloneAbility(abilityName, airship));

        // Assign character and ability to visual component.
        this.pmc.SetPartyCharacter(char0, abilityName, i);*/
    }


	// Temp on-screen buttons.
	public void SetAirshipSpeed (float newSpeed){
		this.airship.SetSpeed (newSpeed);
	}

	public void ReloadScene (){
		Application.LoadLevel ("LoadoutMenu");
	}

    public void Save()
    {
        for (int i = 0; i < this.charactersInAirship.Length; i++)
        {
            GameManager.instance.Data.SetAirshipCharacterCurHp(i, this.charactersInAirship[i].CurHp);
            GameManager.instance.Data.SetAirshipCharacterCurMp(i, this.charactersInAirship[i].CurMp);
        }
        // Save current airship.
        // Save current party members hp and mp.
        // Save current party members exp.

        GameManager.instance.Data.Save();
    }

	public void DeleteSave (){
		System.IO.File.Delete (Application.persistentDataPath + "/savedData.gd");
	}


	public void GoToUpperLevel(){
		this.airship.SetHeightLevel (GameEnum.HeightLevel.UPPER);
	}


	public void GoToLowerLevel (){
		this.airship.SetHeightLevel (GameEnum.HeightLevel.LOWER);
	}

    /*public void OpenMenu()
    {
        this.smc.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        this.smc.gameObject.SetActive(false);
    }*/
}

