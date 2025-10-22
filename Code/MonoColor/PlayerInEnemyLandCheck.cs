using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInEnemyLandCheck : MonoBehaviour
{
    //  ゲームオブジェクトをキーとしたタグ名の連想配列
    Dictionary<GameObject, string> TOUCHING_LAND = new Dictionary<GameObject, string>();

    //  プレイヤーの触れている領地が全て自分の領地か否かのフラグ
    bool IS_IN_MYLAND = true;

    bool gameStart = false;

    private void Awake()
    {
        gameStart = false;
        StartCoroutine("GameStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameStart)
        {
            //  触れている領地に自分のものがなかったらHP を0にする
            if (this.name == "Player_1P")
            {
                //Debug.Log(TOUCHING_LAND.Count);
                IS_IN_MYLAND = TOUCHING_LAND.Values.Contains("Player1Land");

                if (!IS_IN_MYLAND)
                {
                    PlayerHPscript PLAYERHP = GetComponent<PlayerHPscript>();
                    PLAYERHP.Player_HP = 0;
                }
            }
            else if (this.name == "Player_2P")
            {
                //Debug.Log(TOUCHING_LAND.Count + ";2P");
                IS_IN_MYLAND = TOUCHING_LAND.Values.Contains("Player2Land");

                if (!IS_IN_MYLAND)
                {
                    Player2PHPScript PLAYERHP = GetComponent<Player2PHPScript>();
                    PLAYERHP.Player2p_HP = 0;
                }
            }
        }  
    }

    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        gameStart = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //  触れたパネルを連想配列の中に放り込む
        if (collision.tag == "Player1Land" || collision.tag == "Player2Land")
        {
            TOUCHING_LAND.Add(collision.gameObject, collision.tag);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1Land" || collision.tag == "Player2Land")
        {
            //  触れているパネルと配列内のキーとなるパネルが同一なのにタグ名が異なった時に処理を実行
            if (TOUCHING_LAND[collision.gameObject] != collision.tag)
            {
                //  配列内のタグ名を上書き
                TOUCHING_LAND[collision.gameObject] = collision.tag;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //  離れたパネルを配列から消去
        if (collision.tag == "Player1Land" || collision.tag == "Player2Land")
        {
            TOUCHING_LAND.Remove(collision.gameObject);
        }
    }
}
