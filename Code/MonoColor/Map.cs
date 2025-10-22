using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using static Unity.Collections.AllocatorManager;

public class Map : MonoBehaviour
{
    Transform PANEL_OF_PARENT;      //  パネルの親を格納するトランスフォーム型の変数(パネルの親はこのスクリプトをアタッチしているオブジェクト)

    public GameObject BLACK_PLAYERTILE;         //黒いパネル(Player1)
    public GameObject WHITE_PLAYERTILE;         //白いパネル(Player2)

    int PANELPLACE_X = -945;  //最初に配置されるパネルのX座標
    int PANELPLACE_Y = 525;  //最初に配置されるパネルのY座標
    Vector2 PANEL_PLACE = new Vector2();    //配置されるパネルの位置

    [SerializeField] TextAsset MAP_CSVFILE; // CSVファイル
    private List<string[]> MAP_CSVDATA = new List<string[]>(); // CSVファイルの中身を入れるリスト

    // Start is called before the first frame update
    void Start()
    {
        PANEL_OF_PARENT = GetComponent<Transform>();              // 変数にこのオブジェクトのTransformを格納
        StringReader READER = new StringReader(MAP_CSVFILE.text); // TextAssetをStringReaderに変換

        while (READER.Peek() != -1)
        {
            string line = READER.ReadLine(); // 1行ずつ読み込む
            MAP_CSVDATA.Add(line.Split(',')); // MAP_CSVDATAリストに追加する
            PANEL_PLACE = new Vector2(PANELPLACE_X, PANELPLACE_Y);  //  パネルの座標を指定
        }

        for (int i = 0; i <36; i++) //  一つ一つの要素を確認してマップのタイルを出現させる
        {

            for (int j = 0; j < 64; j++)
            {

                if (MAP_CSVDATA[i][j] == "0")   //  黒パネルの時
                {
                    GameObject BLACK = Instantiate(BLACK_PLAYERTILE, PANEL_PLACE, Quaternion.identity);　　 //    パネルの出現
                    BLACK.transform.SetParent(PANEL_OF_PARENT);                                             //  　出したパネルをこのスクリプトがアタッチされているオブジェクトの子にする
                }
                else if (MAP_CSVDATA[i][j] == "1")　//  白パネルの時
                {
                    GameObject WHITE = Instantiate(WHITE_PLAYERTILE, PANEL_PLACE, Quaternion.identity);     //    パネルの出現
                    WHITE.transform.SetParent(PANEL_OF_PARENT);                                            //  　出したパネルをこのスクリプトがアタッチされているオブジェクトの子にする
                }

               PANEL_PLACE.x += 30;     //  次に設置するパネルのX座標が正の方向に30ずらすため

                if (j == 63)    //  横一列分のパネルを配置したら次に配置するパネルのX座標を今の列の１枚目と同じにする
                {
                    PANEL_PLACE.x = -945; //  ここで変更
                }
            }

            PANEL_PLACE.y -= 30;    //  次の列に配置するパネルのためにY座標を負の方向に30ずらす
        }

    }

  
}
