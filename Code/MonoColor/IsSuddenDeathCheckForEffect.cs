using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsSuddenDeathCheckForEffect : MonoBehaviour
{
    public bool isSuddenDeath = false;
    void Start()
    {
        StartCoroutine(ChangeSuddenDeath());
    }

    IEnumerator ChangeSuddenDeath()
    {
        yield return new WaitForSeconds(60);
        isSuddenDeath = true;
    }
}
