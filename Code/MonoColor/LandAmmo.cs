using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandAmmo : MonoBehaviour
{
    //  違うパネルに触れたかどうかのフラグ
    private bool ISTOUCHED_DIFFERENCEPANEL = false;

    //  触れているパネルを格納するリスト
    List<Collider2D> PANELS = new List<Collider2D>();

    //  パネルに触れた時の領土弾のX座標を保持する変数
    //private float PAST_X;

    //  敵パネルに触れた後の弾のX座標を毎フレーム格納する変数
    //private float NOW_X;

    //  これがアタッチされている弾の幅の大きさを格納する変数
    //private float WIDTH;

    public AudioClip paintsound;

    AudioSource audioSource;

    //  生成するエフェクトを格納
    //public GameObject LAND_EFFECT;
    //public GameObject SUDDENDEATH_LAND_EFFECT;

    //  エフェクトがスポーンするまでの時間
    public float EFFECT_SPAWN_TIME = 0.75f;
    public float SUDDENDEATH_EFFECT_SPAWN_TIME = 0.25f;

    private void Start()
    {
        //  このオブジェクトの幅を格納
        //WIDTH = this.GetComponent<RectTransform>().sizeDelta.x;

        ////  敵のパネルに当たりそうになかったら自然消滅
        //StartCoroutine(SelfDestroy());

        //  音声を取得
        audioSource = GetComponent<AudioSource>();

        IsSuddenDeathCheckForEffect SUDDENDEATH_CHECK = GameObject.Find("JudgeManager").GetComponent<IsSuddenDeathCheckForEffect>();
        bool IS_SUDDENDEATH = SUDDENDEATH_CHECK.isSuddenDeath;

        //     サドンデスかどうかで生成するエフェクトを決める
        StartCoroutine(SpawnLandEffect(SUDDENDEATH_CHECK));
    }

    //  触れたパネルをリストに格納
    public void OnTriggerEnter2D(Collider2D TOUCHING_PANEL)
    {
        //  パネルのみ収容
        if (TOUCHING_PANEL.CompareTag("Player1Land") || TOUCHING_PANEL.CompareTag("Player2Land"))
        {

            PANELS.Add(TOUCHING_PANEL);

            //  もし触れたパネルが敵のパネルだったら塗りを開始
            if (this.CompareTag("BLACKPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player2Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.black, "Player1Land");
            }
            else if (this.CompareTag("WHITEPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player1Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.white, "Player2Land");
            }
        }
        else if (TOUCHING_PANEL.CompareTag("BLACKPLAYER_AMMO") || TOUCHING_PANEL.CompareTag("WHITEPLAYER_AMMO"))    //  塗り弾同士の相殺
        {
            Destroy(TOUCHING_PANEL);
            Destroy(this.gameObject);
        }
    }

    //   念のため塗れていないパネルを塗るための処理
    private void OnTriggerStay2D(Collider2D TOUCHING_PANEL)
    {
        if (TOUCHING_PANEL.CompareTag("Player1Land") || TOUCHING_PANEL.CompareTag("Player2Land"))
        {

            //  もし触れたパネルが敵のパネルだったら塗りを開始
            if (this.CompareTag("BLACKPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player2Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.black, "Player1Land");
            }
            else if (this.CompareTag("WHITEPLAYER_AMMO") && TOUCHING_PANEL.CompareTag("Player1Land") && !ISTOUCHED_DIFFERENCEPANEL)
            {
                ISTOUCHED_DIFFERENCEPANEL = true;
                //PAST_X = this.transform.position.x;
                CHANGE_PANELCOLOR(TOUCHING_PANEL, Color.white, "Player2Land");
            }
        }
    }

    //  離れたパネルをリストから削除
    private void OnTriggerExit2D(Collider2D EXIT_PANEL)
    {
        //  リストから、離れていったパネルを削除
        PANELS.Remove(EXIT_PANEL);

        //  リスト内のパネルに打ち出された領土弾と同じ色のパネルがあるかを確認する。
        if (this.CompareTag("BLACKPLAYER_AMMO") && IS_SAMECOLORPANEL(Color.black))
        {
            ISTOUCHED_DIFFERENCEPANEL = false;
        }
        else if (this.CompareTag("WHITEPLAYER_AMMO") && IS_SAMECOLORPANEL(Color.white))
        {
            ISTOUCHED_DIFFERENCEPANEL = false; //→ここ何故かtrueだった。
        }

    }

    private void Update()
    {

        //if (ISTOUCHED_DIFFERENCEPANEL)
        //{
        //    //NOW_X = this.transform.position.x;
        //    //  敵の陣地に弾の大きさだけ進んだかを確認
        //    if (Mathf.Abs(PAST_X - NOW_X) >= WIDTH)
        //    {
        //        if (this.CompareTag("BLACKPLAYER_AMMO"))
        //        {
        //            CHANGE_PANELCOLOR(Color.black, "Player1Land");
        //        }
        //        else
        //        {
        //            CHANGE_PANELCOLOR(Color.white, "Player2Land");
        //        }
        //    }
        //}
    }


    #region リストの中に弾と同じ色のパネルがあるか確認する関数

    private bool IS_SAMECOLORPANEL(Color COLOR)
    {

        //  リストの要素数の分だけ要素の色を調査
        foreach (var CHECK_PANEL in PANELS)
        {
            if (CHECK_PANEL.GetComponent<Image>().color == COLOR) //    同じ色のパネルがあったらtrueを返す
            {
                return true;
            }
        }
        return false;   //  同じ色のパネルがなかったらfalseを返す
    }
    #endregion

    #region リスト内のパネルを領土弾の色に染めてタグも変える関数

    private void CHANGE_PANELCOLOR(Collider2D PANEL, Color CHANGECOLOR, string TAG_NAME)
    {
      
            PANEL.GetComponent<Image>().color = CHANGECOLOR;
            PANEL.tag = TAG_NAME;
        
        ////  エフェクトを生成した後、消滅
        //Instantiate(LAND_EFFECT, this.transform.position, Quaternion.identity);
        //Destroy(this.gameObject);
    }

    #endregion


    ////  領土弾の自然消滅の仕組み
    //IEnumerator SelfDestroy()
    //{
    //    yield return new WaitForSeconds(30);
    //    Destroy(this.gameObject);
    //}

    //  エフェクト生成の仕組み
    IEnumerator SpawnLandEffect(bool IsSuddenDeath)
    {
        
        //  通常時
        if (!IsSuddenDeath)
        {
            yield return new WaitForSeconds(EFFECT_SPAWN_TIME);
            //Instantiate(LAND_EFFECT, this.transform.position, Quaternion.identity);
        }
        else　//  サドンデス時
        {
            yield return new WaitForSeconds(SUDDENDEATH_EFFECT_SPAWN_TIME);
            //Instantiate(SUDDENDEATH_LAND_EFFECT, this.transform.position, Quaternion.identity);
        }

    }

}
