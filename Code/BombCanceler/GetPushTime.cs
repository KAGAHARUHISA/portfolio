using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;


public class GetPushTime : MonoBehaviour
{

    //  ���ꂼ��̃v���C���[�̃L�[���͂܂ł̎��Ԃ��i�[����ϐ�
    float PLAYER1_TIME = 0.0f;
    float PLAYER2_TIME = 0.0f;

    //  ���ꂼ��̃v���C���[�̃L�[���͂ƖڕW���Ԃ̌덷�̑��a���i�[����ϐ�
    public static float PLAYER1_MISSEDTIME = 0.0f;
    public static float PLAYER2_MISSEDTIME = 0.0f;

    //  ����̎��Ԃ�˂����ޕϐ�
    float AIMTIME = 5.0f;

    //  ����������������Ȃ��Ȃ�t���O
    bool PLAYER1_PUSHED = false;
    bool PLAYER2_PUSHED = false;

    // ���s������ϐ�
    public static string JUDGE = null;

    // STOP�̃e�L�X�g���i�[����ϐ�
    public GameObject STOPTEXT_PLAYER1;
    public GameObject STOPTEXT_PLAYER2;

    //  Audio Source�R���|�[�l���g���i�[����ϐ�
    AudioSource PUSH_SE;

    //  �X�g�b�v�{�^�����������Ƃ��ɈꕔUI���Â�����I�u�W�F�N�g���i�[����ϐ�
    public GameObject PLAYER1PUSHED_SQUARE;
    public GameObject PLAYER1PUSHED_CIRCLE;
    public GameObject PLAYER2PUSHED_SQUARE;
    public GameObject PLAYER2PUSHED_CIRCLE;

    public AudioClip Warning;
    public AudioClip Explode;


    private void Start()
    {
        //  Audio Source�R���|�[�l���g���擾���i�[
        PUSH_SE = GetComponent<AudioSource>();
        //  ����̎��Ԃ������_���ɂ��鏈����g�ݍ��ޗ\��
    }

    void Update()
    {
        PLAYER1_TIME += Time.deltaTime;
        PLAYER2_TIME += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) && !PLAYER1_PUSHED)
        {
            GetMissedTime1();
        }
        else if (PLAYER1_PUSHED && Input.GetKeyUp(KeyCode.A))   //  �L�[�𗣂�����Â��Ȃ�UI�͖��邭�Ȃ�
        {
            PLAYER1PUSHED_SQUARE.SetActive(false);
            PLAYER1PUSHED_CIRCLE.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.L) && !PLAYER2_PUSHED)
        {
            GetMissedTime2();
        }
        else if (PLAYER2_PUSHED && Input.GetKeyUp(KeyCode.L))   //  �L�[�𗣂�����Â��Ȃ�UI�͖��邭�Ȃ�
        {
            PLAYER2PUSHED_SQUARE.SetActive(false);
            PLAYER2PUSHED_CIRCLE.SetActive(false);
        }


        //�@���Ԑ؂�ɂȂ���������l�Ƃ��������Ƃ��̏���
        if (AIMTIME < PLAYER1_TIME)
        {
            if (!PLAYER1_PUSHED && !PLAYER2_PUSHED)
            {
                Debug.Log("���������I�I�I");
                JUDGE = "��������";
                StartCoroutine(MoveSceneDrawORWin_Explode());
            }

            if (PLAYER1_PUSHED && !PLAYER2_PUSHED)
            {
                JUDGE = "Player1�̏���";
                StartCoroutine(MoveSceneDrawORWin_Explode());
            }
            else if (!PLAYER1_PUSHED && PLAYER2_PUSHED)
            {
                JUDGE = "Player2�̏���";
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
    
    //  �덷�����߂邩�ASTOP!!�̃e�L�X�g��\������֐�
    void GetMissedTime1()
    {
        //�v���C���[1���v���C���[2����������N��
        if (!PLAYER1_PUSHED && PLAYER1_MISSEDTIME <= 0)
        {
            //  �ꕔUI���Â�����
            PLAYER1PUSHED_SQUARE.SetActive(true);
            PLAYER1PUSHED_CIRCLE.SetActive(true);
            //  SE�̍Đ�
            PUSH_SE.Play();
            //  �X�g�b�v�̃e�L�X�g��\�����A�Q�x�Ɖ����Ȃ��Ȃ�
            STOPTEXT_PLAYER1.SetActive(true);
            PLAYER1_PUSHED = true;

            //  �덷�̎Z�o����
            PLAYER1_MISSEDTIME = AIMTIME - (Mathf.Floor(PLAYER1_TIME * 10) / 10);
            Debug.Log(PLAYER1_MISSEDTIME);
        }
       
    }

    void GetMissedTime2()
    {
        if (!PLAYER2_PUSHED && PLAYER2_MISSEDTIME <= 0)
        {
            //  �ꕔUI���Â�����
            PLAYER2PUSHED_SQUARE.SetActive(true);
            PLAYER2PUSHED_CIRCLE.SetActive(true);
            //  SE�̍Đ�
            PUSH_SE.Play();
            //  �X�g�b�v�̃e�L�X�g��\�����A�Q�x�Ɖ����Ȃ��Ȃ�
            STOPTEXT_PLAYER2.SetActive(true);
            PLAYER2_PUSHED = true;

            //  �덷�̎Z�o����
            PLAYER2_MISSEDTIME = AIMTIME - (Mathf.Floor(PLAYER2_TIME * 10) / 10);
            Debug.Log(PLAYER2_MISSEDTIME);
        }
    }

    //  ���s�����߂�֐�
    private void  DecideJudge()
    {
        if (PLAYER1_MISSEDTIME == PLAYER2_MISSEDTIME)     JUDGE = "�������Ԃ̈�������";
        else if (PLAYER1_MISSEDTIME < PLAYER2_MISSEDTIME) JUDGE = "Player1�̏���";
        else                                              JUDGE = "Player2�̏���";

        if (JUDGE == "�������Ԃ̈�������")
        {
            StartCoroutine(MoveSceneDraw());
        }
        else
        {
            StartCoroutine(MoveWhoWin());
        }
    }

    //  �V�[���ړ��̃R���[�`��
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
        if (JUDGE == "��������")
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
