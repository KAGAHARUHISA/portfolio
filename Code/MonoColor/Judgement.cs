using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    // �@���҂̗̓y�̊������i�[����ϐ�
    public static int WINNER_LAND_PERCENT;

    public static Judgement _instance { get; private set; }

    //  ���҂̗̓y���l�ߍ��ރ��X�g
    List<GameObject> WINNER_LAND = new List<GameObject>();

    //  ���X�g�̗v�f�����i�[����ϐ�
    float LIST_NUMBER;
    private bool isGameOver = false; //�ǉ�

    void Start()
    {
        //isGameOver = true;    
    }
    private void Awake()
    {
        //�V���O���g���̐ݒ�
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
        isGameOver = true; //�Ƃ肠���������𖳑ʂɌĂ΂Ȃ��悤�ɏ����������~�߂�
        // �v���C���[1�̗̓y��S�Ċi�[����
        WINNER_LAND.AddRange(GameObject.FindGameObjectsWithTag("Player1Land"));

        //  �p�[�Z���e�[�W�̎Z�o
        LIST_NUMBER = WINNER_LAND.Count;
        WINNER_LAND_PERCENT = Mathf.RoundToInt((LIST_NUMBER / 2304) * 100 );
        PlayerPrefs.SetInt("WinnerLandScore", WINNER_LAND_PERCENT);
        PlayerPrefs.Save();
    }

    public void Player2_Win() 
    {
        if (isGameOver) return;
        isGameOver = true;//������������
        // �v���C���[2�̗̓y��S�Ċi�[����
        WINNER_LAND.AddRange(GameObject.FindGameObjectsWithTag("Player2Land"));

        //  �p�[�Z���e�[�W�̎Z�o
        LIST_NUMBER = WINNER_LAND.Count;
        WINNER_LAND_PERCENT = Mathf.RoundToInt((LIST_NUMBER / 2304) * 100);
        PlayerPrefs.SetInt("WinnerLandScore", WINNER_LAND_PERCENT);
        PlayerPrefs.Save();
    }
}
