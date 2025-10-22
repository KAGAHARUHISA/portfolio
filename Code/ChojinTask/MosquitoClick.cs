using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosquitoClick : MonoBehaviour
{
    AudioSource _mosquitoSound;
    RectTransform _mosquitoRect;

    //  ���@��SE
    [SerializeField] private AudioClip _slapSE;

    //  ��@���Q�[�����ĊJ����܂ł̎���
    [SerializeField] float _RestartDelayTime;

    //  ���s�Ɋւ���Q�[���I�u�W�F�N�g���i�[����ϐ�
    [SerializeField] GameObject _mosquitoFailedManager;

    //  ���A���Œ@�����Ƃ�h�~����t���O
    bool _isAttack = false;

    //  ��̍��W
    private Vector3 _mosquitoPosition;

    //  �Ⴊ�@���ꂽ���̓_�Ŏ���
    [SerializeField] private float _flashCycle;

    //  �Ⴛ�̂��̂̉摜
    private Image _mosquitoImage;

    //  �_�ł�����̂ɕK�v�Ȏ��Ԃ̎󂯎M
    private float _time;

    //  �@������̗������x
    [SerializeField] private float _fallspeed;

    // Start is called before the first frame update
    void Start()
    {
        _mosquitoRect = GetComponent<RectTransform>();
        _mosquitoImage = GetComponent<Image>();
        _mosquitoSound = GetComponent<AudioSource>();
        _mosquitoPosition = this.transform.position;
    }

    void Update()
    {

        //  �@���ꂽ��Ђ�����Ԃ��ē_�ł��Ȃ���~��
        if (_isAttack)
        {
            //  �_�ł̏���
            _time += Time.deltaTime;
            var repeatValue = Mathf.Repeat((float)_time, _flashCycle);
            if (repeatValue >= _flashCycle * 0.5f)
            {
                _mosquitoImage.enabled = false;
            }
            else
            {
                _mosquitoImage.enabled = true;
            }

            //  �@����ė����鏈��
            _mosquitoPosition = _mosquitoRect.position;
            _mosquitoPosition.y -= _fallspeed * Time.deltaTime;
            _mosquitoRect.position = _mosquitoPosition;

        }

    }

    //  �@���ꂽ��쓮����֐�
    public void Clicked()
    {
        //  �Ⴊ�@���ꂽ����łȂ���Ώ������͒ʂ�
        if (!_isAttack)
        {
            _isAttack = true;
            Debug.Log("����Ԃ��@�����I�I");
            _mosquitoSound.PlayOneShot(_slapSE);
            StartCoroutine(RestartGame());

            //  ���s�񐔂����Z�b�g
            MosquitoFailedManager mosquitoFailedManager = _mosquitoFailedManager.GetComponent<MosquitoFailedManager>();
            mosquitoFailedManager.ResetFailedTime();

            //  ����㉺�ɂЂ�����Ԃ�
            ChangeScaleY();
            
        }
        
    }

    //  �Q�[�������X�^�[�g������R���[�`��
    IEnumerator RestartGame()
    {
        //  ��̓�������U��~
        MosquitoMove mosquitoMove = GetComponent<MosquitoMove>();
        mosquitoMove.enabled = false;

        yield return new WaitForSeconds(_RestartDelayTime);

        //  ���X�|�[���n�_�ւ̈ړ�����
        MosquiteRespawn mosquitoRespawn = GetComponent<MosquiteRespawn>();
        mosquitoRespawn.Respawn();

        //  �Ăщ�𓮂���&���@����悤�ɂ���
        mosquitoMove.enabled = true;
        mosquitoMove.AbjustPosY();
        _isAttack = false;

        //  �Ⴊ�����̏�ԂŔ�΂Ȃ��悤�Ɋm����Image��L���ɂ���
        _mosquitoImage.enabled = true;

        // �@����㉺���]�����Č��ɖ߂�
        ChangeScaleY();

    }

    //  �X�P�[����Y���W��-1�������ĉ���Ђ�����Ԃ�����N�����֐�
    private void ChangeScaleY()
    {
        Vector3 mosquitoScale = transform.localScale;
        mosquitoScale.y *= -1;
        transform.localScale = mosquitoScale;
    }
}
