using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayGameStarter : MonoBehaviour
{
    //  �C���X�y�N�^�[�ł��̃Q�[���̐��b��ɓ����������I�u�W�F�N�g���i�[����
    public List<GameObject> _stoppingObjects = new List<GameObject>();

    //  �t�F�[�h�A�E�g����܂ł̎���
    public float _endTime;

    //  �E�N���b�N�������ǂ����̃t���O
    private bool _rightCliked = false;

    void Start()
    {
        StopObjects();
    }
    private void Update()
    {
        if (!_rightCliked && Input.GetMouseButtonDown(1))
        {
            _rightCliked = true;
            AbleObjects();
            Invoke(nameof(StopObjects), _endTime);
        }
    }

    //  �~�߂��I�u�W�F�N�g���N��������֐�
    private void AbleObjects()
    {
        foreach(GameObject gameObject in _stoppingObjects)
        {
            gameObject.SetActive(true);
        }
    }

    //  �I�u�W�F�N�g���~�߂�

    private void StopObjects()
    {
        foreach (GameObject gameObject in _stoppingObjects)
        {
            gameObject.SetActive(false);
            Debug.Log(gameObject.name);
        }
    }

}
