using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowNowTime : MonoBehaviour
{
    TextMeshProUGUI _showTime;
    float _nowTime;

    //  制限時間を変更できるスクリプトを持つゲームオブジェクト
    [SerializeField] GameObject _timeHasObject;
    ChangeSceneMainToResult _changeSceneMainToResult;
    // Start is called before the first frame update
    void Start()
    {
        _showTime = GetComponent<TextMeshProUGUI>();
        _changeSceneMainToResult = _timeHasObject.GetComponent<ChangeSceneMainToResult>();
        _nowTime = _changeSceneMainToResult._gamePlayTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (_nowTime > 0)
        {
            _nowTime -= Time.deltaTime;
        }
        else
        {
            _nowTime = 0;
        }
        
        _showTime.text = _nowTime.ToString("F0") + "秒";
    }
}
