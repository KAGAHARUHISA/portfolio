using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    //  超人結果の画像
    private Image _resultImage;

    //  測定結果の画像が出るまでの時間
    [SerializeField] private float _showTime;

    //  結果が超人級だった時にBGMが流れるまでの時間
    [SerializeField] private float _brilliantBGMTime;

    //  結果が凡人級、ポンコツ級だった時にBGMが流れるまでの時間
    [SerializeField] private float _badBGMTime;

    //  結果が猛者級、惜才級だった時にBGMが流れるまでの時間
    [SerializeField] private float _normalBGMTime;

    //  BGM開始とともに現れるタイトル行きのボタン
    [SerializeField] private GameObject _titleButton;

    //  結果が超人級だった時のSE
    [SerializeField] private AudioClip _brilliantSE;

    //  結果が凡人級かポンコツ級だった時のSE
    [SerializeField] private AudioClip _badSE;

    //  結果が猛者級、惜才級だった時のSE
    [SerializeField] private AudioClip _normalSE;

    //  SEが流れるまでの時間
    [SerializeField] private float _SEPlayTime;

    //  オーディオソース
    [SerializeField] private AudioSource _audioSource;

    //  評価の文字画像たち
    [SerializeField] private Sprite _top;
    [SerializeField] private Sprite _second;
    [SerializeField] private Sprite _third;
    [SerializeField] private Sprite _forth;
    [SerializeField] private Sprite _fifth;

    //  失敗した回数を示すテキストオブジェクト
    //[SerializeField] private GameObject _failedTimeText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
        _titleButton.SetActive(false);
        //_failedTimeText.SetActive(false);
        _resultImage = GetComponent<Image>();
        _resultImage.color = new Color(1, 1, 1, 0);
    }

    IEnumerator ShowText()
    {
        yield return new WaitForSeconds(_showTime);

        int failedTime = AllMiniGameFailedManager.FAILED_TIME;
        _resultImage = GetComponent<Image>();

        if (failedTime == 0)
        {
            _resultImage.sprite = _top;
            StartCoroutine(PlayBrilliantSE());
        }
        else if (failedTime == 1)
        {
            _resultImage.sprite = _second;
            StartCoroutine(PlayNormalSE());
        }
        else if (failedTime == 2)
        {
            _resultImage.sprite = _third;
            StartCoroutine(PlayNormalSE());
        }
        else if (failedTime == 3)
        {
            _resultImage.sprite = _forth;
            StartCoroutine(PlayBadSE());
        }
        else
        {
            _resultImage.sprite = _fifth;
            StartCoroutine(PlayBadSE());
        }

        _resultImage.color = new Color(1, 1, 1, 1);
        //_failedTimeText.SetActive(true);
    }

    IEnumerator PlayBrilliantSE()
    {
        yield return new WaitForSeconds(_SEPlayTime);
        _audioSource.PlayOneShot(_brilliantSE);
        yield return new WaitForSeconds(_brilliantBGMTime);
        StartResultBGM();
    }

    IEnumerator PlayBadSE()
    {
        yield return new WaitForSeconds(_SEPlayTime);
        _audioSource.PlayOneShot(_badSE);
        yield return new WaitForSeconds(_badBGMTime);
        StartResultBGM();
    }

    IEnumerator PlayNormalSE()
    {
        yield return new WaitForSeconds(_SEPlayTime);
        _audioSource.PlayOneShot(_normalSE);
        yield return new WaitForSeconds(_normalBGMTime);
        StartResultBGM();
    }

    private void StartResultBGM()
    {
        _audioSource.Play();
        _titleButton.SetActive(true);
    }

}