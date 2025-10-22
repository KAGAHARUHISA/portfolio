using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPView : MonoBehaviour
{

    //  �e�v���C���[�̎��@�̃I�u�W�F�N�g���i�[����ϐ�
    public GameObject PLAYER1;
    public GameObject PLAYER2;

    //  ���@�I�u�W�F�N�g�ɃA�^�b�`����Ă���X�N���v�g"PlayerHP"���ɂ���ϐ�PLAYER_HP���i�[����ϐ�
    private int PLAYER1_HP;
    private int PLAYER2_HP;

    //  �e�v���C���[��HPUI�I�u�W�F�N�g���i�[����ϐ�
    //  �v���C���[�P�p
    public GameObject FIRSTHP_PLAYER1;
    public GameObject SECONDHP_PLAYER1;

    //  �v���C���[�Q�p
    public GameObject FIRSTHP_PLAYER2;
    public GameObject SECONDHP_PLAYER2;

    //  �_���[�W���󂯂���������HPUI�̉摜���i�[����ϐ�
    public Sprite DAMAGED_PLAYER1HP;
    public Sprite DAMAGED_PLAYER2HP;


    //  �A���@����
    [SerializeField] private float invincibleTime; // ���G���Ԃ̒���
    [SerializeField] private float blinkInterval; // �_�ŊԊu
    [SerializeField] private Image[] targetimages; // �ΏۃI�u�W�F�N�g�̃����_���[
    [SerializeField] private Image[] targetimages2; // �ΏۃI�u�W�F�N�g�̃����_���[
    [SerializeField] private float invincibleDuration = 3f; // ���G��Ԃ̎�������
    private bool isInvincible; // ���G��Ԃ��ǂ���
    private bool isInvincible2; // �v���C���[2�����G��Ԃ��ǂ���
    private float invincibleTimer; // ���G���Ԃ̃J�E���g�_�E��
    private float invincibleTimerPlayer2; // ���G���Ԃ̃J�E���g�_�E��
    [SerializeField] private string newTag = "Damage";
    private string originalTag1;
    private string originalTag2;
    //private bool damege = false;

    public AudioClip hitsound;

    public AudioSource audioSource;

    //[SerializeField] private PlayerControl _playerControl;

    private void Start()
    {
        //  �������擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //originalTag1 = PLAYER1.tag;
        
        // ���G���Ԃ̏���
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0)
            {
                isInvincible = false;
                //  �^�O��ς��ē����蔻�������
                PLAYER1.tag = originalTag1;
                Debug.Log("���G���ԏI��");
                //damege = true;
            }
        }
        // ���G���Ԃ̏���
        if (isInvincible2)
        {
            invincibleTimerPlayer2 -= Time.deltaTime;
            if (invincibleTimerPlayer2 <= 0)
            {
                isInvincible2 = false;
                //  �^�O��ς��ē����蔻�������
                PLAYER2.tag = originalTag2;
                Debug.Log("���G���ԏI��");
                //damege = true;
            }
        }
        //if (_playerControl._suddenDeath)
       // {
            //damege = true;
        //}
    }

    public void ChangeHPViwer()
    {
        //  �v���C���[�P��HPUI��ύX
        if (PLAYER1_HP == 1)
        {
            Image DAMAGED_UI = FIRSTHP_PLAYER1.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER1HP;
            audioSource.PlayOneShot(hitsound);

        }
        else if (PLAYER1_HP == 0)
        {
            Debug.Log("a");
            Image DAMAGED_UI = SECONDHP_PLAYER1.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER1HP;
            ActivateIncibility();
            //  �^�O��ς��ē����蔻�������
            originalTag1 = PLAYER1.tag;
            PLAYER1.tag = newTag;
            audioSource.PlayOneShot(hitsound);
            StartCoroutine(InvincibleCoroutine());
        }
    }

    public void ChangeHPViwerPlayer2()
    {

        //  �v���C���[�Q��HPUI��ύX
        if (PLAYER2_HP == 1)
        {
            Image DAMAGED_UI = FIRSTHP_PLAYER2.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER2HP;
            audioSource.PlayOneShot(hitsound);
        }
        else if (PLAYER2_HP == 0)
        {
            Debug.Log("a");
            Image DAMAGED_UI = SECONDHP_PLAYER2.GetComponent<Image>();
            DAMAGED_UI.sprite = DAMAGED_PLAYER2HP;
            ActivateIncibilityPlayer2();
            //  �^�O��ς��ē����蔻�������
            originalTag2 = PLAYER2.tag;
            PLAYER2.tag = newTag;
            Debug.Log(PLAYER2.tag);
            audioSource.PlayOneShot(hitsound);
            StartCoroutine(InvincibleCoroutine2());
        }
    }

    IEnumerator InvincibleCoroutine()
    {
        float elapsedTime = 0f;
        while (elapsedTime < invincibleTime)
        {
            // �eRenderer��enabled��؂�ւ��ē_�Ō��ʂ����
            foreach (var image in targetimages)
            {
                if (image != null)
                {
                    image.enabled = !image.enabled; // �_�ł�����
                }
            }

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // �eRenderer��\����Ԃɖ߂�
        foreach (var image in targetimages)
        {
            if (image != null)
            {
                image.enabled = true;
            }
        }
    }

    IEnumerator InvincibleCoroutine2()
    {
        float elapsedTime = 0f;
        while (elapsedTime < invincibleTime)
        {
            // �eRenderer��enabled��؂�ւ��ē_�Ō��ʂ����
            foreach (var image in targetimages2)
            {
                if (image != null)
                {
                    image.enabled = !image.enabled; // �_�ł�����
                }
            }

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }

        // �eRenderer��\����Ԃɖ߂�
        foreach (var image in targetimages2)
        {
            if (image != null)
            {
                image.enabled = true;
            }
        }
    }
    //���G���ԊJ�n����
    public void ActivateIncibility()
    {
        isInvincible = true;
        invincibleTimer = invincibleDuration;
    }

    //���G���ԊJ�n����
    public void ActivateIncibilityPlayer2()
    {
        isInvincible2 = true;
        invincibleTimerPlayer2 = invincibleDuration;
    }
}
