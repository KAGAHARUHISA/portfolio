using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreEachOtherCollider : MonoBehaviour
{
    //  �����Ă���I�u�W�F�N�g�̃R���C�_�[���i�[���郊�X�g
    [SerializeField] private List<Collider2D> _movingColliders;

    // Start is called before the first frame update
    void Start()
    {
        //  �R���C�_�[�������m��������Ȃ��悤�ɂ���
        StartCoroutine(IgnoreCollider2D());
    }

    IEnumerator IgnoreCollider2D()
    {

        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < _movingColliders.Count; i++)
        {
            for (int j = i + 1; j < _movingColliders.Count; j++)
            {
                Physics2D.IgnoreCollision(_movingColliders[i], _movingColliders[j], true);
            }
        }
    }

    
}
