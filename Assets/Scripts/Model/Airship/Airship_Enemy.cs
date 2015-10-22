using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//[RequireComponent (typeof (Collider))]
public class Airship_Enemy : A_Airship
{
	/*public GameObject model;
	public float baseSpeed = 1.0f;
	public int hp = 10;
	public float agroRadius = 5.0f;
	public Image hpImage;
	
	private float speed = 0.0f;
	private int baseHp = 10;
	private Collider baseCollider;
	private Vector3 startPos;*/

	//public float baseSpeed = 1.0f;
	public int baseHp = 10;
	public float agroDist = 5.0f;
	public Image hpImage;

	private int curHp = 10;
	//private float curSpeed = 0.0f;
	private A_Ability ability;
	private float targetCd;
	private float curCd;
	private Vector3 startPos;

	// Use this for initialization
	protected override void Start ()
	{
		base.Start ();

		this.startPos = this.transform.position;
		//this.baseCollider = this.GetComponent <Collider> ();
		//this.curSpeed = this.baseSpeed;
		this.curHp = this.baseHp;
		this.hpImage.fillAmount = 1.0f;

		this.ability = GameManager.instance.Data.CloneAbility (GameEnum.AbilityName.ABILITY_AUTOBULLET, this);
		this.targetCd = this.ability.Cooldown;
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();

		// Perform ability.
		this.curCd += Time.deltaTime;

		if (this.curCd > this.targetCd * 10) {
			this.curCd = 0;
			this.ability.Use (Vector3.zero);
		}

		this.CheckAgro ();

		/*
		if (GameManager.instance.InGameController.airship != null) {
			Vector3 moveDir = GameManager.instance.InGameController.airship.transform.position - this.transform.position;
			this.transform.position += moveDir.normalized * this.curSpeed * Time.deltaTime;
			this.model.transform.LookAt (GameManager.instance.InGameController.airship.transform.position);
		}
		*/
		//this.headingDirection = (GameManager.instance.InGameController.airship.transform.position - this.transform.position).normalized;
	}


	void OnDrawGizmosSelected (){
		Gizmos.DrawSphere (this.startPos, 1.0f);
		Gizmos.DrawWireSphere (this.transform.position, this.agroDist);
	}

	
	public override void TakeDamage (int position, int damage){
		this.curHp -= damage;
		this.hpImage.fillAmount = (1.0f * this.curHp / this.baseHp);
		
		if (this.curHp <= 0)
			GameObject.Destroy (this.gameObject);
	}


	private void CheckAgro (){
		float playerDist = (this.transform.position - GameManager.instance.InGameController.airship.transform.position).magnitude;

		if (playerDist < this.agroDist) {
			this.SetSpeed (1.0f);
			this.headingDirection = (GameManager.instance.InGameController.airship.transform.position - this.transform.position).normalized;
		} else {
			if ((this.startPos - this.transform.position).magnitude > 1.0f) {
				this.headingDirection = (this.startPos - this.transform.position).normalized;
				this.SetSpeed (1.0f);
			} else {
				this.SetSpeed (0.0f);
			}
		}
		//return (this.transform.position - GameManager.instance.InGameController.airship.transform.position
	}
}

