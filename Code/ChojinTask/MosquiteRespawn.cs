using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquiteRespawn : MonoBehaviour
{
    //  蚊が湧くスポナーを格納する変数
    [SerializeField] GameObject _leftSpawner;
    [SerializeField] GameObject _rightSpawner;

    //  蚊が湧く位置を決める番号、０なら左、１なら右から湧く
    int _desideSpawnNum;

    // Start is called before the first frame update
    void Start()
    {
        Respawn();
    }

    public void Respawn()
    {
        _desideSpawnNum = Random.Range(0, 2);

        if (_desideSpawnNum == 0)   //  左側でスポーンするときの処理
        {
            Vector3 spawnPos = _leftSpawner.transform.position;
            this.transform.position = spawnPos;

            //  クリック前に蚊が左方向へ進行していたらスピードに-1をかける＆イラストも反転させる
            MosquitoMove mosquitomove = GetComponent<MosquitoMove>();
            if (mosquitomove._besideSpeed < 0)
            {
                mosquitomove._besideSpeed *= -1;

                Vector3 localScale = this.transform.localScale;
                localScale.x *= -1;
                this.transform.localScale = localScale;
            }


        }
        else　//  右側でスポーンするときの処理
        {
            Vector3 spawnPos = _rightSpawner.transform.position;
            this.transform.position = spawnPos;

            //  クリック前に蚊が右方向へ進行していたらスピードに-1をかける＆イラストも反転させる
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
