using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unicorn : MonoBehaviour
{
    //  ｘ、ｙ軸の最低座標
    [SerializeField] float _xMin, _yMin;

    //  ｘ、ｙ軸の最高座標
    [SerializeField] float _xMax, _yMax;

    //  移動速度の最高速度, 最低速度
    [SerializeField] float _maxSpeed, _minSpeed;

    //  ユニコーンの移動速度
    [SerializeField] float _speed;

   //  ユニコーンのRect
    private RectTransform _unicornRect;

    //  ユニコーンの目標到達座標
    private Vector3 _unicornAimPos;

    //  ユニコーンの現在位置
    private Vector3 _unicornNowPos;

    private void Start()
    {
        _unicornRect = GetComponent<RectTransform>();

        //  スポーンする地点をランダムにする
        float startPosX = Random.Range(_xMin, _xMax);
        float startPosY = Random.Range(_yMin, _yMax);
        _unicornNowPos = new Vector3(startPosX, startPosY, 0);
        _unicornRect.anchoredPosition = new Vector3(startPosX, startPosY,0);

        DecidePositionAndSpeed();
    }

    private void Update()
    {
        //  ユニコーンの移動
        _unicornRect.anchoredPosition = Vector3.MoveTowards(_unicornNowPos, _unicornAimPos, _speed * Time.deltaTime);
        _unicornNowPos = _unicornRect.anchoredPosition;

        //  目標到達点に到達したら再び移動地点とスピードを変える
        if (_unicornNowPos == _unicornAimPos)
        {
            DecidePositionAndSpeed();
        }

    }

    //  ユニコーンの目標到達点とスピード決定する関数
    void DecidePositionAndSpeed()
    {
        //  ユニコーンの目標到達点を決める
        float unicornAimPosX = Random.Range(_xMin, _xMax);
        float unicornAimPosY = Random.Range(_yMin, _yMax);
        _unicornAimPos = new Vector3(unicornAimPosX, unicornAimPosY, 0);

        //  スピードを決める
        _speed = Random.Range(_minSpeed, _maxSpeed);

        //  移動方向とイラストの向きによってがどちらを向くか決める
        if (_unicornAimPos.x - _unicornNowPos.x >= 0 && this.transform.localScale.x >= 0)
        {
            Vector3 inversionImage = this.transform.localScale;
            inversionImage.x *= -1;
            this.transform.localScale = inversionImage;
        }
        else if (_unicornAimPos.x - _unicornNowPos.x <= 0 && this.transform.localScale.x <= 0)
        {
            Vector3 inversionImage = this.transform.localScale;
            inversionImage.x *= -1;
            this.transform.localScale = inversionImage;
        }
    }
}
