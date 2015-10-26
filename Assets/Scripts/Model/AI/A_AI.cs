using UnityEngine;
using System.Collections;

public abstract class A_AI : MonoBehaviour
{
    /*
    protected A_BTNode root;
    protected bool isWaiting = false;

    // Use this for initialization
    void Start()
    {
        this.InitAI();
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.isWaiting)
        {
            this.root.Execute();
        }

        this.root.Reset();
    }

    public void Wait(float time)
    {
        this.isWaiting = true;
        StopCoroutine("WaitRoutine");
        StartCoroutine("WaitRoutine", time);
    }

    IEnumerator WaitRoutine(float delay)
    {
        float timer = 0.0f;
        this.isWaiting = true;

        while (timer < delay)
        {
            yield return new WaitForEndOfFrame();
            timer += Time.deltaTime;
        }

        this.isWaiting = false;
    }
    */

    protected abstract void InitAI();
}
