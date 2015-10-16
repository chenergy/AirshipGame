﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwipeProjectile : MonoBehaviour
{
    public Collider swipeCollider;
    public float speed = 1.0f;
    public int damage = 1;
    public float lifetime = 3.0f;
    public float delay = 0.0f;

    private Vector3 direction;
    private float timer = 0.0f;
    private float curAngle = 0.0f;
    private float targetAngle = 0.0f;
	private A_Airship owner;

	private List<A_Airship> hitColliders = new List<A_Airship>();

    // Use this for initialization
    void Start()
    {
        GameObject.Destroy(this.gameObject, this.lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += this.direction * this.speed * Time.deltaTime;
        if (this.timer > this.delay)
        {
            if (this.curAngle < this.targetAngle)
                this.curAngle += this.speed * Time.deltaTime;
            else
                this.curAngle = this.targetAngle;

            this.swipeCollider.transform.localRotation = Quaternion.Euler(0.0f, (-this.targetAngle / 2) + this.curAngle, 0.0f);
        }

        this.timer += Time.deltaTime;
    }


    /*public void SetDirection(Vector3 dir)
    {
        this.direction = dir;
    }*/

    public void SetAngle(float degrees)
    {
        this.targetAngle = degrees;
        this.swipeCollider.transform.Rotate(0.0f, -degrees / 2, 0.0f);
    }

	public void SetOwner (A_Airship owner){
		this.owner = owner;
	}


    void OnTriggerEnter(Collider other)
    {
		A_Airship a = other.GetComponent<A_Airship>();
        if (a != null)
        {
            if (!this.hitColliders.Contains(a))
            {
                this.hitColliders.Add(a);
                //e.TakeDamage(this.damage);
            }
        }
    }
}

