using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAnimationManager : MonoBehaviour
{
    //  �A�j���[�^�[
    [SerializeField] private Animator _animator;

    //  ���s�����񐔂��i�[����ϐ�
    private int _failedTime;

    // Start is called before the first frame update
    void Start()
    {
        _failedTime = AllMiniGameFailedManager.FAILED_TIME;
        AwakeTrigger();
    }

    void AwakeTrigger()
    {
        if (_failedTime == 0)
        {

        }
        else if (_failedTime == 1)
        {
            _animator.SetTrigger("Excellent");
        }
        else if (_failedTime == 2)
        {
            _animator.SetTrigger("Good");
        }
        else if (_failedTime == 3)
        {
            _animator.SetTrigger("NoBad");
        }
        else
        {
            _animator.SetTrigger("Bad");
        }

    }


}