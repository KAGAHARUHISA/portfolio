using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonSize : MonoBehaviour
{
    //  最小、最大のサイズになったか
    private bool _isMin;
    private bool _isMax;

    //  マウスカーソルがボタンに触れているか
    private bool _isTouch;

    //  縮小拡大スピード
    [SerializeField] private float _scaleSpeed;

    //  クリックしていないときのボタンの最小、最大サイズ
    [SerializeField] private Vector3 _minSize = new Vector3();
    [SerializeField] private Vector3 _maxSize = new Vector3();

    //  Imageを格納する変数
    [SerializeField] private Image _changeImage;

    //  ボタンをクリックしたかクリックを終えた際に変わるカラーを設定する(0から255の数値を入れて調整)
    [SerializeField] private Color32 _pushColor = new Color32();
    [SerializeField] private Color32 _exitColor = new Color32();

    //  オーディオソース
    [SerializeField] private AudioSource _changeSE;

    //  マウスカーソルが触れた時の処理
    public void TouchButton()
    {
        _isTouch = true;
    }

    //  マウスカーソルが触れなかった時の処理
    public void ExitButton()
    {
        _isTouch = false;
    }

    //  マウスカーソルを押した瞬間のカーソルの色変更の処理
    public void PushChangeColorButton()
    {
        _changeImage.color = _pushColor;
    }

    //  マウスカーソルをアイコン上でクリックして離した際のアイコンの色の処理
    public void ExitChangeColorButton()
    {
        _changeImage.color = _exitColor;
        _changeSE.Play();
    }


    private void Update()
    {
        if (!_isMin && _isTouch)
        {
            //  マウスカーソルで触れた時にボタンのサイズを小さくする
            transform.localScale = Vector3.Lerp(transform.localScale, _minSize, _scaleSpeed * Time.deltaTime);
            _isMax = false;
        }
        else if (!_isMax && !_isTouch)
        {
            //  マウスカーソルから離れたときにボタンのサイズを大きくする
            transform.localScale = Vector3.Lerp(transform.localScale, _maxSize, _scaleSpeed * Time.deltaTime);
            _isMin = false;
        }

        //  最大、最小の大きさになった際、無駄にLerpを起動しないフラグをオンにする
        if (transform.localScale == _minSize)
        {
            _isMin = true;
        }
        else if (transform.localScale == _maxSize)
        {
            _isMax = true;
        }
        
    }

}
