using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGarbage : MonoBehaviour
{
    //  ゴミのプレファブを入れるリスト
    [SerializeField] private　List<GameObject> _garbages;

    //  ゴミを再スポーンさせるまでの秒数
    [SerializeField] private float _spawnSpanTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnGarbageInGame();
    }

    private void SpawnGarbageInGame()
    {
        //  スポーンさせるゴミを決める変数
        int garbageSelectNum = Random.Range(0, _garbages.Count);

        //  ゴミをスポーン
        Instantiate(_garbages[garbageSelectNum], this.transform);

        //  数秒後に再びリスポーン
        Invoke("SpawnGarbageInGame", _spawnSpanTime);
    }

    
}
