using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Airship_Enemy : A_Airship
{
	public int baseHp = 10;
	//public float agroDist = 5.0f;
	public Image hpImage;
    public A_EnemyBehaviour behaviour;

	private int curHp = 10;
	private A_Ability ability;
    public A_Ability Ability
    {
        get { return this.ability; }
    }
	//private float targetCd;
	//private float curCd;
	

	// Use this for initialization
	protected override void Start ()
	{
		base.Start ();

		this.curHp = this.baseHp;
		this.hpImage.fillAmount = 1.0f;

		this.ability = GameManager.instance.Data.CloneAbility (GameEnum.AbilityName.ABILITY_AUTOBULLET, this);
		//this.targetCd = this.ability.Cooldown;
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();

		// Perform ability.
		//this.curCd += Time.deltaTime;

		//this.CheckAgro ();
	}


	//void OnDrawGizmosSelected (){
		//Gizmos.DrawSphere (this.startPos, 1.0f);
		//Gizmos.DrawWireSphere (this.transform.position, this.agroDist);
	//}

	
	public override void TakeDamage (int position, int damage){
		this.curHp -= damage;
		this.hpImage.fillAmount = (1.0f * this.curHp / this.baseHp);
		this.behaviour.SetPlayerDetected (true);
		
		if (this.curHp <= 0)
			GameObject.Destroy (this.gameObject);
	}
}

