using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof (Collider))]
public class Enemy : MonoBehaviour
{
	public GameObject model;
	public float baseSpeed = 1.0f;
	public int hp = 10;
	public float agroRadius = 5.0f;
	public Image hpImage;
	
	private float speed = 0.0f;
	private int baseHp = 10;
	private Collider baseCollider;
	private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
		this.startPos = this.transform.position;
		this.baseCollider = this.GetComponent <Collider> ();
		this.speed = this.baseSpeed;
		this.hp = this.baseHp;
		this.hpImage.fillAmount = 1.0f;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameManager.instance.InGameController.airship != null) {
			Vector3 moveDir = GameManager.instance.InGameController.airship.transform.position - this.transform.position;
			this.transform.position += moveDir.normalized * this.speed * Time.deltaTime;
			this.model.transform.LookAt (GameManager.instance.InGameController.airship.transform.position);
		}
	}


	public void TakeDamage (int damage){
		this.hp -= damage;
		this.hpImage.fillAmount = (1.0f * this.hp / this.baseHp);

		if (this.hp <= 0)
			GameObject.Destroy (this.gameObject);
	}
}

