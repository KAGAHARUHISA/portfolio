using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoFailedManager : MonoBehaviour
{
    //  蚊叩き失敗のフラグ
    bool _failed = false;

    //  蚊叩きゲーム完全終了のフラグ
    bool _finish = false;

    //  蚊を逃がした回数
    public int _mosquitoEscapedCount = 0;

    //  蚊以外をたたいた回数
    public int _otherMosquiteHitCount = 0;

    //  蚊のミニゲームができなくなるためのパネル
    [SerializeField] GameObject _failedPanel;

    //  動いているそのものを格納するリスト
    [SerializeField] private List<GameObject> _movingObjects;

    //  蚊が横の壁に何回当たったら失敗するかの変数
    [SerializeField] private int _besideHitCount;

    //  蚊以外を何回叩いたら失敗するかの変数
    [SerializeField] private int _failedSwapCount;

    void Update()
    {
        if (_mosquitoEscapedCount == _besideHitCount && !_finish)
        {
            _failed = true;
            Debug.Log("蚊を3回逃がしちまったッ！！！");
        }
        else if (_otherMosquiteHitCount == _failedSwapCount && !_finish)
        {
            _failed = true;
            Debug.Log("蚊以外5回叩いちまった！！！");
        }

        //  失敗した時の処理を記載
        if (_failed && !_finish)
        {
            _finish = true;
            //  失敗したことがわかるパネルを設置
            _failedPanel.SetActive(true);

            //  動いているオブジェクトを全て非表示
            foreach (GameObject movingObject in _movingObjects)
            {
                movingObject.SetActive(false);
            }

            //  失敗回数を加算
            GameObject failedManager = GameObject.Find("AllMiniGameFailedManager");
            if (failedManager != null)
            {
                AllMiniGameFailedManager allMiniGameFailedManager = failedManager.GetComponent<AllMiniGameFailedManager>();
                allMiniGameFailedManager.AddPoint();
            }
            
        }
    }

    //  蚊を叩くまでの失敗回数を無かったことにする関数
    public void ResetFailedTime()
    {
        _mosquitoEscapedCount = 0;
        _otherMosquiteHitCount = 0;
    }


}
