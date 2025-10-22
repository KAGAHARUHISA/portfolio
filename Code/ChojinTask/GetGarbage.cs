using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGarbage : MonoBehaviour
{
    //  ���̃S�~�������S�~��������邩�����߂�ԍ��B�O�͉R���݁A�P�͎�������
    [SerializeField] private int _trashCanType;

    //  ��ł��Ⴄ�^�C�v�̂��݂��������Ă��邩�̃t���O
    private bool _isGetDifferent = false;

    //  �S�~�܂����̂ɕK�v�Ȃ��݂̐�
    [SerializeField] private int _makeGarbageBagNum;

    //  ���ݕ����Ă��邲�݂̐�
    [SerializeField] private int _havingGarbageNum;

    //  �S�~���ɔC�ӂ̐��̃S�~�����܂����甭������A�j���[�V����
    [SerializeField] private Animator _crowAnimation;
    [SerializeField] private Animator _dustTrackAnimation;

    //  �A�j���[�V�������N��������g���K�[��
    [SerializeField] private string _triggerName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  ���S�~���𔻕ʂ���
        GarbageType garbageType = collision.gameObject.GetComponent<GarbageType>();
        if (garbageType != null)
        {
            //  ������S�~�̐����C���N�������g
            _havingGarbageNum++;

            if (garbageType._garbageTypeNumber == _trashCanType)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
                //  �Ή����Ă��Ȃ��S�~���������玸�s�̃t���O�𗧂Ă�
                _isGetDifferent = true;
            }

            //  �S�~�ܐ����̏������S�~�ۗ̕L�������Z�b�g
            if (_havingGarbageNum == _makeGarbageBagNum && !_isGetDifferent)
            {
                Debug.Log("�S�~���W�ԂɘA�ꋎ���鐳�����S�~��");
                _havingGarbageNum = 0;

                //  �A�j���[�V�������N��  
                _dustTrackAnimation.SetTrigger(_triggerName);
            }
            else if (_havingGarbageNum == _makeGarbageBagNum && _isGetDifferent)
            {
                Debug.Log("�J���X�ɘA��Ă������_���ȃS�~��");
                //  ���s�̃t���O������
                _isGetDifferent = false;
                _havingGarbageNum = 0;

                //  �A�j���[�V�������N��
                _crowAnimation.SetTrigger(_triggerName);

                //  ���s�񐔂����Z���鏈��
                GameObject failedManager = GameObject.Find("AllMiniGameFailedManager");
                if (failedManager != null)
                {
                    AllMiniGameFailedManager allMiniGameFailedManager = failedManager.GetComponent<AllMiniGameFailedManager>();
                    allMiniGameFailedManager.AddPoint();
                }

            }

            //  �����Ă����S�~���폜
            Destroy(collision.gameObject);

        }
    }

}
