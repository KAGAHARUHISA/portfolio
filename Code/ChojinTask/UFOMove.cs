using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMove : MonoBehaviour
{
    //  �����̉������Əc�����̈ړ����x
    public float _besideSpeed, _upSpeed;

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
    }

    // Update is called once per frame
    void Update()
    {
        //  sin��p����UFO���㉺�ɓ�����
        _upManager = Mathf.Sin(Time.time);

        //  UFO�̋����̐���
        transform.Translate(_besideSpeed * Time.deltaTime, _upSpeed * _upManager * Time.deltaTime, 0);
    }

    //  �������̈ړ����x�̃����_���ω�
    IEnumerator ChangeBesideSpeed()
    {
        float changeBesideSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeBesideSpeedSpan);
        _besideSpeed = Random.Range(_besideSpeedMin, _besideSpeedMax) * ContinueUFOBesideVector();
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
    public short ContinueUFOBesideVector()
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

    //  �E�o��������ǂɓ���������ړ����������]���鏈��
    public void UFOReturn()
    {
        //  �ړ��������]
        _besideSpeed *= -1;
    }
}
