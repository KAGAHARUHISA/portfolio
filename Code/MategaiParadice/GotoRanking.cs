using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoRanking : MonoBehaviour
{
    public void Ranking()
    {
        SceneManager.LoadScene("RankingScene");
    }
}
