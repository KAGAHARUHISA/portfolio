using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMosquitoEscape : MonoBehaviour
{
    //  �㉺�̕ǂɓ����������̈ړ���
    [SerializeField] private float _movePosition;

    //  �ڍ׃p�l���ŏ�̕ǂ��ۂ��𕪂���
    [SerializeField] private bool _isTopWall;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Mosquito"))    //  �Ⴊ�㉺�g�O����o�Ȃ��悤�ɂ��鏈��
        {
            MosquitoMove mosquitoMove = collision.GetComponent<MosquitoMove>();
            mosquitoMove._upSpeed *= -1;
        }
        else�@// UFO���㉺�g�O����o�Ȃ��悤�ɂ��鏈��
        {
            UFOMove ufoMove = collision.GetComponent<UFOMove>();
            if (ufoMove != null )
            {
                RectTransform rectTransform = collision.gameObject.GetComponent<RectTransform>();
                Vector3 ufoPos = rectTransform.position;

                //  UFO�̂��蔲�����������Ȃ��l�ɒ���
                if (_isTopWall) //  ��̕ǂɓ���������
                {
                    ufoPos.y -= _movePosition;
                }
                else // ���̕ǂɓ���������
                {
                    ufoPos.y += _movePosition;
                }

                rectTransform.position = ufoPos;

                //  ���������ǂ̔��΂ɐi�ނ悤�ɂ���
                ufoMove._upSpeed *= -1;
            }
        }
        
    }
}
