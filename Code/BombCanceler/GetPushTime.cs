using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class GetPushTime : MonoBehaviour
{

    //  それぞれのプレイヤーのキー入力までの時間を格納する変数
    float PLAYER1_TIME = 0.0f;
    float PLAYER2_TIME = 0.0f;

    //  それぞれのプレイヤーのキー入力と目標時間の誤差の総和を格納する変数
    public static float PLAYER1_MISSEDTIME = 0.0f;
    public static float PLAYER2_MISSEDTIME = 0.0f;

    //  お題の時間を突っ込む変数
    float AIMTIME = 5.0f;

    //  押したらもう押せなくなるフラグ
    bool PLAYER1_PUSHED = false;
    bool PLAYER2_PUSHED = false;

    // 勝敗が入る変数
    public static string JUDGE = null;

    // STOPのテキストを格納する変数
    public GameObject STOPTEXT_PLAYER1;
    public GameObject STOPTEXT_PLAYER2;

    //  Audio Sourceコンポーネントを格納する変数
    AudioSource PUSH_SE;

    //  ストップボタンを押したときに一部UIを暗くするオブジェクトを格納する変数
    public GameObject PLAYER1PUSHED_SQUARE;
    public GameObject PLAYER1PUSHED_CIRCLE;
    public GameObject PLAYER2PUSHED_SQUARE;
    public GameObject PLAYER2PUSHED_CIRCLE;

    public AudioClip Warning;
    public AudioClip Explode;


    private void Start()
    {
        //  Audio Sourceコンポーネントを取得し格納
        PUSH_SE = GetComponent<AudioSource>();
        //  お題の時間がランダムにする処理を組み込む予定
    }

    void Update()
    {
        PLAYER1_TIME += Time.deltaTime;
        PLAYER2_TIME += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) && !PLAYER1_PUSHED)
        {
            GetMissedTime1();
        }
        else if (PLAYER1_PUSHED && Input.GetKeyUp(KeyCode.A))   //  キーを離したら暗くなるUIは明るくなる
        {
            PLAYER1PUSHED_SQUARE.SetActive(false);
            PLAYER1PUSHED_CIRCLE.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.L) && !PLAYER2_PUSHED)
        {
            GetMissedTime2();
        }
        else if (PLAYER2_PUSHED && Input.GetKeyUp(KeyCode.L))   //  キーを離したら暗くなるUIは明るくなる
        {
            PLAYER2PUSHED_SQUARE.SetActive(false);
            PLAYER2PUSHED_CIRCLE.SetActive(false);
        }


        //　時間切れになった時か二人とも押したときの処理
        if (AIMTIME < PLAYER1_TIME)
        {
            if (!PLAYER1_PUSHED && !PLAYER2_PUSHED)
            {
                Debug.Log("引き分け！！！");
                JUDGE = "引き分け";
                StartCoroutine(MoveSceneDrawORWin_Explode());
            }

            if (PLAYER1_PUSHED && !PLAYER2_PUSHED)
            {
                JUDGE = "Player1の勝利";
                StartCoroutine(MoveSceneDrawORWin_Explode());
            }
            else if (!PLAYER1_PUSHED && PLAYER2_PUSHED)
            {
                JUDGE = "Player2の勝利";
                StartCoroutine(MoveSceneDrawORWin_Explode());
            }

            if (!PLAYER1_PUSHED)
            {
                PUSH_SE.PlayOneShot(Warning);
                PLAYER1_PUSHED = true;
                StartCoroutine(PlayExplodeSE());
            }

            if (!PLAYER2_PUSHED)
            {
                PUSH_SE.PlayOneShot(Warning);
                PLAYER2_PUSHED = true;
                StartCoroutine(PlayExplodeSE());
            }

        }
        else if (PLAYER1_PUSHED && PLAYER2_PUSHED)
        {
            DecideJudge();
        }

    }
    
    //  誤差を求めるかつ、STOP!!のテキストを表示する関数
    void GetMissedTime1()
    {
        //プレイヤー1かプレイヤー2が押したら起動
        if (!PLAYER1_PUSHED && PLAYER1_MISSEDTIME <= 0)
        {
            //  一部UIを暗くする
            PLAYER1PUSHED_SQUARE.SetActive(true);
            PLAYER1PUSHED_CIRCLE.SetActive(true);
            //  SEの再生
            PUSH_SE.Play();
            //  ストップのテキストを表示し、２度と押せなくなる
            STOPTEXT_PLAYER1.SetActive(true);
            PLAYER1_PUSHED = true;

            //  誤差の算出処理
            PLAYER1_MISSEDTIME = AIMTIME - (Mathf.Floor(PLAYER1_TIME * 10) / 10);
            Debug.Log(PLAYER1_MISSEDTIME);
        }
       
    }

    void GetMissedTime2()
    {
        if (!PLAYER2_PUSHED && PLAYER2_MISSEDTIME <= 0)
        {
            //  一部UIを暗くする
            PLAYER2PUSHED_SQUARE.SetActive(true);
            PLAYER2PUSHED_CIRCLE.SetActive(true);
            //  SEの再生
            PUSH_SE.Play();
            //  ストップのテキストを表示し、２度と押せなくなる
            STOPTEXT_PLAYER2.SetActive(true);
            PLAYER2_PUSHED = true;

            //  誤差の算出処理
            PLAYER2_MISSEDTIME = AIMTIME - (Mathf.Floor(PLAYER2_TIME * 10) / 10);
            Debug.Log(PLAYER2_MISSEDTIME);
        }
    }

    //  勝敗を決める関数
    private void  DecideJudge()
    {
        if (PLAYER1_MISSEDTIME == PLAYER2_MISSEDTIME)     JUDGE = "同じ時間の引き分け";
        else if (PLAYER1_MISSEDTIME < PLAYER2_MISSEDTIME) JUDGE = "Player1の勝利";
        else                                              JUDGE = "Player2の勝利";

        if (JUDGE == "同じ時間の引き分け")
        {
            StartCoroutine(MoveSceneDraw());
        }
        else
        {
            StartCoroutine(MoveWhoWin());
        }
    }

    //  シーン移動のコルーチン
    IEnumerator MoveSceneDraw()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Result_Draw");
    }

    IEnumerator MoveWhoWin()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Result2");
    }

    IEnumerator MoveSceneDrawORWin_Explode()
    {
        yield return new WaitForSeconds(6);
        if (JUDGE == "引き分け")
        {
            SceneManager.LoadScene("Result_Draw2");
        }
        else
        {
            SceneManager.LoadScene("Result2");
        }
    }



    IEnumerator PlayExplodeSE()
    {
        yield return new WaitForSeconds(3);
        PUSH_SE.PlayOneShot(Explode);
    }

}
