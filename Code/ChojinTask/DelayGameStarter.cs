using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayGameStarter : MonoBehaviour
{
    //  インスペクターでそのゲームの数秒後に動かしたいオブジェクトを格納する
    public List<GameObject> _stoppingObjects = new List<GameObject>();

    //  フェードアウトするまでの時間
    public float _endTime;

    //  右クリックしたかどうかのフラグ
    private bool _rightCliked = false;

    void Start()
    {
        StopObjects();
    }
    private void Update()
    {
        if (!_rightCliked && Input.GetMouseButtonDown(1))
        {
            _rightCliked = true;
            AbleObjects();
            Invoke(nameof(StopObjects), _endTime);
        }
    }

    //  止めたオブジェクトを起動させる関数
    private void AbleObjects()
    {
        foreach(GameObject gameObject in _stoppingObjects)
        {
            gameObject.SetActive(true);
        }
    }

    //  オブジェクトを止める

    private void StopObjects()
    {
        foreach (GameObject gameObject in _stoppingObjects)
        {
            gameObject.SetActive(false);
            Debug.Log(gameObject.name);
        }
    }

}
