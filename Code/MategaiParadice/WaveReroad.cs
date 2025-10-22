using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveReroad : MonoBehaviour
{
    public GameObject No2Wave;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaveNo2());   
    }

    IEnumerator WaveNo2()
    {
        yield return new WaitForSeconds(61);
        No2Wave.SetActive(true);
        StartCoroutine(Reroad_to_false());
    }

    private void WaveReroad_true()
    {
        StartCoroutine(Reroad_to_true());
    }

    private void WaveReroad_false()
    {
        StartCoroutine(Reroad_to_false());
    }

    IEnumerator Reroad_to_true()
    {
        yield return new WaitForSeconds(0.5f);
        No2Wave.SetActive(true);
        WaveReroad_false();
    }

    IEnumerator Reroad_to_false()
    {
        yield return new WaitForSeconds(0.5f);
        No2Wave.SetActive(false);
        WaveReroad_true();
    }

}
