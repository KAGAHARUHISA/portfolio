using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManegement : MonoBehaviour
{

    public bool isEasy = true;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

}
