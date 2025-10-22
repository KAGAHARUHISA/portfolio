using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class GameObjectDisplayController : MonoBehaviour    
{
    public GameObject ObjectToShow;
    public GameObject ObjectToShow2;
    public GameObject ObjectToShow3;
    public GameObject ObjectToShow4;
    public GameObject ObjectToShow5;
    public GameObject Black1;
    public GameObject Black2;
    public GameObject Black3;
    public GameObject Black4;
    public GameObject Black5;
    public GameObject BonusStart;

    public float DisplayDelay = 2.0f; // 表示までの待機時間（秒）

    private float Timer;
    public float Salt;
    [SerializeField]private int HowTime;
    public bool Use_Solt = true;


    public Spawner1 Spawn1;
    public Spawner2 Spawn2;
    public Spawner3 Spawn3;
    public Spawner4 Spawn4;
    public Spawner5 Spawn5;
    public Spawner6 Spawn6;
    public Spawner7 Spawn7;
    public Spawner8 Spawn8;
    public Spawner9 Spawn9;
    public Spawner10 Spawn10;
    public Spawner11 Spawn11;
    public Spawner12 Spawn12;
    public Spawner13 Spawn13;
    public Spawner14 Spawn14;
    public Spawner15 Spawn15;
    public Spawner16 Spawn16;
    public Spawner17 Spawn17;
    public Spawner18 Spawn18;
    public Spawner19 Spawn19;
    public Spawner20 Spawn20;
    public Spawner21 Spawn21;

    public bool S1 ;
    public bool S2 ;
    public bool S3 ;
    public bool S4 ;
    public bool S5 ;
    public bool S6 ;
    public bool S7 ;
    public bool S8 ;
    public bool S9 ;
    public bool S10 ;
    public bool S11 ;
    public bool S12 ;
    public bool S13 ;
    public bool S14 ;
    public bool S15 ;
    public bool S16 ;
    public bool S17 ;
    public bool S18 ;
    public bool S19 ;
    public bool S20 ;
    public bool S21 ;

    [SerializeField] private ParticleSystem particle;

    private void Start()
    {
        // 初期化
        Timer = 0.0f;
        //isDisplayed = false;
        ObjectToShow.SetActive(false);
        ObjectToShow2.SetActive(false);
        ObjectToShow3.SetActive(false);
        ObjectToShow4.SetActive(false);
        ObjectToShow5.SetActive(false);// ゲーム開始時にオブジェクトを非表示にする
        Black1.SetActive(false);
        Black2.SetActive(false);
        Black3.SetActive(false);
        Black4.SetActive(false);
        Black5.SetActive(false);
        BonusStart.SetActive(false);
        StartCoroutine(Bonus());

    }

    #region　塩の管理&使用中の穴の確認
    private void Update()
    {
        Timer += Time.deltaTime; // 経過時間をカウント

        if (Timer >= 3)
        {
            Salt++;
            Timer = 0.0f;

            if (Salt == 6)
            {
                Salt--;
            }
        }

        #region  塩アイコンの表示

        if (Salt == 0)
        {
            ObjectToShow.SetActive(false);
            ObjectToShow2.SetActive(false);
            ObjectToShow3.SetActive(false);
            ObjectToShow4.SetActive(false);
            ObjectToShow5.SetActive(false);
        }
        else if (Salt == 1)
        {
            ObjectToShow.SetActive(true);
            ObjectToShow2.SetActive(false);
            ObjectToShow3.SetActive(false);
            ObjectToShow4.SetActive(false);
            ObjectToShow5.SetActive(false);
        }
        else if (Salt == 2)
        {
            ObjectToShow.SetActive(true);
            ObjectToShow2.SetActive(true);
            ObjectToShow3.SetActive(false);
            ObjectToShow4.SetActive(false);
            ObjectToShow5.SetActive(false);
        }
        else if (Salt == 3)
        {
            ObjectToShow.SetActive(true);
            ObjectToShow2.SetActive(true);
            ObjectToShow3.SetActive(true);
            ObjectToShow4.SetActive(false);
            ObjectToShow5.SetActive(false);
        }
        else if (Salt == 4)
        {
            ObjectToShow.SetActive(true);
            ObjectToShow2.SetActive(true);
            ObjectToShow3.SetActive(true);
            ObjectToShow4.SetActive(true);
            ObjectToShow5.SetActive(false);
        }
        else if (Salt == 5)
        {
            ObjectToShow.SetActive(true);
            ObjectToShow2.SetActive(true);
            ObjectToShow3.SetActive(true);
            ObjectToShow4.SetActive(true);
            ObjectToShow5.SetActive(true);
        }

        Shadow();

       
        #endregion

        if (Input.GetMouseButtonDown(1))
        {
            if (Salt > 0 && Use_Solt)
            {
                Salt--;
                Use_Solt = false;
                HowTime += (int)Random.Range(2, 4);
                Select();
                particle.Play();
                StartCoroutine(Cooldown());
                
            }

        }

        KASANARI_Block();

    }

    void KASANARI_Block()
    {
        S1 = Spawn1.S1;
        S2 = Spawn2.S1;
        S3 = Spawn3.S1;
        S4 = Spawn4.S1;
        S5 = Spawn5.S1;
        S6 = Spawn6.S1;
        S7 = Spawn7.S1;
        S8 = Spawn8.S1;
        S9 = Spawn9.S1;
        S10 = Spawn10.S1;
        S11 = Spawn11.S1;
        S12 = Spawn12.S1;
        S13 = Spawn13.S1;
        S14 = Spawn14.S1;
        S15 = Spawn15.S1;
        S16 = Spawn16.S1;
        S17 = Spawn17.S1;
        S18 = Spawn18.S1;
        S19 = Spawn19.S1;
        S20 = Spawn20.S1;
        S21 = Spawn21.S1;
    }

    #endregion 


    #region  出る穴の抽選
    void Select()
    {
        while (HowTime != 0)
        {
            int rnd = Random.Range(1, 22);
            if (rnd == 1)
            {
                if (S1 == false)
                {
                    Spawn1.Change();
                    S1 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 2)
            {
                if (S2 == false)
                {
                    Spawn2.Change();
                    S2 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 3)
            {
                if (S3 == false)
                {
                    Spawn3.Change();
                    S3 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 4)
            {
                if (S4 == false)
                {
                    Spawn4.Change();
                    S4 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 5)
            {
                if (S5 == false)
                {
                    Spawn5.Change();
                    S5 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 6)
            {
                if (S6 == false)
                {
                    Spawn6.Change();
                    S6 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 7)
            {
                if (S7 == false)
                {
                    Spawn7.Change();
                    S7 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd== 8)
            {
                if (S8 == false)
                {
                    Spawn8.Change();
                    S8 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 9)
            {
                if (S9 == false)
                {
                    Spawn9.Change();
                    S9 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 10)
            {
                if (S10 == false)
                {
                    Spawn10.Change();
                    S10 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 11)
            {
                if (S11 == false)
                {
                    Spawn11.Change();
                    S11 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 12)
            {
                if (S12 == false)
                {
                    Spawn12.Change();
                    S12 = true;
                    HowTime--;
                }
                else if (S12 == true)
                {
                    Select();
                }
            }
            else if (rnd == 13)
            {
                if (S13 == false)
                {
                    Spawn13.Change();
                    S13 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 14)
            {
                if (S14 == false)
                {
                    Spawn14.Change();
                    S14 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 15)
            {
                if (S15 == false)
                {
                    Spawn15.Change();
                    S15 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 16)
            {
                if (S16 == false)
                {
                    Spawn16.Change();
                    S16 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 17)
            {
                if (S17 == false)
                {
                    Spawn17.Change();
                    S17 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 18)
            {
                if (S18 == false)
                {
                    Spawn18.Change();
                    S18 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 19)
            {
                if (S19 == false)
                {
                    Spawn19.Change();
                    S19 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else if (rnd == 20)
            {
                if (S20 == false)
                {
                    Spawn20.Change();
                    S20 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }
            else
            {
                if (S21 == false)
                {
                    Spawn21.Change();
                    S21 = true;
                    HowTime--;
                }
                else
                {
                    Select();
                }
            }

        }
        

    }

    #endregion

    #region 塩のクールダウンコルーチン

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
        Use_Solt = true;

    }


    #endregion

    #region クールダウンの塩の影に関わる関数

    void Shadow()
    {
        if (Salt == 0 && Use_Solt == false)
        {
            Black1.SetActive(false);
            Black2.SetActive(false);
            Black3.SetActive(false);
            Black4.SetActive(false);
            Black5.SetActive(false);
        }
        else if (Salt == 1 && Use_Solt == false)
        {
            Black1.SetActive(true);
            Black2.SetActive(false);
            Black3.SetActive(false);
            Black4.SetActive(false);
            Black5.SetActive(false);
        }
        else if (Salt == 2 && Use_Solt == false)
        {
            Black1.SetActive(true);
            Black2.SetActive(true);
            Black3.SetActive(false);
            Black4.SetActive(false);
            Black5.SetActive(false);
        }
        else if (Salt == 3 && Use_Solt == false)
        {
            Black1.SetActive(true);
            Black2.SetActive(true);
            Black3.SetActive(true);
            Black4.SetActive(false);
            Black5.SetActive(false);
        }
        else if (Salt == 4 && Use_Solt == false)
        {
            Black1.SetActive(true);
            Black2.SetActive(true);
            Black3.SetActive(true);
            Black4.SetActive(true);
            Black5.SetActive(false);
        }
        else if (Salt == 5 && Use_Solt == false)
        {
            Black1.SetActive(true);
            Black2.SetActive(true);
            Black3.SetActive(true);
            Black4.SetActive(true);
            Black5.SetActive(true);
        }

        if (Use_Solt)
        {
            Black1.SetActive(false);
            Black2.SetActive(false);
            Black3.SetActive(false);
            Black4.SetActive(false);
            Black5.SetActive(false);
        }

    }
    #endregion

    #region ボーナス開始とボーナスタイム時に塩が撒けなくなるコルーチンと関数

    IEnumerator Bonus()
    {
        yield return new WaitForSeconds(60);
        BonusStart.SetActive(true);
        END();

    }

    private void END()
    {
        Destroy(ObjectToShow);
        Destroy(ObjectToShow2);
        Destroy(ObjectToShow3);
        Destroy(ObjectToShow4);
        Destroy(ObjectToShow5);
        Destroy(Black1);
        Destroy(Black2);
        Destroy(Black3);
        Destroy(Black4);
        Destroy(Black5);
        Destroy(this.gameObject);
    }

    #endregion

}
