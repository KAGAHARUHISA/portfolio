using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject PUSH_MANAGER;
    public GameObject AimTimeText;

    void Start()
    {
        PUSH_MANAGER.SetActive(false);
        StartCoroutine(CanPush());
        StartCoroutine(AimView());
    }

    IEnumerator CanPush()
    {
        yield return new WaitForSeconds(6);
        PUSH_MANAGER.SetActive(true);
    }

    IEnumerator AimView()
    {
        yield return new WaitForSeconds(3);
        AimTimeText.SetActive(true);
    }
}
