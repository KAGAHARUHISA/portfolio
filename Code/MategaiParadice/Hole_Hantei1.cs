using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hole_Hantei1 : MonoBehaviour
{
    public Spawner1 spawner1;
    private bool Fever = false;
    private Animator anim;

    void Start()
    {
        StartCoroutine(Bonus());
    }
    // Update is called once per frame
    void Update()
    {
        if (spawner1.S1 == false || Fever)
        {
            gameObject.GetComponent<Image>().color = new Color(0.8f, 0.3f, 0.1f, 0.0f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }

    }
    
    IEnumerator Bonus()
    {
        yield return new WaitForSeconds(60);
        Fever = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wave"))
        {
            Debug.Log("Ç‘Ç¬Ç©Ç¡ÇΩÅI");
        }
    }

}
