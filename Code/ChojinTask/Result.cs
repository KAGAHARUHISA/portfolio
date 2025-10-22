using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    //  ���l���ʂ̉摜
    private Image _resultImage;

    //  ���茋�ʂ̉摜���o��܂ł̎���
    [SerializeField] private float _showTime;

    //  ���ʂ����l������������BGM�������܂ł̎���
    [SerializeField] private float _brilliantBGMTime;

    //  ���ʂ��}�l���A�|���R�c������������BGM�������܂ł̎���
    [SerializeField] private float _badBGMTime;

    //  ���ʂ��Ҏҋ��A�ɍˋ�����������BGM�������܂ł̎���
    [SerializeField] private float _normalBGMTime;

    //  BGM�J�n�ƂƂ��Ɍ����^�C�g���s���̃{�^��
    [SerializeField] private GameObject _titleButton;

    //  ���ʂ����l������������SE
    [SerializeField] private AudioClip _brilliantSE;

    //  ���ʂ��}�l�����|���R�c������������SE
    [SerializeField] private AudioClip _badSE;

    //  ���ʂ��Ҏҋ��A�ɍˋ�����������SE
    [SerializeField] private AudioClip _normalSE;

    //  SE�������܂ł̎���
    [SerializeField] private float _SEPlayTime;

    //  �I�[�f�B�I�\�[�X
    [SerializeField] private AudioSource _audioSource;

    //  �]���̕����摜����
    [SerializeField] private Sprite _top;
    [SerializeField] private Sprite _second;
    [SerializeField] private Sprite _third;
    [SerializeField] private Sprite _forth;
    [SerializeField] private Sprite _fifth;

    //  ���s�����񐔂������e�L�X�g�I�u�W�F�N�g
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