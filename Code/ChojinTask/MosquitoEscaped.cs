using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoEscaped : MonoBehaviour
{
    [SerializeField] GameObject _mosquitoFailedManager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mosquito"))    //  蚊が当たった時の処理
        {
            //  MosquitoFailedManager内の_mosquitoEscapedCount変数をインクリメントする
            Debug.Log("蚊を逃した");
            MosquitoFailedManager mosquitoFailedManager = _mosquitoFailedManager.GetComponent<MosquitoFailedManager>();
            mosquitoFailedManager._mosquitoEscapedCount++;

            //  蚊が当たったらx軸方向の移動を反転させる関数を起動
            MosquitoMove mosquitoMove = other.GetComponent<MosquitoMove>();
            mosquitoMove.MosquitoReturn();
        }
        else    //  UFOが当たった時の処理
        {
            UFOMove ufoMove = other.GetComponent<UFOMove>();
            if (ufoMove != null )
            {
                ufoMove.UFOReturn();
            }
        }

    }
}
