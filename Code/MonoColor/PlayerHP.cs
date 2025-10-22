using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    //  プレイヤーのHP
    public int PLAYER_HP = 2;

    [SerializeField, Header("遷移先のシーン名")] private string _loadSceneName;

    Judgement JUDGE_SCRIPT;
    PlayerBurst playerBurst_script;
    //加筆
    public float boundsPower = 10f;
    public Rigidbody2D rb;


    void Start()
    {
        GameObject JUDGE = GameObject.Find("JudgeManager");
        JUDGE_SCRIPT = JUDGE.GetComponent<Judgement>();
        playerBurst_script = GetComponent<PlayerBurst>();
        //
        rb = GetComponent<Rigidbody2D>();
    }

    // void Update()
    // {
    //     //  プレイヤーのHPが０になった時の処理
    //     if (PLAYER_HP == 0)
    //     {
    //         //  リザルトシーンに移動
    //         Debug.Log("リザルトなう");

    //         if (this.CompareTag("Player"))
    //         {
    //             JUDGE_SCRIPT.Player1_Win();
    //             SceneManager.LoadScene(_loadSceneName);
    //         }
    //         else
    //         {
    //             JUDGE_SCRIPT.Player2_Win();
    //             SceneManager.LoadScene(_loadSceneName);
    //         }

    //     }
    // }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {

        
        Debug.Log("当たった");
        if(PLAYER_HP == 0)
        {
            Debug.Log("Hpが０になった");
            if(this.CompareTag("Player"))
            {
                Debug.Log("プレイヤー１が勝利");
                //原加筆
                Vector2 boundsDirection = collision.contacts[0].normal;//
                rb.AddForce(boundsDirection * boundsPower, ForceMode2D.Impulse);

                JUDGE_SCRIPT.Player1_Win();
                SceneManager.LoadScene(_loadSceneName);
            }
            else
            {
                JUDGE_SCRIPT.Player2_Win();
                SceneManager.LoadScene(_loadSceneName);
            }
        }
        }
    }

}