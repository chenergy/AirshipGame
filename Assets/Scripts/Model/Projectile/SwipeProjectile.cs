using UnityEngine;
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

    private List<Enemy> hitColliders = new List<Enemy>();

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


    void OnTriggerEnter(Collider other)
    {
        Enemy e = other.GetComponent<Enemy>();
        if (e != null)
        {
            if (!this.hitColliders.Contains(e))
            {
                this.hitColliders.Add(e);
                e.TakeDamage(this.damage);
            }
        }
    }
}

