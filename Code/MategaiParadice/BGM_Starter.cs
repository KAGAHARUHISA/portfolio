using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Starter : MonoBehaviour
{
    public AudioSource Fever;

    void Start()
    {
        StartCoroutine(StartBGM());
    }

    IEnumerator StartBGM()
    {
        yield return new WaitForSeconds(60);
        Fever.Play();
    }
}
