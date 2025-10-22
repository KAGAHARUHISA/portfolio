using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySEGarbageGame : MonoBehaviour
{
    //  �I�[�f�B�I�\�[�X
    [SerializeField] private AudioSource _audioSource;

    //  �J���X�ƃS�~���W�Ԃ̃A�j���[�V�����̉�
    [SerializeField] private AudioClip _crowSE;
    [SerializeField] private AudioClip _truckSE;

    public void PlayCrowSE()
    {
        _audioSource.PlayOneShot(_crowSE);
    }

    public void PlayTruckSE()
    {
        _audioSource.PlayOneShot(_truckSE);
    }
}
