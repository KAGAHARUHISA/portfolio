using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySEGarbageGame : MonoBehaviour
{
    //  オーディオソース
    [SerializeField] private AudioSource _audioSource;

    //  カラスとゴミ収集車のアニメーションの音
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
