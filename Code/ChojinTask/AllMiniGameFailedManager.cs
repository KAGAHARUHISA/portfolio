using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMiniGameFailedManager : MonoBehaviour
{

    public static int FAILED_TIME = 4;
    // Start is called before the first frame update
    void Start()
    {
        FAILED_TIME = 0;
    }

    //  ���s�����񐔂̃J�E���g
    public void AddPoint()
    {
        FAILED_TIME ++;
    }
}
