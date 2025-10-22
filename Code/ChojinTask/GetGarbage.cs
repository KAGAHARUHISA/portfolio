using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGarbage : MonoBehaviour
{
    //  このゴミ箱が何ゴミを回収するかを決める番号。０は可燃ごみ、１は資源ごみ
    [SerializeField] private int _trashCanType;

    //  一つでも違うタイプのごみが混ざっているかのフラグ
    private bool _isGetDifferent = false;

    //  ゴミ袋を作るのに必要なごみの数
    [SerializeField] private int _makeGarbageBagNum;

    //  現在抱えているごみの数
    [SerializeField] private int _havingGarbageNum;

    //  ゴミ箱に任意の数のゴミがたまったら発動するアニメーション
    [SerializeField] private Animator _crowAnimation;
    [SerializeField] private Animator _dustTrackAnimation;

    //  アニメーションを起動させるトリガー名
    [SerializeField] private string _triggerName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  何ゴミかを判別する
        GarbageType garbageType = collision.gameObject.GetComponent<GarbageType>();
        if (garbageType != null)
        {
            //  抱えるゴミの数をインクリメント
            _havingGarbageNum++;

            if (garbageType._garbageTypeNumber == _trashCanType)
            {
                Debug.Log("Success");
            }
            else
            {
                Debug.Log("Fail");
                //  対応していないゴミが入ったら失敗のフラグを立てる
                _isGetDifferent = true;
            }

            //  ゴミ袋生成の処理＆ゴミの保有数をリセット
            if (_havingGarbageNum == _makeGarbageBagNum && !_isGetDifferent)
            {
                Debug.Log("ゴミ収集車に連れ去られる正しいゴミ袋");
                _havingGarbageNum = 0;

                //  アニメーションを起動  
                _dustTrackAnimation.SetTrigger(_triggerName);
            }
            else if (_havingGarbageNum == _makeGarbageBagNum && _isGetDifferent)
            {
                Debug.Log("カラスに連れていかれるダメなゴミ袋");
                //  失敗のフラグを消す
                _isGetDifferent = false;
                _havingGarbageNum = 0;

                //  アニメーションを起動
                _crowAnimation.SetTrigger(_triggerName);

                //  失敗回数を加算する処理
                GameObject failedManager = GameObject.Find("AllMiniGameFailedManager");
                if (failedManager != null)
                {
                    AllMiniGameFailedManager allMiniGameFailedManager = failedManager.GetComponent<AllMiniGameFailedManager>();
                    allMiniGameFailedManager.AddPoint();
                }

            }

            //  落ちてきたゴミを削除
            Destroy(collision.gameObject);

        }
    }

}
