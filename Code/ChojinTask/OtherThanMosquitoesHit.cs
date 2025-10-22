using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherThanMosquitoesHit : MonoBehaviour
{
    [SerializeField] GameObject _mosquitoFailedManager;

    [SerializeField] AudioClip _missSE;
    [SerializeField] AudioSource _audioSource;

    // 蚊以外をたたいた時の処理
    public void Hit()
    {
        //  MosquitoFailedManagaer内のint型変数、_otherMosquiteHitCountをインクリメントする
        MosquitoFailedManager mosquitoFailedManager = _mosquitoFailedManager.GetComponent<MosquitoFailedManager>();
        mosquitoFailedManager._otherMosquiteHitCount++;
        _audioSource.PlayOneShot(_missSE);
    }

}
