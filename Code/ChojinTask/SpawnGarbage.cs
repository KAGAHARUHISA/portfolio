using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarbage : MonoBehaviour
{
    //  �S�~�̃v���t�@�u�����郊�X�g
    [SerializeField] private�@List<GameObject> _garbages;

    //  �S�~���ăX�|�[��������܂ł̕b��
    [SerializeField] private float _spawnSpanTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGarbageInGame();
    }

    private void SpawnGarbageInGame()
    {
        //  �X�|�[��������S�~�����߂�ϐ�
        int garbageSelectNum = Random.Range(0, _garbages.Count);

        //  �S�~���X�|�[��
        Instantiate(_garbages[garbageSelectNum], this.transform);

        //  ���b��ɍĂу��X�|�[��
        Invoke("SpawnGarbageInGame", _spawnSpanTime);
    }

    
}
