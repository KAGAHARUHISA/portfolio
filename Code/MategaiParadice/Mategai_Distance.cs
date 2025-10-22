using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mategai_Distance : MonoBehaviour
{

    private float tmpTime = 0;
    private bool get = false;
    private bool CLICK = false;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpTime += Time.deltaTime;
        var colliderTest = GetComponent<Collider2D>();

        if (tmpTime >= 0.8 && 1.4 >= tmpTime)
        {
            colliderTest.enabled = true;
            get = true;

        }
        else
        {
            colliderTest.enabled = false;
            get = false;
        }

        if (tmpTime >= 1.5 && !CLICK)
        {
            tmpTime = 0;
            Destroy(this.gameObject);
        }

        if (CLICK)
        {
            colliderTest.enabled = false;
            StartCoroutine(Destoroy());
        }

    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (get == true)
            {
                anim.SetTrigger("Get");
                Score score;
                GameObject obj = GameObject.Find("SCORE");
                score = obj.GetComponent<Score>();
                score.score_point += 1f;
                CLICK = true;

            }

        }

    }

    IEnumerator Destoroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}