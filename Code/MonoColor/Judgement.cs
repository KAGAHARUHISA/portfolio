using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    // 　勝者の領土の割合を格納する変数
    public static int WINNER_LAND_PERCENT;

    public static Judgement _instance { get; private set; }

    //  勝者の領土を詰め込むリスト
    List<GameObject> WINNER_LAND = new List<GameObject>();

    //  リストの要素数を格納する変数
    float LIST_NUMBER;
    private bool isGameOver = false; //追加

    void Start()
    {
        //isGameOver = true;    
    }
    private void Awake()
    {
        //シングルトンの設定
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Player1_Win()
    {
        if (isGameOver) return;
        isGameOver = true; //とりあえずここを無駄に呼ばないように処理をせき止める
        // プレイヤー1の領土を全て格納する
        WINNER_LAND.AddRange(GameObject.FindGameObjectsWithTag("Player1Land"));

        //  パーセンテージの算出
        LIST_NUMBER = WINNER_LAND.Count;
        WINNER_LAND_PERCENT = Mathf.RoundToInt((LIST_NUMBER / 2304) * 100 );
        PlayerPrefs.SetInt("WinnerLandScore", WINNER_LAND_PERCENT);
        PlayerPrefs.Save();
    }

    public void Player2_Win() 
    {
        if (isGameOver) return;
        isGameOver = true;//こっちも同じ
        // プレイヤー2の領土を全て格納する
        WINNER_LAND.AddRange(GameObject.FindGameObjectsWithTag("Player2Land"));

        //  パーセンテージの算出
        LIST_NUMBER = WINNER_LAND.Count;
        WINNER_LAND_PERCENT = Mathf.RoundToInt((LIST_NUMBER / 2304) * 100);
        PlayerPrefs.SetInt("WinnerLandScore", WINNER_LAND_PERCENT);
        PlayerPrefs.Save();
    }
}
