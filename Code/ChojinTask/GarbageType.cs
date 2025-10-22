using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageType : MonoBehaviour
{
    //  �U���Ă��邲�݂̃^�C�v�����߂�B�O�Ȃ�R���݁A�P�Ȃ玑������
    public int _garbageTypeNumber;

    //  �S�~���ɓ������ۂ̃S�~�ʂ�SE�������Ɋi�[
    [SerializeField] private AudioClip _garbageSE;

    void OnDestroy()
    {
        AudioSource audioSource = transform.parent.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(_garbageSE);
    }

}
