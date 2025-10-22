using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Stoper : MonoBehaviour
{
    public AudioSource Normal;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StopBGM());
    }

    IEnumerator StopBGM()
    {
        yield return new WaitForSeconds(60);
        Normal.Stop();
    }

}
