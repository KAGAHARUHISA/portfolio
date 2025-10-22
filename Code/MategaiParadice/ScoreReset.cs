using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreReset : MonoBehaviour
{

    private bool Easy;
    // Start is called before the first frame update
    void Start()
    {
        RankManegement maneger;
        GameObject rank = GameObject.Find("RankManeger");
        maneger = rank.GetComponent<RankManegement>();
        Easy = maneger.isEasy;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P) && Easy == true)
        {
            PlayerPrefs.DeleteKey("EasyNo1");
            PlayerPrefs.DeleteKey("EasyNo2");
            PlayerPrefs.DeleteKey("EasyNo3");
            PlayerPrefs.DeleteKey("EasyNo4");
            PlayerPrefs.DeleteKey("EasyNo5");
        }

        if (Input.GetKeyUp(KeyCode.P) && Easy == false)
        {
            PlayerPrefs.DeleteKey("No1");
            PlayerPrefs.DeleteKey("No2");
            PlayerPrefs.DeleteKey("No3");
            PlayerPrefs.DeleteKey("No4");
            PlayerPrefs.DeleteKey("No5");
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            PlayerPrefs.DeleteAll();
        }

    }
}
