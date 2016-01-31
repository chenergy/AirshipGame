using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Airship_Enemy : A_Airship
{
    public GameEnum.EnemyName enemyName;
	public int baseHp = 10;
    public int expReward = 10;
	//public float agroDist = 5.0f;
	public Image hpImage;
    public A_EnemyBehaviour behaviour;
	public GameEnum.AbilityName abilityName;
	public GameObject m_deathParticle;

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

		this.ability = GameManager.instance.Data.CloneAbility (this.abilityName, this);
	}
	
	// Update is called once per frame
	protected override void Update ()
	{
		base.Update ();
	}



    public override void TakeDamage (int position, int damage){
		this.curHp -= damage;
		this.hpImage.fillAmount = (1.0f * this.curHp / this.baseHp);
		this.behaviour.SetPlayerDetected (true);

        if (this.curHp <= 0)
        {
            //GameManager.instance.InGameController.mc.TriggerObjectiveCondition(GameEnum.ObjectiveCondition.KILL_ENEMY, this.enemyName.ToString());
            GameManager.instance.InGameController.AddExp(this.expReward);

			if (m_deathParticle != null) {
				GameObject newParticle = GameObject.Instantiate (m_deathParticle, this.transform.position, Quaternion.identity) as GameObject;
				GameObject.Destroy (newParticle, 1.0f);
			}

            GameObject.Destroy(this.gameObject);
        }
	}
}

