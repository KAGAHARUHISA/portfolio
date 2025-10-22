using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosquitoMove : MonoBehaviour
{
    //  初期の横方向と縦方向の移動速度
    public float _besideSpeed,_upSpeed;

    //  横方向と縦方向の移動速度の最小値
    [SerializeField] float _besideSpeedMin, _upSpeedMin;

    //  横方向と縦方向の移動速度の最大値
    [SerializeField] float _besideSpeedMax, _upSpeedMax;

    //  上下に動かすのに直接関わる変数
    float _upManager;

    void Start()
    {
        StartCoroutine(ChangeBesideSpeed());
        StartCoroutine(ChangeUpSpeed());
        Random.InitState(System.Environment.TickCount + GetInstanceID());
    }

    // Update is called once per frame
    void Update()
    {
        //  sinを用いて蚊を上下に動かす
        _upManager = Mathf.Sin(Time.time);

        //  蚊の挙動の制御
        transform.Translate(_besideSpeed * Time.deltaTime, _upSpeed * _upManager * Time.deltaTime, 0);
    }

    //  横方向の移動速度のランダム変化
    IEnumerator ChangeBesideSpeed()
    {
        float changeBesideSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeBesideSpeedSpan);
        _besideSpeed = Random.Range(_besideSpeedMin, _besideSpeedMax) * ContinueMosquiteBesideVector()  ;
        StartCoroutine(ChangeBesideSpeed());
    }

    //  縦方向の移動速度のランダム変化
    IEnumerator ChangeUpSpeed()
    {
        float changeUpSpeedSpan = Random.Range(0.5f, 1.0f);
        yield return new WaitForSeconds(changeUpSpeedSpan);
        _upSpeed = Random.Range(_upSpeedMin, _upSpeedMax);
        StartCoroutine(ChangeUpSpeed());
    }

    //  変な移動方向切り返しを阻止する関数
    public short ContinueMosquiteBesideVector()
    {
        if (_besideSpeed < 0)
        {
            return -1;
        }
        else
        {
            return 1;
        }

    }

    //  脱出判定を持つ壁に当たったら蚊のイラストや移動方向が反転する処理
    public void MosquitoReturn()
    {
        // イラスト反転
        Vector3 localScale = this.transform.localScale;
        localScale.x *= -1;
        this.transform.localScale = localScale;

        //  移動方向反転
        _besideSpeed *= -1;

    }

    //  クリックされて復活した後にスポーン時と同じような挙動にするための関数
    public void AbjustPosY()
    {
        _upManager = 0;
    }
}
