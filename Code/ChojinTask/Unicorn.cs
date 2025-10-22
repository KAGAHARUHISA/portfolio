using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : MonoBehaviour
{
    //  ���A�����̍Œ���W
    [SerializeField] float _xMin, _yMin;

    //  ���A�����̍ō����W
    [SerializeField] float _xMax, _yMax;

    //  �ړ����x�̍ō����x, �Œᑬ�x
    [SerializeField] float _maxSpeed, _minSpeed;

    //  ���j�R�[���̈ړ����x
    [SerializeField] float _speed;

   //  ���j�R�[����Rect
    private RectTransform _unicornRect;

    //  ���j�R�[���̖ڕW���B���W
    private Vector3 _unicornAimPos;

    //  ���j�R�[���̌��݈ʒu
    private Vector3 _unicornNowPos;

    private void Start()
    {
        _unicornRect = GetComponent<RectTransform>();

        //  �X�|�[������n�_�������_���ɂ���
        float startPosX = Random.Range(_xMin, _xMax);
        float startPosY = Random.Range(_yMin, _yMax);
        _unicornNowPos = new Vector3(startPosX, startPosY, 0);
        _unicornRect.anchoredPosition = new Vector3(startPosX, startPosY,0);

        DecidePositionAndSpeed();
    }

    private void Update()
    {
        //  ���j�R�[���̈ړ�
        _unicornRect.anchoredPosition = Vector3.MoveTowards(_unicornNowPos, _unicornAimPos, _speed * Time.deltaTime);
        _unicornNowPos = _unicornRect.anchoredPosition;

        //  �ڕW���B�_�ɓ��B������Ăшړ��n�_�ƃX�s�[�h��ς���
        if (_unicornNowPos == _unicornAimPos)
        {
            DecidePositionAndSpeed();
        }

    }

    //  ���j�R�[���̖ڕW���B�_�ƃX�s�[�h���肷��֐�
    void DecidePositionAndSpeed()
    {
        //  ���j�R�[���̖ڕW���B�_�����߂�
        float unicornAimPosX = Random.Range(_xMin, _xMax);
        float unicornAimPosY = Random.Range(_yMin, _yMax);
        _unicornAimPos = new Vector3(unicornAimPosX, unicornAimPosY, 0);

        //  �X�s�[�h�����߂�
        _speed = Random.Range(_minSpeed, _maxSpeed);

        //  �ړ������ƃC���X�g�̌����ɂ���Ă��ǂ�������������߂�
        if (_unicornAimPos.x - _unicornNowPos.x >= 0 && this.transform.localScale.x >= 0)
        {
            Vector3 inversionImage = this.transform.localScale;
            inversionImage.x *= -1;
            this.transform.localScale = inversionImage;
        }
        else if (_unicornAimPos.x - _unicornNowPos.x <= 0 && this.transform.localScale.x <= 0)
        {
            Vector3 inversionImage = this.transform.localScale;
            inversionImage.x *= -1;
            this.transform.localScale = inversionImage;
        }
    }
}
