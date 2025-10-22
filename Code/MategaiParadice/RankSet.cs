using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankSet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RankManegement maneger; 
        GameObject rank = GameObject.Find("RankManeger"); 
        maneger= rank.GetComponent<RankManegement>(); 

        if(maneger.isEasy == true)
        {
            EasyRankSet();
        }
        else
        {
            HardRankSet();
        }


        PlayerPrefs.Save();
    }

    public void HardRankSet()
    {
        if (PlayerPrefs.HasKey("No1"))
        {
            Debug.Log("一位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("No1", 0);
        }

        if (PlayerPrefs.HasKey("No2"))
        {
            Debug.Log("二位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("No2", 0);
        }

        if (PlayerPrefs.HasKey("No3"))
        {
            Debug.Log("三位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("No3", 0);
        }

        if (PlayerPrefs.HasKey("No4"))
        {
            Debug.Log("四位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("No4", 0);
        }

        if (PlayerPrefs.HasKey("No5"))
        {
            Debug.Log("五位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("No5", 0);
        }
    }

    public void EasyRankSet()
    {
        if (PlayerPrefs.HasKey("EasyNo1"))
        {
            Debug.Log("Easy一位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("EasyNo1", 0);
        }

        if (PlayerPrefs.HasKey("EasyNo2"))
        {
            Debug.Log("Easy二位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("EasyNo2", 0);
        }

        if (PlayerPrefs.HasKey("EasyNo3"))
        {
            Debug.Log("Easy三位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("EasyNo3", 0);
        }

        if (PlayerPrefs.HasKey("EasyNo4"))
        {
            Debug.Log("Easy四位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("EasyNo4", 0);
        }

        if (PlayerPrefs.HasKey("EasyNo5"))
        {
            Debug.Log("Easy五位をセット");
        }
        else
        {
            PlayerPrefs.SetFloat("EasyNo5", 0);
        }
    }

}
