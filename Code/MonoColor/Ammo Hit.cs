using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHit : MonoBehaviour
{

    //  当てられたプレイヤーのオブジェクトの情報を格納する変数
    private GameObject HITTEDPLAYER_INFOTMATION;


    private void Start()
    {
        //  当たらなかった時に時間差で自然崩壊
        StartCoroutine(Dont_hit());
    }


    //  敵に当たった時の処理
    void OnTriggerEnter2D(Collider2D HITTED_PLAYER)
    {
        //  もし敵プレイヤーに当たったら
        if (HITTED_PLAYER.gameObject.tag == "Player"　|| HITTED_PLAYER.gameObject.tag == "Player2")
        {
            Debug.Log("当たった！");
            //  当てられたプレイヤーのオブジェクトの情報を格納  
            HITTEDPLAYER_INFOTMATION = HITTED_PLAYER.gameObject;

            //  当てられた側のHPスクリプトを格納する変数作成＆格納
            PlayerHP HP;
            HP = HITTEDPLAYER_INFOTMATION.GetComponent<PlayerHP>();

            //  当てられた側のHPを削る処理
            HP.PLAYER_HP--;

            //  HPViewManagerにアタッチされているスクリプト内にある関数を起動し、HPUIを変える
            HPView HPVIEW;
            GameObject HPVIEW_MANAGER = GameObject.FindGameObjectWithTag("HPView_Manager");
            HPVIEW = HPVIEW_MANAGER.GetComponent<HPView>();
            HPVIEW.ChangeHPViwer();

            //弾幕を破壊
            Destroy(this.gameObject);
        }
    }

    //  自然崩壊の仕組み
    IEnumerator Dont_hit()
    {
        yield return new WaitForSeconds(60);
        Destroy(this.gameObject);
    }

   
}
