using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneMainToResult : MonoBehaviour
{
    //  ���U���g�V�[���̖��O
    [SerializeField] string _resultName;

    //  ���Ԃ̔��f�̂��߂�public
    public float _gamePlayTime;

    [SerializeField] private bool _rightCliked = false;

    //  �J�n���ɂ���Ȃ����̂��폜
    [SerializeField] private List<GameObject> _deleteObjects = new List<GameObject>();

    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private GameObject _fadePanel;

    // �t�F�[�h�A�E�g���I���܂ł̎���
    [SerializeField] private float _fadeOutTime;

    void Start()
    {
        FadeInFadeOut fadeInFadeOut = _fadePanel.GetComponent<FadeInFadeOut>();
        fadeInFadeOut._in = true;
    }

    private void Update()
    {
        //  �E�N���b�N�ŃX�^�[�g
        if (!_rightCliked && Input.GetMouseButtonDown(1))
        {
            _rightCliked = true;
            DeleteObjects();
        }
    }


    //  �������Ԍ�Ƀt�F�[�h�A�E�g���ăV�[���ړ�
    IEnumerator MainSceneToResult()
    {
        yield return new WaitForSeconds(_gamePlayTime);
        FadeInFadeOut fadeInFadeOut = _fadePanel.GetComponent<FadeInFadeOut>();
        fadeInFadeOut._out = true;
        yield return new WaitForSeconds(_fadeOutTime);
        SceneManager.LoadScene(_resultName);
    }


    // ����w���̃e�L�X�g��\������p�l��������Ȃ����̂��폜
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
