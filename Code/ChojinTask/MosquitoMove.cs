using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMove : MonoBehaviour
{
    //  �����̉������Əc�����̈ړ����x
    public float _besideSpeed,_upSpeed;

    //  �������Əc�����̈ړ����x�̍ŏ��l
    [SerializeField] float _besideSpeedMin, _upSpeedMin;

    //  �������Əc�����̈ړ����x�̍ő�l
    [SerializeField] float _besideSpeedMax, _upSpeedMax;

    //  �㉺�ɓ������̂ɒ��ڊւ��ϐ�
    float _upManager;

    void Start()
    {
        StartCoroutine(ChangeBesideSpeed());
        StartCoroutine(ChangeUpSpeed());
        Random.InitState(System.Environment.TickCount + GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        //  sin��p���ĉ���㉺�ɓ�����
        _upManager = Mathf.Sin(Time.time);

        //  ��̋����̐���
        transform.Translate(_besideSpeed * Time.deltaTime, _upSpeed * _upManager * Time.deltaTime, 0);
    }

    //  �������̈ړ����x�̃����_���ω�
    IEnumerator ChangeBesideSpeed()
    {
        float changeBesideSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeBesideSpeedSpan);
        _besideSpeed = Random.Range(_besideSpeedMin, _besideSpeedMax) * ContinueMosquiteBesideVector()  ;
        StartCoroutine(ChangeBesideSpeed());
    }

    //  �c�����̈ړ����x�̃����_���ω�
    IEnumerator ChangeUpSpeed()
    {
        float changeUpSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeUpSpeedSpan);
        _upSpeed = Random.Range(_upSpeedMin, _upSpeedMax);
        StartCoroutine(ChangeUpSpeed());
    }

    //  �ςȈړ������؂�Ԃ���j�~����֐�
    public short ContinueMosquiteBesideVector()
    {
        if (_besideSpeed < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }

    //  �E�o��������ǂɓ����������̃C���X�g��ړ����������]���鏈��
    public void MosquitoReturn()
    {
        // �C���X�g���]
        Vector3 localScale = this.transform.localScale;
        localScale.x *= -1;
        this.transform.localScale = localScale;

        //  �ړ��������]
        _besideSpeed *= -1;

    }

    //  �N���b�N����ĕ���������ɃX�|�[�����Ɠ����悤�ȋ����ɂ��邽�߂̊֐�
    public void AbjustPosY()
    {
        _upManager = 0;
    }
}
