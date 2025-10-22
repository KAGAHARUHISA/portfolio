using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoEscaped : MonoBehaviour
{
    [SerializeField] GameObject _mosquitoFailedManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mosquito"))    //  �Ⴊ�����������̏���
        {
            //  MosquitoFailedManager����_mosquitoEscapedCount�ϐ����C���N�������g����
            Debug.Log("��𓦂���");
            MosquitoFailedManager mosquitoFailedManager = _mosquitoFailedManager.GetComponent<MosquitoFailedManager>();
            mosquitoFailedManager._mosquitoEscapedCount++;

            //  �Ⴊ����������x�������̈ړ��𔽓]������֐����N��
            MosquitoMove mosquitoMove = other.GetComponent<MosquitoMove>();
            mosquitoMove.MosquitoReturn();
        }
        else    //  UFO�������������̏���
        {
            UFOMove ufoMove = other.GetComponent<UFOMove>();
            if (ufoMove != null )
            {
                ufoMove.UFOReturn();
            }
        }

    }
}
