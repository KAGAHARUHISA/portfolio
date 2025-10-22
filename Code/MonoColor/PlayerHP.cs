using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHP : MonoBehaviour
{
    //  �v���C���[��HP
    public int PLAYER_HP = 2;

    [SerializeField, Header("�J�ڐ�̃V�[����")] private string _loadSceneName;

    Judgement JUDGE_SCRIPT;
    PlayerBurst playerBurst_script;
    //���M
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
    //     //  �v���C���[��HP���O�ɂȂ������̏���
    //     if (PLAYER_HP == 0)
    //     {
    //         //  ���U���g�V�[���Ɉړ�
    //         Debug.Log("���U���g�Ȃ�");

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

        
        Debug.Log("��������");
        if(PLAYER_HP == 0)
        {
            Debug.Log("Hp���O�ɂȂ���");
            if(this.CompareTag("Player"))
            {
                Debug.Log("�v���C���[�P������");
                //�����M
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