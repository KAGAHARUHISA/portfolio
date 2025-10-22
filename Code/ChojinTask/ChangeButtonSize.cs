using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSize : MonoBehaviour
{
    //  �ŏ��A�ő�̃T�C�Y�ɂȂ�����
    private bool _isMin;
    private bool _isMax;

    //  �}�E�X�J�[�\�����{�^���ɐG��Ă��邩
    private bool _isTouch;

    //  �k���g��X�s�[�h
    [SerializeField] private float _scaleSpeed;

    //  �N���b�N���Ă��Ȃ��Ƃ��̃{�^���̍ŏ��A�ő�T�C�Y
    [SerializeField] private Vector3 _minSize = new Vector3();
    [SerializeField] private Vector3 _maxSize = new Vector3();

    //  Image���i�[����ϐ�
    [SerializeField] private Image _changeImage;

    //  �{�^�����N���b�N�������N���b�N���I�����ۂɕς��J���[��ݒ肷��(0����255�̐��l�����Ē���)
    [SerializeField] private Color32 _pushColor = new Color32();
    [SerializeField] private Color32 _exitColor = new Color32();

    //  �I�[�f�B�I�\�[�X
    [SerializeField] private AudioSource _changeSE;

    //  �}�E�X�J�[�\�����G�ꂽ���̏���
    public void TouchButton()
    {
        _isTouch = true;
    }

    //  �}�E�X�J�[�\�����G��Ȃ��������̏���
    public void ExitButton()
    {
        _isTouch = false;
    }

    //  �}�E�X�J�[�\�����������u�Ԃ̃J�[�\���̐F�ύX�̏���
    public void PushChangeColorButton()
    {
        _changeImage.color = _pushColor;
    }

    //  �}�E�X�J�[�\�����A�C�R����ŃN���b�N���ė������ۂ̃A�C�R���̐F�̏���
    public void ExitChangeColorButton()
    {
        _changeImage.color = _exitColor;
        _changeSE.Play();
    }


    private void Update()
    {
        if (!_isMin && _isTouch)
        {
            //  �}�E�X�J�[�\���ŐG�ꂽ���Ƀ{�^���̃T�C�Y������������
            transform.localScale = Vector3.Lerp(transform.localScale, _minSize, _scaleSpeed * Time.deltaTime);
            _isMax = false;
        }
        else if (!_isMax && !_isTouch)
        {
            //  �}�E�X�J�[�\�����痣�ꂽ�Ƃ��Ƀ{�^���̃T�C�Y��傫������
            transform.localScale = Vector3.Lerp(transform.localScale, _maxSize, _scaleSpeed * Time.deltaTime);
            _isMin = false;
        }

        //  �ő�A�ŏ��̑傫���ɂȂ����ہA���ʂ�Lerp���N�����Ȃ��t���O���I���ɂ���
        if (transform.localScale == _minSize)
        {
            _isMin = true;
        }
        else if (transform.localScale == _maxSize)
        {
            _isMax = true;
        }
        
    }

}
