using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Easy_or_Hard : MonoBehaviour
{

    public GameObject Easy;
    public GameObject Hard;
    public GameObject Start;
    public GameObject Rank;
    // Start is called before the first frame update
   public void GotoEasy()
    {
        SceneManager.LoadScene("HowToPlay_Easy");
    }

    public void GotoHard()
    {
        RankManegement maneger;
        GameObject rank = GameObject.Find("RankManeger");
        maneger = rank.GetComponent<RankManegement>();
        maneger.isEasy = false;
        SceneManager.LoadScene("HowToPlay");
    }
   
    public void GoBack()
    {
        Easy.SetActive(false);
        Hard.SetActive(false);
        Start.SetActive(true);
        Rank.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
