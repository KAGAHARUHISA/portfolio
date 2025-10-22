using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherThanMosquitoesHit : MonoBehaviour
{
    [SerializeField] GameObject _mosquitoFailedManager;

    [SerializeField] AudioClip _missSE;
    [SerializeField] AudioSource _audioSource;

    // ��ȊO�������������̏���
    public void Hit()
    {
        //  MosquitoFailedManagaer����int�^�ϐ��A_otherMosquiteHitCount���C���N�������g����
        MosquitoFailedManager mosquitoFailedManager = _mosquitoFailedManager.GetComponent<MosquitoFailedManager>();
        mosquitoFailedManager._otherMosquiteHitCount++;
        _audioSource.PlayOneShot(_missSE);
    }

}
