using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public float score_point = 0;
    public Text Scoretext;
    public static float score = 0;
    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Scoretext.text = "" + score_point;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "" + score_point;
        if(score != score_point && score_point != 0)
        {
            audioSource.PlayOneShot(sound1);
        }
        score = score_point;
    }
}
