using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquiteRespawn : MonoBehaviour
{
    //  �Ⴊ�N���X�|�i�[���i�[����ϐ�
    [SerializeField] GameObject _leftSpawner;
    [SerializeField] GameObject _rightSpawner;

    //  �Ⴊ�N���ʒu�����߂�ԍ��A�O�Ȃ獶�A�P�Ȃ�E����N��
    int _desideSpawnNum;

    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        _desideSpawnNum = Random.Range(0, 2);

        if (_desideSpawnNum == 0)   //  �����ŃX�|�[������Ƃ��̏���
        {
            Vector3 spawnPos = _leftSpawner.transform.position;
            this.transform.position = spawnPos;

            //  �N���b�N�O�ɉႪ�������֐i�s���Ă�����X�s�[�h��-1�������違�C���X�g�����]������
            MosquitoMove mosquitomove = GetComponent<MosquitoMove>();
            if (mosquitomove._besideSpeed < 0)
            {
                mosquitomove._besideSpeed *= -1;

                Vector3 localScale = this.transform.localScale;
                localScale.x *= -1;
                this.transform.localScale = localScale;
            }


        }
        else�@//  �E���ŃX�|�[������Ƃ��̏���
        {
            Vector3 spawnPos = _rightSpawner.transform.position;
            this.transform.position = spawnPos;

            //  �N���b�N�O�ɉႪ�E�����֐i�s���Ă�����X�s�[�h��-1�������違�C���X�g�����]������
            MosquitoMove mosquitomove = GetComponent<MosquitoMove>();
            if(mosquitomove._besideSpeed > 0)
            {
                mosquitomove._besideSpeed *= -1;

                Vector3 localScale = this.transform.localScale;
                localScale.x *= -1;
                this.transform.localScale = localScale;
            }
            
        }
    }
}
