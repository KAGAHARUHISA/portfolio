using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoFailedManager : MonoBehaviour
{
    //  ��@�����s�̃t���O
    bool _failed = false;

    //  ��@���Q�[�����S�I���̃t���O
    bool _finish = false;

    //  ��𓦂�������
    public int _mosquitoEscapedCount = 0;

    //  ��ȊO������������
    public int _otherMosquiteHitCount = 0;

    //  ��̃~�j�Q�[�����ł��Ȃ��Ȃ邽�߂̃p�l��
    [SerializeField] GameObject _failedPanel;

    //  �����Ă��邻�̂��̂��i�[���郊�X�g
    [SerializeField] private List<GameObject> _movingObjects;

    //  �Ⴊ���̕ǂɉ��񓖂������玸�s���邩�̕ϐ�
    [SerializeField] private int _besideHitCount;

    //  ��ȊO������@�����玸�s���邩�̕ϐ�
    [SerializeField] private int _failedSwapCount;

    void Update()
    {
        if (_mosquitoEscapedCount == _besideHitCount && !_finish)
        {
            _failed = true;
            Debug.Log("���3�񓦂������܂����b�I�I�I");
        }
        else if (_otherMosquiteHitCount == _failedSwapCount && !_finish)
        {
            _failed = true;
            Debug.Log("��ȊO5��@�����܂����I�I�I");
        }

        //  ���s�������̏������L��
        if (_failed && !_finish)
        {
            _finish = true;
            //  ���s�������Ƃ��킩��p�l����ݒu
            _failedPanel.SetActive(true);

            //  �����Ă���I�u�W�F�N�g��S�Ĕ�\��
            foreach (GameObject movingObject in _movingObjects)
            {
                movingObject.SetActive(false);
            }

            //  ���s�񐔂����Z
            GameObject failedManager = GameObject.Find("AllMiniGameFailedManager");
            if (failedManager != null)
            {
                AllMiniGameFailedManager allMiniGameFailedManager = failedManager.GetComponent<AllMiniGameFailedManager>();
                allMiniGameFailedManager.AddPoint();
            }
            
        }
    }

    //  ���@���܂ł̎��s�񐔂𖳂��������Ƃɂ���֐�
    public void ResetFailedTime()
    {
        _mosquitoEscapedCount = 0;
        _otherMosquiteHitCount = 0;
    }


}
