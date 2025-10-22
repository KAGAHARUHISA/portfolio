using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MosquitoClick : MonoBehaviour
{
    AudioSource _mosquitoSound;
    RectTransform _mosquitoRect;

    //  蚊を叩くSE
    [SerializeField] private AudioClip _slapSE;

    //  蚊叩きゲームを再開するまでの時間
    [SerializeField] float _RestartDelayTime;

    //  失敗に関するゲームオブジェクトを格納する変数
    [SerializeField] GameObject _mosquitoFailedManager;

    //  蚊を連続で叩くことを防止するフラグ
    bool _isAttack = false;

    //  蚊の座標
    private Vector3 _mosquitoPosition;

    //  蚊が叩かれた時の点滅周期
    [SerializeField] private float _flashCycle;

    //  蚊そのものの画像
    private Image _mosquitoImage;

    //  点滅させるのに必要な時間の受け皿
    private float _time;

    //  叩いた蚊の落下速度
    [SerializeField] private float _fallspeed;

    // Start is called before the first frame update
    void Start()
    {
        _mosquitoRect = GetComponent<RectTransform>();
        _mosquitoImage = GetComponent<Image>();
        _mosquitoSound = GetComponent<AudioSource>();
        _mosquitoPosition = this.transform.position;
    }

    void Update()
    {

        //  叩かれたらひっくり返って点滅しながら降下
        if (_isAttack)
        {
            //  点滅の処理
            _time += Time.deltaTime;
            var repeatValue = Mathf.Repeat((float)_time, _flashCycle);
            if (repeatValue >= _flashCycle * 0.5f)
            {
                _mosquitoImage.enabled = false;
            }
            else
            {
                _mosquitoImage.enabled = true;
            }

            //  叩かれて落ちる処理
            _mosquitoPosition = _mosquitoRect.position;
            _mosquitoPosition.y -= _fallspeed * Time.deltaTime;
            _mosquitoRect.position = _mosquitoPosition;

        }

    }

    //  叩かれたら作動する関数
    public void Clicked()
    {
        //  蚊が叩かれた直後でなければ条件式は通る
        if (!_isAttack)
        {
            _isAttack = true;
            Debug.Log("蚊をぶっ叩いた！！");
            _mosquitoSound.PlayOneShot(_slapSE);
            StartCoroutine(RestartGame());

            //  失敗回数をリセット
            MosquitoFailedManager mosquitoFailedManager = _mosquitoFailedManager.GetComponent<MosquitoFailedManager>();
            mosquitoFailedManager.ResetFailedTime();

            //  蚊を上下にひっくり返す
            ChangeScaleY();
            
        }
        
    }

    //  ゲームをリスタートさせるコルーチン
    IEnumerator RestartGame()
    {
        //  蚊の動きを一旦停止
        MosquitoMove mosquitoMove = GetComponent<MosquitoMove>();
        mosquitoMove.enabled = false;

        yield return new WaitForSeconds(_RestartDelayTime);

        //  リスポーン地点への移動処理
        MosquiteRespawn mosquitoRespawn = GetComponent<MosquiteRespawn>();
        mosquitoRespawn.Respawn();

        //  再び蚊を動かす&蚊を叩けるようにする
        mosquitoMove.enabled = true;
        mosquitoMove.AbjustPosY();
        _isAttack = false;

        //  蚊が透明の状態で飛ばないように確実にImageを有効にする
        _mosquitoImage.enabled = true;

        // 　蚊を上下反転させて元に戻す
        ChangeScaleY();

    }

    //  スケールのY座標に-1をかけて蚊をひっくり返したり起こす関数
    private void ChangeScaleY()
    {
        Vector3 mosquitoScale = transform.localScale;
        mosquitoScale.y *= -1;
        transform.localScale = mosquitoScale;
    }
}
