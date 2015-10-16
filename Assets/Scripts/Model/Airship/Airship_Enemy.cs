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
	public float agroRadius = 5.0f;
	public Image hpImage;

	private int curHp = 10;
	//private float curSpeed = 0.0f;

	// Use this for initialization
	protected override void Start ()
	{
		base.Start ();
		/*this.startPos = this.transform.position;
		this.baseCollider = this.GetComponent <Collider> ();*/
		//this.curSpeed = this.baseSpeed;
		this.curHp = this.baseHp;
		this.hpImage.fillAmount = 1.0f;
		this.UpdateSpeed (1.0f);
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();
		/*
		if (GameManager.instance.InGameController.airship != null) {
			Vector3 moveDir = GameManager.instance.InGameController.airship.transform.position - this.transform.position;
			this.transform.position += moveDir.normalized * this.curSpeed * Time.deltaTime;
			this.model.transform.LookAt (GameManager.instance.InGameController.airship.transform.position);
		}
		*/
		this.headingDirection = (GameManager.instance.InGameController.airship.transform.position - this.transform.position).normalized;
	}
	
	
	public void TakeDamage (int damage){
		this.curHp -= damage;
		this.hpImage.fillAmount = (1.0f * this.curHp / this.baseHp);
		
		if (this.curHp <= 0)
			GameObject.Destroy (this.gameObject);
	}
}

