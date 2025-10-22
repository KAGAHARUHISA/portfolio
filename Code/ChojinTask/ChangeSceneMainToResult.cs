using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMainToResult : MonoBehaviour
{
    //  リザルトシーンの名前
    [SerializeField] string _resultName;

    //  時間の反映のためにpublic
    public float _gamePlayTime;

    [SerializeField] private bool _rightCliked = false;

    //  開始時にいらないものを削除
    [SerializeField] private List<GameObject> _deleteObjects = new List<GameObject>();

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _fadePanel;

    // フェードアウトが終わるまでの時間
    [SerializeField] private float _fadeOutTime;

    void Start()
    {
        FadeInFadeOut fadeInFadeOut = _fadePanel.GetComponent<FadeInFadeOut>();
        fadeInFadeOut._in = true;
    }

    private void Update()
    {
        //  右クリックでスタート
        if (!_rightCliked && Input.GetMouseButtonDown(1))
        {
            _rightCliked = true;
            DeleteObjects();
        }
    }


    //  制限時間後にフェードアウトしてシーン移動
    IEnumerator MainSceneToResult()
    {
        yield return new WaitForSeconds(_gamePlayTime);
        FadeInFadeOut fadeInFadeOut = _fadePanel.GetComponent<FadeInFadeOut>();
        fadeInFadeOut._out = true;
        yield return new WaitForSeconds(_fadeOutTime);
        SceneManager.LoadScene(_resultName);
    }


    // 操作指示のテキストを表示するパネル等いらないものを削除
    private void DeleteObjects()
    {
        foreach (GameObject gameObject in _deleteObjects)
        {
            if (gameObject.activeSelf == true)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

            _audioSource.Play();
            StartCoroutine(MainSceneToResult());
        }
    }
}
