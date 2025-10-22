using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner1 : MonoBehaviour    //適応ゾーン
{

    public GameObject Mategai1;
    public GameObject Mategai2;
    public GameObject Mategai3;
    public GameObject Agemaki;
    public GameObjectDisplayController Script;
    public bool S1;
    public bool First;
    public bool Bonus = false;


    #region   出現秒数ルーレット
    public void Change()
    {
        int Time = Random.Range(1, 6);
        int Kai = Random.Range(0, 5);
        switch (Time)
        {
            case 1:
                if (Kai == 0 || Kai == 1 || Kai == 2 || Kai == 3 || Kai == 4)
                {
                    StartCoroutine(Spawn1secA());
                }
                else
                {
                    StartCoroutine(Spawn1secA());
                }
                break;
            case 2:
                if (Kai == 0 || Kai == 1 || Kai == 2 || Kai == 3 || Kai == 4)
                {
                    StartCoroutine(Spawn2secM());
                }
                else
                {
                    StartCoroutine(Spawn2secA());
                }
                break;
            case 3:
                if (Kai == 0 || Kai == 1 || Kai == 2 || Kai == 3 || Kai == 4)
                {
                    StartCoroutine(Spawn3secM());
                }
                else
                {
                    StartCoroutine(Spawn3secA());
                }
                break;
            case 4:
                if (Kai == 0 || Kai == 1 || Kai == 2 || Kai == 3 || Kai == 4)
                {
                    StartCoroutine(Spawn4secM());
                }
                else
                {
                    StartCoroutine(Spawn4secA());
                }
                break;
            case 5:
                if (Kai == 0 || Kai == 1 || Kai == 2 || Kai == 3 || Kai == 4)
                {
                    StartCoroutine(Spawn5secM());
                }
                else
                {
                    StartCoroutine(Spawn5secA());
                }
                break;


        }

    }

    #endregion


    #region  １～５秒ごとに機能するコルーチン保管庫
    IEnumerator Spawn1secM()
    {
        First = true;
        yield return new WaitForSeconds(1);
        int WhatMategai = Random.Range(0, 3);
        if (WhatMategai == 0)
        {
            GameObject MATE1 = Instantiate(Mategai1);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE1.transform.SetParent(transform, false);
        }
        else if (WhatMategai == 1)
        {
            GameObject MATE2 = Instantiate(Mategai2);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE2.transform.SetParent(transform, false);
        }
        else
        {
            GameObject MATE3 = Instantiate(Mategai3);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE3.transform.SetParent(transform, false);
        }
        First = false;
    }

    IEnumerator Spawn1secA()
    {
        First = true;
        yield return new WaitForSeconds(1);
        GameObject AGE = Instantiate(Agemaki);
        Instantiate(Agemaki, new Vector3(0, -97f, -1f), Quaternion.identity);
        AGE.transform.SetParent(transform, false);
        First = false;
    }

    IEnumerator Spawn2secM()
    {
        First = true;
        yield return new WaitForSeconds(2);
        int WhatMategai = Random.Range(0, 3);
        if (WhatMategai == 0)
        {
            GameObject MATE1 = Instantiate(Mategai1);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE1.transform.SetParent(transform, false);
        }
        else if (WhatMategai == 1)
        {
            GameObject MATE2 = Instantiate(Mategai2);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE2.transform.SetParent(transform, false);
        }
        else
        {
            GameObject MATE3 = Instantiate(Mategai3);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE3.transform.SetParent(transform, false);
        }
        First = false;
    }

    IEnumerator Spawn2secA()
    {
        First = true;
        yield return new WaitForSeconds(2);
        GameObject AGE = Instantiate(Agemaki);
        Instantiate(Agemaki, new Vector3(0, -97f, -1f), Quaternion.identity);
        AGE.transform.SetParent(transform, false);
        First = false;
    }

    IEnumerator Spawn3secM()
    {
        First = true;
        yield return new WaitForSeconds(3);
        int WhatMategai = Random.Range(0, 3);
        if (WhatMategai == 0)
        {
            GameObject MATE1 = Instantiate(Mategai1);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE1.transform.SetParent(transform, false);
        }
        else if (WhatMategai == 1)
        {
            GameObject MATE2 = Instantiate(Mategai2);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE2.transform.SetParent(transform, false);
        }
        else
        {
            GameObject MATE3 = Instantiate(Mategai3);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE3.transform.SetParent(transform, false);
        }
        First = false;
    }

    IEnumerator Spawn3secA()
    {
        First = true;
        yield return new WaitForSeconds(3);
        GameObject AGE = Instantiate(Agemaki);
        Instantiate(Agemaki, new Vector3(0, -97f, -1f), Quaternion.identity);
        AGE.transform.SetParent(transform, false);
        First = false;
    }

    IEnumerator Spawn4secM()
    {
        First = true;
        yield return new WaitForSeconds(4);
        int WhatMategai = Random.Range(0, 3);
        if (WhatMategai == 0)
        {
            GameObject MATE1 = Instantiate(Mategai1);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE1.transform.SetParent(transform, false);
        }
        else if (WhatMategai == 1)
        {
            GameObject MATE2 = Instantiate(Mategai2);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE2.transform.SetParent(transform, false);
        }
        else
        {
            GameObject MATE3 = Instantiate(Mategai3);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE3.transform.SetParent(transform, false);
        }
        First = false;
    }

    IEnumerator Spawn4secA()
    {
        First = true;
        yield return new WaitForSeconds(4);
        GameObject AGE = Instantiate(Agemaki);
        Instantiate(Agemaki, new Vector3(0, -97f, -1f), Quaternion.identity);
        AGE.transform.SetParent(transform, false);
        First = false;
    }

    IEnumerator Spawn5secM()
    {
        First = true;
        yield return new WaitForSeconds(5);
        int WhatMategai = Random.Range(0, 3);
        if (WhatMategai == 0)
        {
            GameObject MATE1 = Instantiate(Mategai1);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE1.transform.SetParent(transform, false);
        }
        else if (WhatMategai == 1)
        {
            GameObject MATE2 = Instantiate(Mategai2);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE2.transform.SetParent(transform, false);
        }
        else
        {
            GameObject MATE3 = Instantiate(Mategai3);
            Instantiate(Mategai1, new Vector3(0, -97f, -1f), Quaternion.identity);
            MATE3.transform.SetParent(transform, false);
        }
        First = false;
    }

    IEnumerator Spawn5secA()
    {
        First = true;
        yield return new WaitForSeconds(5);
        GameObject AGE = Instantiate(Agemaki);
        Instantiate(Agemaki, new Vector3(0, -97f, -1f), Quaternion.identity);
        AGE.transform.SetParent(transform, false);
        First = false;
    }

    #endregion

    private void Update()
    {
        Transform IsMG = this.transform.Find("Mategai(Clone)");
        Transform IsMG1 = this.transform.Find("Mategai1(Clone)");
        Transform IsMG2 = this.transform.Find("Mategai2(Clone)");
        Transform IsAM = this.transform.Find("Agemaki(Clone)");

        if (First == false)
        {
            S1 = false;
            Bonus = false;
        }

        if (First || IsMG != null || IsAM != null || IsMG1 != null || IsMG2 != null)
        {
            S1 = true;
            Bonus = true;
        }
    }

    #region ボーナスタイム時の出現の仕組み

    public void BONUS()
    {

        int WhatMategai = Random.Range(0, 3);
        if (WhatMategai == 0)
        {
            GameObject MATE1 = Instantiate(Mategai1);
            Instantiate(Mategai1, new Vector3(0, -97f, 0), Quaternion.identity);
            MATE1.transform.SetParent(transform, false);
        }
        else if (WhatMategai == 1)
        {
            GameObject MATE2 = Instantiate(Mategai2);
            Instantiate(Mategai1, new Vector3(0, -97f, 0), Quaternion.identity);
            MATE2.transform.SetParent(transform, false);
        }
        else
        {
            GameObject MATE3 = Instantiate(Mategai3);
            Instantiate(Mategai1, new Vector3(0, -97f, 0), Quaternion.identity);
            MATE3.transform.SetParent(transform, false);
        }


    }


    #endregion
}